namespace DataAccessLayer.BrandMonitorTestTask.Database.Interfaces;

/// <summary>
/// ORM model builder configuration abstraction/interface.
/// </summary>
/// <typeparam name="TOrmModelBuilder">Native ORM model builder type.</typeparam>
internal interface IOrmModelBuilderConfigurator<in TOrmModelBuilder>
{
    /// <summary>
    /// Build/configure ORM model method.
    /// </summary>
    /// <param name="ormModelBuilder">Native ORM model builder reference value.</param>
    void ConfigureModel(TOrmModelBuilder ormModelBuilder);
}