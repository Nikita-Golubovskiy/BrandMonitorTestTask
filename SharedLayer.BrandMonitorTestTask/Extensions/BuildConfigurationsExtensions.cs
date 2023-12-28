using SharedLayer.BrandMonitorTestTask.BuildConfiguration.Constants;
using SharedLayer.BrandMonitorTestTask.Converters;
using SharedLayer.BrandMonitorTestTask.Interfaces;

// ReSharper disable UnusedMember.Global

namespace SharedLayer.BrandMonitorTestTask.Extensions;

/// <summary>
/// <see cref="BuildConfigurations">BuildConfigurations</see> extensions class.
/// </summary>
public static class BuildConfigurationsExtensions
{
    /// <summary>
    /// Build configuration value to string one converter reference field.
    /// </summary>
    private static readonly IConverter<BuildConfigurations, string> buildConfigurationToStringConverter;

    /// <summary>
    /// Static constructor.
    /// </summary>
    static BuildConfigurationsExtensions()
    {
        BuildConfigurationsExtensions.buildConfigurationToStringConverter = new BuildConfigurationToString();
    }

    /// <summary>
    /// Build configuration to name string conversion extension method.
    /// </summary>
    /// <param name="buildConfiguration">Build configuration value to convert.</param>
    /// <returns>Build configuration value as string one.</returns>
    public static string GetName(this BuildConfigurations buildConfiguration)
    {
        return BuildConfigurationsExtensions
            .buildConfigurationToStringConverter
            .Convert(buildConfiguration);
    }

    /// <summary>
    /// Build configuration name as uppercase string one obtaining extension method.
    /// </summary>
    /// <param name="buildConfiguration">Build configuration value to convert.</param>
    /// <returns>Build configuration name as uppercase string one.</returns>
    public static string GetNameInUpperCase(this BuildConfigurations buildConfiguration)
    {
        return buildConfiguration
            .GetName()
            .ToUpper();
    }
}