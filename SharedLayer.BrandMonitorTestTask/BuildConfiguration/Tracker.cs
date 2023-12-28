using SharedLayer.BrandMonitorTestTask.BuildConfiguration.Constants;

// ReSharper disable UnusedMember.Global

namespace SharedLayer.BrandMonitorTestTask.BuildConfiguration;

/// <summary>
/// Build configuration tracking class.
/// </summary>
public static partial class Tracker
{
    /// <summary>
    /// Checks, if the current host environment name is equivalent to <see cref="BuildConfigurations.Debug">BuildConfigurations.Debug</see> one value constant.
    /// </summary>
    /// <returns>True, if the build configuration is equivalent to <see cref="BuildConfigurations.Debug">BuildConfigurations.Debug</see> one value constant. Otherwise, returns false.</returns>
    public static bool IsDebug()
    {
        // ReSharper disable once RedundantNameQualifier
        return Tracker.Info.Type == BuildConfigurations.Debug;
    }

    /// <summary>
    /// Checks, if the current host environment name is equivalent to <see cref="BuildConfigurations.Development">BuildConfigurations.Development</see> one value constant.
    /// </summary>
    /// <returns>True, if the build configuration is equivalent to <see cref="BuildConfigurations.Development">BuildConfigurations.Development</see> one value constant. Otherwise, returns false.</returns>
    public static bool IsDevelopment()
    {
        // ReSharper disable once RedundantNameQualifier
        return Tracker.Info.Type == BuildConfigurations.Development;
    }

    /// <summary>
    /// Checks, if the current host environment name is equivalent to <see cref="BuildConfigurations.Test">BuildConfigurations.Test</see> one value constant.
    /// </summary>
    /// <returns>True, if the build configuration is equivalent to <see cref="BuildConfigurations.Test">BuildConfigurations.Test</see> one value constant. Otherwise, returns false.</returns>
    public static bool IsTest()
    {
        // ReSharper disable once RedundantNameQualifier
        return Tracker.Info.Type == BuildConfigurations.Test;
    }

    /// <summary>
    /// Checks, if the current host environment name is equivalent to <see cref="BuildConfigurations.Preproduction">BuildConfigurations.Preproduction</see> one value constant.
    /// </summary>
    /// <returns>True, if the build configuration is equivalent to <see cref="BuildConfigurations.Preproduction">BuildConfigurations.Preproduction</see> one value constant. Otherwise, returns false.</returns>
    public static bool IsPreproduction()
    {
        // ReSharper disable once RedundantNameQualifier
        return Tracker.Info.Type == BuildConfigurations.Preproduction;
    }

    /// <summary>
    /// Checks, if the current host environment name is equivalent to <see cref="BuildConfigurations.Production">BuildConfigurations.Production</see> one value constant.
    /// </summary>
    /// <returns>True, if the build configuration is equivalent to <see cref="BuildConfigurations.Production">BuildConfigurations.Production</see> one value constant. Otherwise, returns false.</returns>
    public static bool IsProduction()
    {
        // ReSharper disable once RedundantNameQualifier
        return Tracker.Info.Type == BuildConfigurations.Production;
    }
}