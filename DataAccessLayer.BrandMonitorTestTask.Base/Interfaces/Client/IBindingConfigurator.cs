using System.ServiceModel.Channels;

namespace DataAccessLayer.BrandMonitorTestTask.Base.Interfaces.Client;

/// <summary>
/// Binding configuration strategy providing interface.
/// </summary>
/// <typeparam name="TBinding">Binding type of instance, which one must be configured.</typeparam>
public interface IBindingConfigurator<TBinding> where TBinding : Binding, new()
{
    /// <summary>
    /// Create default binding of type <typeparamref name="TBinding" /> providing method.
    /// </summary>
    /// <returns>Default binding instance of type <typeparamref name="TBinding" />.</returns>
    TBinding CreateBinding();

    /// <summary>
    /// Binding of type <typeparamref name="TBinding" /> timeout settings applying method.
    /// </summary>
    /// <returns>Binding instance of type <typeparamref name="TBinding" /> with timeout settings applied.</returns>
    TBinding SetDefaultTimeoutSettings(TBinding binding);

    /// <summary>
    /// Binding of type <typeparamref name="TBinding" /> reader quotas applying method.
    /// </summary>
    /// <returns>Binding instance of type <typeparamref name="TBinding" /> with reader quotas applied.</returns>
    TBinding SetReaderQuotas(TBinding binding);

    /// <summary>
    /// Binding of type <typeparamref name="TBinding" /> security settings applying method.
    /// </summary>
    /// <returns>Binding instance of type <typeparamref name="TBinding" /> with security settings applied.</returns>
    TBinding SetSecurity(TBinding binding);
}