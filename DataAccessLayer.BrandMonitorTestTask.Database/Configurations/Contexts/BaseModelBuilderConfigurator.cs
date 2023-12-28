using DataAccessLayer.BrandMonitorTestTask.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.BrandMonitorTestTask.Database.Configurations.Contexts;

/// <summary>
/// Base implementation of <see cref="IOrmModelBuilderConfigurator{OrmModelBuilder}">IOrmModelBuilderConfigurator</see>
/// for EF Core <see cref="ModelBuilder">ModelBuilder</see>.
/// </summary>
internal abstract class BaseModelBuilderConfigurator : IOrmModelBuilderConfigurator<ModelBuilder>
{
    /// <summary>
    /// Build/configure ORM model method.
    /// </summary>
    /// <param name="ormModelBuilder">Native ORM model builder reference value.</param>
    public abstract void ConfigureModel(ModelBuilder ormModelBuilder);
}