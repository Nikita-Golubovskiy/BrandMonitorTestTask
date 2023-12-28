using DataAccessLayer.BrandMonitorTestTask.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

// ReSharper disable UnusedMember.Global

namespace DataAccessLayer.BrandMonitorTestTask.Database.Configurations.Contexts;

/// <summary>
/// Composite model builder configurator class.
/// </summary>
internal class CompositeModelBuilderConfigurator : BaseModelBuilderConfigurator
{
    /// <summary>
    /// Atomic configurators collection reference field.
    /// </summary>
    private readonly IOrmModelBuilderConfigurator<ModelBuilder>[] configurators;

    /// <summary>
    /// Build/configure ORM model method.
    /// </summary>
    /// <param name="ormModelBuilder">Native ORM model builder reference value.</param>
    public sealed override void ConfigureModel(ModelBuilder ormModelBuilder)
    {
        foreach (var configurator in this.configurators)
        {
            configurator.ConfigureModel(ormModelBuilder);
        }
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="configurators">Atomic configurators collection reference value.</param>
    public CompositeModelBuilderConfigurator(params IOrmModelBuilderConfigurator<ModelBuilder>[] configurators)
    {
        this.configurators = configurators;
    }
}