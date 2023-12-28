// Enable this variant of building configuration only for production build configuration mode.

#if PRODUCTION

using SharedLayer.BrandMonitorTestTask.BuildConfiguration.Constants;

// ReSharper disable once CheckNamespace
namespace SharedLayer.BrandMonitorTestTask.BuildConfiguration;

/// <summary>
/// Build configuration tracking class.
/// </summary>
public static partial class Tracker
{
    /// <summary>
    /// Build configuration/informational section class.
    /// </summary>
    public static class Info
    {
        /// <summary>
        /// Build configuration type of <see cref="BuildConfigurations" /> value constant.
        /// </summary>
        public static readonly BuildConfigurations Type;

        /// <summary>
        /// Static constructor.
        /// </summary>
        static Info()
        {
            Tracker.Info.Type = BuildConfigurations.Production;
        }
    }
}

#endif