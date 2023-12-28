using System;
using System.Net.Http;

// ReSharper disable UnusedMember.Global

namespace DataAccessLayer.BrandMonitorTestTask.Base.Client.Builders.Unauthorized;

/// <summary>
/// Unauthorized REST-based client of type <typeparamref name="TClient" /> builder.
/// </summary>
/// <typeparam name="TClient">Client type.</typeparam>
public class RestBuilder<TClient> : BaseBuilder<TClient, Func<string, HttpClient, TClient>>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="instanceCreator">Instance of type <typeparamref name="TClient"/> creator delegate.</param>
    public RestBuilder(Func<string, HttpClient, TClient> instanceCreator) : base(instanceCreator)
    {
    }

    /// <summary>
    /// Client instance building method.
    /// </summary>
    /// <param name="serviceUrl">Client/service connection string URL.</param>
    /// <returns>Properly initialized client instance of type <typeparamref name="TClient" />.</returns>
    public override TClient Build(string serviceUrl)
    {
        var httpClient = new HttpClient();

        return this.instanceCreator(serviceUrl, httpClient);
    }
}