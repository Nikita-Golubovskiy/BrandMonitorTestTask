using System;
using SharedLayer.BrandMonitorTestTask.BuildConfiguration.Constants;
using SharedLayer.BrandMonitorTestTask.Interfaces;

namespace SharedLayer.BrandMonitorTestTask.Converters;

/// <summary>
/// <see cref="BuildConfigurations">BuildConfigurations</see> to string converter class.
/// </summary>
public sealed class BuildConfigurationToString : IConverter<BuildConfigurations, string>
{
    /// <summary>
    /// Value conversion method.
    /// </summary>
    /// <param name="source">Source value to convert.</param>
    /// <returns>Result/converted value.</returns>
    /// <exception cref="ArgumentException">Throws, if source value is incorrect one.</exception>
    public string Convert(BuildConfigurations source)
    {
        return source switch
        {
            BuildConfigurations.Debug => nameof(BuildConfigurations.Debug),
            BuildConfigurations.Development => nameof(BuildConfigurations.Development),
            BuildConfigurations.Test => nameof(BuildConfigurations.Test),
            BuildConfigurations.Preproduction => nameof(BuildConfigurations.Preproduction),
            BuildConfigurations.Production => nameof(BuildConfigurations.Production),

            _ => throw new ArgumentException(nameof(source))
        };
    }

    /// <summary>
    /// Value reverse-conversion method.
    /// </summary>
    /// <param name="source">Source value to reverse-convert.</param>
    /// <returns>Result/reverse-converted value.</returns>
    /// <exception cref="ArgumentException">Throws, if source value is incorrect one.</exception>
    public BuildConfigurations ConvertBack(string source)
    {
        return source switch
        {
            nameof(BuildConfigurations.Debug) => BuildConfigurations.Debug,
            nameof(BuildConfigurations.Development) => BuildConfigurations.Development,
            nameof(BuildConfigurations.Test) => BuildConfigurations.Test,
            nameof(BuildConfigurations.Preproduction) => BuildConfigurations.Preproduction,
            nameof(BuildConfigurations.Production) => BuildConfigurations.Production,

            _ => throw new ArgumentException(nameof(source))
        };
    }
}