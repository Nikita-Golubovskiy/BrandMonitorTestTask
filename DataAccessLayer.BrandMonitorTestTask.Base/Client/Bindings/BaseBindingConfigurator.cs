using System;
using DataAccessLayer.BrandMonitorTestTask.Base.Interfaces.Client;

using Channels = System.ServiceModel.Channels;

namespace DataAccessLayer.BrandMonitorTestTask.Base.Client.Bindings;

/// <summary>
/// Base binding configuration strategy providing class.
/// </summary>
/// <typeparam name="TBinding">Binding type of instance, which one must be configured.</typeparam>
public abstract class BaseBindingConfigurator<TBinding> : IBindingConfigurator<TBinding>
    where TBinding : Channels.Binding, new()
{
    /// <summary>
    /// Create default binding of type <typeparamref name="TBinding" /> providing method.
    /// </summary>
    /// <returns>Default binding instance of type <typeparamref name="TBinding" />.</returns>
    public virtual TBinding CreateBinding()
    {
        return new TBinding();
    }

    /// <summary>
    /// Binding of type <typeparamref name="TBinding" /> timeout settings applying method.
    /// </summary>
    /// <returns>Binding instance of type <typeparamref name="TBinding" /> with timeout settings applied.</returns>
    public virtual TBinding SetDefaultTimeoutSettings(TBinding binding)
    {
        binding.CloseTimeout = new TimeSpan(0, 50, 0);
        binding.OpenTimeout = new TimeSpan(0, 50, 0);
        binding.ReceiveTimeout = new TimeSpan(0, 50, 0);
        binding.SendTimeout = new TimeSpan(0, 50, 0);

        return binding;
    }

    /// <summary>
    /// Binding of type <typeparamref name="TBinding" /> reader quotas applying method.
    /// </summary>
    /// <returns>Binding instance of type <typeparamref name="TBinding" /> with reader quotas applied.</returns>
    public virtual TBinding SetReaderQuotas(TBinding binding)
    {
        return binding;
    }

    /// <summary>
    /// Binding of type <typeparamref name="TBinding" /> security settings applying method.
    /// </summary>
    /// <returns>Binding instance of type <typeparamref name="TBinding" /> with security settings applied.</returns>
    public virtual TBinding SetSecurity(TBinding binding)
    {
        return binding;
    }
}