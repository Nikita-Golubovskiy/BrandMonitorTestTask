namespace DataAccessLayer.BrandMonitorTestTask.Base.Interfaces.Connection;

/// <summary>
/// Database connection string builder interface.
/// </summary>
public interface IConnectionStringBuilder
{
    /// <summary>
    /// Database connection string building method.
    /// </summary>
    /// <returns>Database connection string.</returns>
    string BuildConnectionString();
}