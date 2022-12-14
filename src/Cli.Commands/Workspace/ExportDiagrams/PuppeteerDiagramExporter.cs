using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using PuppeteerSharp;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.ExportDiagrams
{
    /// <summary>
    /// Implementation of the <see cref="IDiagramExporter"/> interface that uses Puppeteer
    /// to automate diagram exporting to png format.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PuppeteerDiagramExporter : IDiagramExporter
    {
        /// <inheritdoc />
        public async Task<IEnumerable<Diagram>> ExportAllAsync(ushort port)
        {
            using BrowserFetcher browserFetcher = new();
            await browserFetcher.DownloadAsync();

            await using IBrowser? browser = await Puppeteer.LaunchAsync(
                new LaunchOptions { Headless = true });

            await using IPage? page = await browser.NewPageAsync();

            await page.GoToAsync($"http://localhost:{port}/", WaitUntilNavigation.DOMContentLoaded);

            List<Diagram> diagrams = new();

            await page.ExposeFunctionAsync<string, string, bool>("exportDiagram", (diagramContent, fileName) =>
            {
                string trimmedContent = diagramContent.Replace(@"data:image/png;base64,", "");
                try
                {
                    diagrams.Add(new Diagram()
                    {
                        Content = Convert.FromBase64String(trimmedContent),
                        Name = RenameView(fileName)
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return true;
            });

            await page.WaitForFunctionAsync(
                "() => structurizr.scripting && structurizr.scripting.isDiagramRendered() === true");

            await ProcessViewsAsync(page);

            return diagrams;
        }

        /// <summary>
        /// Processes all of the views in the workspace.
        /// </summary>
        /// <param name="page">
        /// Required instance of the page to execute the JavaScript on.
        /// </param>
        private static async Task ProcessViewsAsync(IPage page)
        {
            dynamic? views = await page.EvaluateFunctionAsync<dynamic>("() => structurizr.scripting.getViews()");

            foreach (dynamic view in views)
            {
                await page.EvaluateFunctionAsync("(diagramKey) => {structurizr.scripting.changeView(diagramKey);}",
                    view.key);
                await page.WaitForFunctionAsync("() => structurizr.scripting.isDiagramRendered() === true");
                await page.EvaluateFunctionAsync(
                    "(diagramFilename) => { structurizr.scripting.exportCurrentDiagramToPNG({ crop: false }, function (png) {window.exportDiagram(png, diagramFilename);})}",
                    view.key);
                await page.EvaluateFunctionAsync(
                    "(diagramFilename) => { structurizr.scripting.exportCurrentDiagramKeyToPNG(function (png) {window.exportDiagram(png, diagramFilename);})}",
                    view.key + "-key");
            }
        }

        /// <summary>
        /// Renames a diagram view to kabob case.
        /// </summary>
        /// <param name="viewName">
        /// Require name of the view to rename.
        /// </param>
        private static string RenameView(string viewName)
        {
            StringBuilder nameBuilder = new();
            nameBuilder.Append(char.ToLowerInvariant(viewName[0]));
            
            for (int i = 1; i < viewName.Length; i++)
            {
                char currentCharacter = viewName[i];
                if (char.IsUpper(currentCharacter))
                {
                    nameBuilder.Append('-');
                    nameBuilder.Append(char.ToLowerInvariant(currentCharacter));
                }
                else
                {
                    nameBuilder.Append(viewName[i]);
                }
            }

            return nameBuilder.ToString();
        }
    }
}