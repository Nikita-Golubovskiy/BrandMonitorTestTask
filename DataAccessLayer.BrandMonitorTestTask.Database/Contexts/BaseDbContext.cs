using DataAccessLayer.BrandMonitorTestTask.Base.Interfaces.Connection;
using DataAccessLayer.BrandMonitorTestTask.Database.Connection;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.BrandMonitorTestTask.Database.Contexts;

/// <summary>
/// Base EF Core database context class.
/// </summary>
/// <typeparam name="TChildDbContext">Child EF Core database context type.</typeparam>
public class BaseDbContext<TChildDbContext> : DbContext where TChildDbContext : BaseDbContext<TChildDbContext>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public BaseDbContext()
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="options">Database context configuration options reference value.</param>
    public BaseDbContext(DbContextOptions<TChildDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Override this method to configure the database (and other options) to be used
    /// for this context. This method is called for each instance of the context that
    /// is created. The base implementation does nothing.
    /// In situations where an instance of <see cref="DbContextOptions">DbContextOptions</see>
    /// may or may not have been passed to the constructor, you can use <see cref="DbContextOptionsBuilder.IsConfigured">DbContextOptionsBuilder.IsConfigured</see>
    /// to determine if the options have already been set, and skip some or all of the
    /// logic in <see cref="OnConfiguring(DbContextOptionsBuilder)">OnConfiguring</see>.
    /// </summary>
    /// <param name="optionsBuilder">
    /// A builder used to create or modify options for this context. Databases (and other
    /// extensions) typically define extension methods on this object that allow you
    /// to configure the context.
    /// </param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionStringBuilderFactory = (IConnectionStringBuilderFactory) new ConnectionStringBuilderFactory();

        var connectionStringBuilder = connectionStringBuilderFactory
            .CreateConnectionStringBuilder("Default");

        var connectionString = connectionStringBuilder.BuildConnectionString();

        optionsBuilder.UseSqlServer(connectionString);
    }
}