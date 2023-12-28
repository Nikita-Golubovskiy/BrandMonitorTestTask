// ReSharper disable UnusedMemberInSuper.Global

namespace BusinessLogicLayer.BrandMonitorTestTask.Base.Interfaces;

/// <summary>
/// Common registrar interface for registering some observations/objects of type <typeparamref name="TObservation" />.
/// </summary>
/// <typeparam name="TObservation">Corresponding registrable observation/object type.</typeparam>
public interface IRegistrar<in TObservation>
{
    /// <summary>
    /// Some observation/object of type <typeparamref name="TObservation" /> registration method.
    /// </summary>
    /// <param name="observation">Observation/object need to be registered.</param>
    void Register(TObservation observation);
}