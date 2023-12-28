using DataAccessLayer.BrandMonitorTestTask.Base.Interfaces.Client;

namespace DataAccessLayer.BrandMonitorTestTask.Base.Client.Builders.Unauthorized;

/// <summary>
/// Unauthorized client of type <typeparamref name="TClient" /> base builder.
/// </summary>
/// <typeparam name="TClient">Client type.</typeparam>
/// <typeparam name="TInstanceCreator">Instance creator delegate type.</typeparam>
public abstract class BaseBuilder<TClient, TInstanceCreator> : IUnauthorizedClientBuilder<TClient>
{
    /// <summary>
    /// Instance of type <typeparamref name="TClient" /> creator delegate reference field.
    /// </summary>
    protected readonly TInstanceCreator instanceCreator;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="instanceCreator">Instance of type <typeparamref name="TClient"/> creator delegate.</param>
    protected BaseBuilder(TInstanceCreator instanceCreator)
    {
        this.instanceCreator = instanceCreator;
    }

    /// <summary>
    /// Client instance building method.
    /// </summary>
    /// <param name="serviceUrl">Client/service connection string URL.</param>
    /// <returns>Properly initialized client instance of type <typeparamref name="TClient" />.</returns>
    public abstract TClient Build(string serviceUrl);
}