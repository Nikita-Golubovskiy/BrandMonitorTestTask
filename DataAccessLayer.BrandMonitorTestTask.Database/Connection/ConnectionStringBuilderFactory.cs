using System.Diagnostics.CodeAnalysis;
using DataAccessLayer.BrandMonitorTestTask.Base.Interfaces.Connection;
using SharedLayer.BrandMonitorTestTask.BuildConfiguration;
using SharedLayer.BrandMonitorTestTask.BuildConfiguration.Constants;
using SharedLayer.BrandMonitorTestTask.Extensions;

namespace DataAccessLayer.BrandMonitorTestTask.Database.Connection;

/// <summary>
/// Implementation of <see cref="IConnectionStringBuilderFactory">IConnectionStringBuilderFactory</see> interface class.
/// </summary>
internal sealed class ConnectionStringBuilderFactory : IConnectionStringBuilderFactory
{
    /// <summary>
    /// An instance of <see cref="IConnectionStringBuilder">IConnectionStringBuilder</see> creating method.
    /// </summary>
    /// <param name="clientName">Name of some connection-dependent object.</param>
    /// <returns>An instance of <see cref="IConnectionStringBuilder">IConnectionStringBuilder</see>.</returns>
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public IConnectionStringBuilder CreateConnectionStringBuilder(string clientName)
    {
        return Tracker.Info.Type switch
        {
            BuildConfigurations.Debug => new Builders.FromConfigurationFile(
                clientName,
                BuildConfigurations.Debug.GetName(),
                "BrandMonitor",
                "iWR2IZtce"
            ),

            BuildConfigurations.Development => new Builders.FromConfigurationFile(
                clientName,
                BuildConfigurations.Development.GetName(),
                "BrandMonitor",
                "iWR2IZtce"
            ),

            BuildConfigurations.Test => new Builders.FromConfigurationFile(
                clientName,
                BuildConfigurations.Test.GetName(),
                "BrandMonitor",
                "iWR2IZtce"
            ),

            BuildConfigurations.Preproduction => new Builders.FromConfigurationFile(
                clientName,
                BuildConfigurations.Preproduction.GetName(),
                "BrandMonitor",
                "iWR2IZtce"
            ),

            BuildConfigurations.Production => new Builders.FromConfigurationFile(
                clientName,
                BuildConfigurations.Production.GetName(),
                "BrandMonitor",
                "iWR2IZtce"
            ),

            _ => new Builders.FromConfigurationFile(
                clientName,
                BuildConfigurations.Debug.GetName(),
                "BrandMonitor",
                "iWR2IZtce"
            )
        };
    }
}