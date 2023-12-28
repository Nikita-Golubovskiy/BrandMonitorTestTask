using System;
using System.ServiceModel;
using DataAccessLayer.BrandMonitorTestTask.Base.Interfaces.Client;

using Channels = System.ServiceModel.Channels;

// ReSharper disable UnusedMember.Global

namespace DataAccessLayer.BrandMonitorTestTask.Base.Client.Builders.Unauthorized;

/// <summary>
/// Unauthorized WCF-based client of type <typeparamref name="TClient" /> builder.
/// </summary>
/// <typeparam name="TClient">Client type.</typeparam>
/// <typeparam name="TBinding">Binding type.</typeparam>
public class WcfBuilder<TClient, TBinding> : BaseBuilder<TClient, Func<TBinding, EndpointAddress, TClient>>
    where TBinding : Channels.Binding, new()
{
    /// <summary>
    /// Binding configurator reference field.
    /// </summary>
    private readonly IBindingConfigurator<TBinding> bindingConfigurator;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="instanceCreator">Instance of type <typeparamref name="TClient"/> creator delegate.</param>
    /// <param name="bindingConfigurator">Binding configurator reference value.</param>
    public WcfBuilder(
        Func<TBinding, EndpointAddress, TClient> instanceCreator,
        IBindingConfigurator<TBinding> bindingConfigurator
    ) : base(instanceCreator)
    {
        this.bindingConfigurator = bindingConfigurator;
    }

    /// <summary>
    /// Client instance building method.
    /// </summary>
    /// <param name="serviceUrl">Client/service connection string URL.</param>
    /// <returns>Properly initialized client instance of type <typeparamref name="TClient" />.</returns>
    public override TClient Build(string serviceUrl)
    {
        var binding = this.bindingConfigurator.CreateBinding();

        binding = this.bindingConfigurator.SetReaderQuotas(binding);
        binding = this.bindingConfigurator.SetDefaultTimeoutSettings(binding);
        binding = this.bindingConfigurator.SetSecurity(binding);

        return this.instanceCreator.Invoke(binding, new EndpointAddress(serviceUrl));
    }
}