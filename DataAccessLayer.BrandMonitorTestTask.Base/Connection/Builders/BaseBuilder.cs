using System;
using DataAccessLayer.BrandMonitorTestTask.Base.Interfaces.Connection;

namespace DataAccessLayer.BrandMonitorTestTask.Base.Connection.Builders;

/// <summary>
/// Base database connection string build implementing class.
/// </summary>
public abstract class BaseBuilder : IConnectionStringBuilder
{
    /// <summary>
    /// Connection string value field.
    /// </summary>
    private readonly Lazy<string> connectionString;

    /// <summary>
    /// Constructor.
    /// </summary>
    protected BaseBuilder()
    {
        this.connectionString = new Lazy<string>(this.buildConnectionString);
    }

    /// <summary>
    /// Build connection string implementation method.
    /// </summary>
    /// <returns>Connection string value.</returns>
    protected abstract string buildConnectionString();

    /// <summary>
    /// Database connection string building method.
    /// </summary>
    /// <returns>Database connection string.</returns>
    public string BuildConnectionString()
    {
        return this.connectionString.Value;
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return $"Connection string: {this.connectionString.Value}";
    }
}