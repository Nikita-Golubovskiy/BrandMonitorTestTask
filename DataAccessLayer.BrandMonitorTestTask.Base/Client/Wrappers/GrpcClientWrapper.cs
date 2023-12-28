using Grpc.Core;

// ReSharper disable UnusedMember.Global

namespace DataAccessLayer.BrandMonitorTestTask.Base.Client.Wrappers;

/// <summary>
/// gRPC service client wrapping class.
/// </summary>
/// <typeparam name="TClient">Client type.</typeparam>
public class GrpcClientWrapper<TClient>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="client">Client reference value.</param>
    /// <param name="channel">Corresponding client channel reference value.</param>
    public GrpcClientWrapper(TClient client, Channel channel)
    {
        this.Client = client;
        this.Channel = channel;
    }

    /// <summary>
    /// gRPC client of type <see cref="TClient" /> reference property.
    /// </summary>
    public TClient Client { get; }

    /// <summary>
    /// Corresponding channel, used for wrapped gRPC client of type <typeparamref name="TClient" /> property.
    /// </summary>
    public Channel Channel { get; }
}