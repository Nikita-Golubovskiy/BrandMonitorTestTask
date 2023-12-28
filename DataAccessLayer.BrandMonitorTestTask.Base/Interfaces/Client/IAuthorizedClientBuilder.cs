// ReSharper disable UnusedMember.Global

namespace DataAccessLayer.BrandMonitorTestTask.Base.Interfaces.Client;

/// <summary>
/// Client of type <typeparamref name="TClient" /> authorized building interface.
/// </summary>
/// <typeparam name="TClient">Client type.</typeparam>
public interface IAuthorizedClientBuilder<out TClient>
{
    /// <summary>
    /// Client instance building method.
    /// </summary>
    /// <param name="serviceUrl">Client/service connection string URL.</param>
    /// <param name="login">Login value.</param>
    /// <param name="password">Password value.</param>
    /// <returns>Properly initialized client instance of type <typeparamref name="TClient" />.</returns>
    TClient Build(string serviceUrl, string login, string password);
}