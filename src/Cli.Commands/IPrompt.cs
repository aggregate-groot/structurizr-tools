namespace AggregateGroot.Structurizr.Tools.Cli.Commands
{
    /// <summary>
    /// Interface for types that provide prompting for user input.
    /// </summary>
    public interface IPrompt
    {
        /// <summary>
        /// Prompts the user for a string value.
        /// </summary>
        /// <param name="prompt">
        /// Required test to display for the user.
        /// </param>
        /// <param name="defaultValue">
        /// Value to display to the user for the default value.
        /// </param>
        /// <returns>
        /// The value provided by the user.
        /// </returns>
        string? GetString(string prompt, string defaultValue);

        /// <summary>
        /// Prompts the user for a required string value. If no value is provided,
        /// an exception will be thrown.
        /// </summary>
        /// <param name="prompt">
        /// Required test to display for the user.
        /// </param>
        /// <param name="defaultValue">
        /// Value to display to the user for the default value.
        /// </param>
        /// <returns>
        /// The value provided by the user.
        /// </returns>
        string GetRequiredString(string prompt, string defaultValue);
    }
}