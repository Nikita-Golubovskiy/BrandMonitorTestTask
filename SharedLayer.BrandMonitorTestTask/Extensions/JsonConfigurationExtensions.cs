using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace SharedLayer.BrandMonitorTestTask.Extensions;

/// <summary>
/// Custom JSON configuration extensions, similar to
/// <see cref="Microsoft.Extensions.Configuration.JsonConfigurationExtensions">JsonConfigurationExtensions</see> one.
/// </summary>
public static class JsonConfigurationExtensions
{
    /// <summary>
    /// Embedded JSON file resource loading method.
    /// </summary>
    /// <param name="configurationBuilder">Configuration builder instance, implementing <see cref="IConfigurationBuilder">IConfigurationBuilder</see> interface.</param>
    /// <param name="jsonConfigurator">JSON loading/configuring builder implementation configuration delegate reference value.</param>
    /// <param name="assembly">Source assembly value, from which one embedded JSON file must be loaded.</param>
    /// <param name="relativeResourcePath">Relative namespace-based file name value.</param>
    /// <returns>Loaded JSON resource/file configuration root reference value.</returns>
    public static IConfigurationRoot LoadEmbeddedJsonFile(
        this IConfigurationBuilder configurationBuilder,
        Func<IConfigurationBuilder, Stream, IConfigurationBuilder> jsonConfigurator,
        Assembly assembly,
        string relativeResourcePath
    ) {
        var resourcePath = assembly
            .GetManifestResourceNames()
            .Single(resourceName => resourceName.EndsWith(relativeResourcePath));

        using var stream = assembly.GetManifestResourceStream(resourcePath);

        configurationBuilder = jsonConfigurator.Invoke(configurationBuilder, stream);

        return configurationBuilder.Build();
    }
}