using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands.Templating
{
    /// <summary>
    /// .NET implementation of the <see cref="ITemplateEngine"/> interface.
    /// </summary>
    public class DotNetTemplateEngine : ITemplateEngine
    {
        /// <summary>
        /// Creates a new instance of the <see cref="DotNetTemplateEngine"/> class.
        /// </summary>
        /// <param name="cliProvider">
        /// Required type used to invoke the dotnet CLI.
        /// </param>
        public DotNetTemplateEngine(ICliProvider cliProvider)
        {
            _cliProvider = cliProvider 
                ?? throw new ArgumentNullException(nameof(cliProvider));
        }
        
        /// <inheritdoc />
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="template"/> is not provided.
        /// </exception>
        public async Task RunAsync(ISourceTemplate template)
        {
            if (template == null)
            {
                throw new ArgumentNullException(nameof(template));
            }

            string argumentText = BuildArgumentText(template.Arguments);
            
            await ConfirmTemplateInstallationAsync(template.Name);

            await _cliProvider.ExecuteAsync("dotnet", $"new {template.Name}{argumentText}");
        }
        
        private readonly ICliProvider _cliProvider;
        
        /// <summary>
        /// Builds the argument string for passing to the dotnet CLI.
        /// </summary>
        /// <param name="arguments">
        /// Required list arguments to passing to the template.
        /// </param>
        private static string BuildArgumentText(IEnumerable<KeyValuePair<string, string>> arguments)
        {
            StringBuilder builder = new();
            
            foreach (KeyValuePair<string,string> argument in arguments)
            {
                builder.Append($" --{argument.Key} \"{argument.Value}\"");
            }
            
            return builder.ToString();
        }
        
        /// <summary>
        /// Determines if the provided <paramref name="templateName"/> is installed .
        /// </summary>
        /// <param name="templateName">
        /// Required name of the template to check.
        /// </param>
        /// <returns>
        /// True if the template is installed, otherwise false.
        /// </returns>
        private async Task ConfirmTemplateInstallationAsync(string templateName)
        {
            string result = await _cliProvider.ExecuteAsync("dotnet", $"new list {templateName}");

            if (result.Contains("No templates found")) {
                throw new InvalidOperationException($"The template '{templateName}' is not installed.");
            }
        }
    }
}