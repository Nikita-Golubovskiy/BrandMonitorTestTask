using System;
using System.Data.SqlClient;
using System.Security;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using SharedLayer.BrandMonitorTestTask.Extensions;
using System.Reflection;
using DataAccessLayer.BrandMonitorTestTask.Base.Connection.Builders;

using ErrorMessages = DataAccessLayer.BrandMonitorTestTask.Database.Assets.Strings.Errors;
using Configuration = DataAccessLayer.BrandMonitorTestTask.Database.Assets.Strings.Configuration;

using JsonConfigurationExtensions = Microsoft.Extensions.Configuration.JsonConfigurationExtensions;

// ReSharper disable UnusedMember.Global

namespace DataAccessLayer.BrandMonitorTestTask.Database.Connection.Builders;

/// <summary>
/// Database connection string build from configuration file implementing class.
/// </summary>
internal sealed class FromConfigurationFile : BaseBuilder
{
    /// <summary>
    /// JSON configuration file accessor keeper reference field.
    /// </summary>
    private static readonly Lazy<IConfigurationRoot> configurationFileKeeper;

    /// <summary>
    /// <see cref="SqlConnectionStringBuilder">SqlConnectionStringBuilder</see> reference field.
    /// </summary>
    private readonly SqlConnectionStringBuilder connectionStringBuilder;

    /// <summary>
    /// Static constructor.
    /// </summary>
    static FromConfigurationFile()
    {
        FromConfigurationFile.configurationFileKeeper = new Lazy<IConfigurationRoot>(() =>
        {
            var configurationBuilder = new ConfigurationBuilder();

            return configurationBuilder.LoadEmbeddedJsonFile(
                JsonConfigurationExtensions.AddJsonStream,
                Assembly.GetExecutingAssembly(),
                Configuration.Connection.FILE_NAME
            );
        });
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="database">Database connection configuration name.</param>
    /// <param name="connectionName">Database connection name.</param>
    /// <param name="login">Database user login value.</param>
    /// <param name="password">Database user password value.</param>
    /// <exception cref="JsonException">Throws, if database connection section contains incorrect JSON or required section(s) are missing.</exception>
    /// <exception cref="SecurityException">Throws, if database connection section contains user-related data.</exception>
    public FromConfigurationFile(
        string database,
        string connectionName,
        string login,
        string password
    ) {
        var connectionStringData = FromConfigurationFile
            .configurationFileKeeper
            .Value
            .GetSection($"{database}:{connectionName}");

        this.connectionStringBuilder = connectionStringData.Get<SqlConnectionStringBuilder>();

        if (this.connectionStringBuilder is null)
        {
            throw new JsonException(ErrorMessages.Connection.FILE_WITH_INVALID_JSON);
        }

        if (!string.IsNullOrEmpty(this.connectionStringBuilder.UserID) ||
            !string.IsNullOrEmpty(this.connectionStringBuilder.Password)
        ) {
            throw new SecurityException(ErrorMessages.Connection.FILE_CONTAINS_USER_RELATED_DATA);
        }

        this.connectionStringBuilder.UserID = login;
        this.connectionStringBuilder.Password = password;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="connectionType">Database connection type name.</param>
    /// <param name="login">Database user login value.</param>
    /// <param name="password">Database user password value.</param>
    /// <exception cref="JsonException">Throws, if database connection section contains incorrect JSON or required section(s) are missing.</exception>
    /// <exception cref="SecurityException">Throws, if database connection section contains user-related data.</exception>
    public FromConfigurationFile(
        string connectionType,
        string login,
        string password
    ) : this("Default", connectionType, login, password)
    {
    }

    /// <summary>
    /// Build connection string implementation method.
    /// </summary>
    /// <returns>Connection string value.</returns>
    protected override string buildConnectionString()
    {
        return this.connectionStringBuilder.ToString();
    }
}