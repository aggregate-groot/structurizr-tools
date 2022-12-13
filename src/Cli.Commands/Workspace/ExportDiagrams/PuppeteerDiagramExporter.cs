using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

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
                Console.WriteLine($"File: {fileName}");
                string trimmedContent = diagramContent.Replace(@"data:image/png;base64,", "");
                try
                {
                    diagrams.Add(new Diagram()
                    {
                        Content =  Convert.FromBase64String(trimmedContent), 
                        Name = fileName
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
                Console.WriteLine("Saved.");
                return true;
            });
            
            await page.WaitForFunctionAsync("() => structurizr.scripting && structurizr.scripting.isDiagramRendered() === true");

            var views = await page.EvaluateFunctionAsync<dynamic>("() => structurizr.scripting.getViews()");

            foreach (dynamic view in views)
            {
                Console.WriteLine($"View: {view.key}");
                await page.EvaluateFunctionAsync("(diagramKey) => {structurizr.scripting.changeView(diagramKey);}", view.key);
                await page.WaitForFunctionAsync("() => structurizr.scripting.isDiagramRendered() === true");
                await page.EvaluateFunctionAsync(
                    "(diagramFilename) => { structurizr.scripting.exportCurrentDiagramToPNG({ crop: false }, function (png) {window.exportDiagram(png, diagramFilename);})}",
                    view.key);
                await page.EvaluateFunctionAsync(
                    "(diagramFilename) => { structurizr.scripting.exportCurrentDiagramKeyToPNG(function (png) {window.exportDiagram(png, diagramFilename);})}",
                    view.key + "-key");
            }

            return diagrams;
        }
    }
}