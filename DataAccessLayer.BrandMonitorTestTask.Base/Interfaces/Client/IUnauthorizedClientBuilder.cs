namespace DataAccessLayer.BrandMonitorTestTask.Base.Interfaces.Client;

/// <summary>
/// Client of type <typeparamref name="TClient" /> unauthorized building interface.
/// </summary>
/// <typeparam name="TClient">Client type.</typeparam>
public interface IUnauthorizedClientBuilder<out TClient>
{
    /// <summary>
    /// Client instance building method.
    /// </summary>
    /// <param name="serviceUrl">Client/service connection string URL.</param>
    /// <returns>Properly initialized client instance of type <typeparamref name="TClient" />.</returns>
    TClient Build(string serviceUrl);
}