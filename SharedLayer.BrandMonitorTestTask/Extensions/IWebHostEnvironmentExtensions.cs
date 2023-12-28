using Microsoft.Extensions.Hosting;

namespace SharedLayer.BrandMonitorTestTask.Extensions;

/// <summary>
/// <see cref="IHostEnvironment">IHostEnvironment</see> extensions class.
/// </summary>
// ReSharper disable once InconsistentNaming
public static class IWebHostEnvironmentExtensions
{
    /// <summary>
    /// Checks, if the current host environment name is equivalent to "Debug" string value constant.
    /// </summary>
    /// <param name="hostEnvironment">An instance of <see cref="IHostEnvironment">IHostEnvironment</see>.</param>
    /// <returns>True, if the environment name is equivalent to "Debug" string value constant. Otherwise, returns false.</returns>
    public static bool IsDebug(this IHostEnvironment hostEnvironment)
    {
        return hostEnvironment.IsEnvironment("Debug");
    }
}