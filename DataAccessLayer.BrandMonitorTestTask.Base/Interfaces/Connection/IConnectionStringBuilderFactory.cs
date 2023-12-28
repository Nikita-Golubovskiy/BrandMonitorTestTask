namespace DataAccessLayer.BrandMonitorTestTask.Base.Interfaces.Connection;

/// <summary>
/// Connection string builder factory interface.
/// </summary>
public interface IConnectionStringBuilderFactory
{
    /// <summary>
    /// An instance of <see cref="IConnectionStringBuilder">IConnectionStringBuilder</see> creating method.
    /// </summary>
    /// <param name="clientName">Name of some connection-dependent object.</param>
    /// <returns>An instance of <see cref="IConnectionStringBuilder">IConnectionStringBuilder</see>.</returns>
    IConnectionStringBuilder CreateConnectionStringBuilder(string clientName);
}