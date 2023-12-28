using System;
using Grpc.Core;

// ReSharper disable UnusedMember.Global

namespace DataAccessLayer.BrandMonitorTestTask.Base.Client.Builders.Unauthorized;

/// <summary>
/// Unauthorized gRPC-based client of type <typeparamref name="TClient" /> builder.
/// </summary>
/// <typeparam name="TClient">Client type.</typeparam>
public class GrpcBuilder<TClient> : BaseBuilder<TClient, Func<Channel, TClient>>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="instanceCreator">Instance of type <typeparamref name="TClient"/> creator delegate.</param>
    public GrpcBuilder(Func<Channel, TClient> instanceCreator) : base(instanceCreator)
    {
    }

    /// <summary>
    /// Client instance building method.
    /// </summary>
    /// <param name="serviceUrl">
    /// Client/service connection string URL.<br />
    /// Attention. URL must NOT use http/https/etc prefixes!
    /// </param>
    /// <returns>Properly initialized client instance of type <typeparamref name="TClient" />.</returns>
    public override TClient Build(string serviceUrl)
    {
        var channel = new Channel(serviceUrl, ChannelCredentials.Insecure);

        return this.instanceCreator.Invoke(channel);
    }
}