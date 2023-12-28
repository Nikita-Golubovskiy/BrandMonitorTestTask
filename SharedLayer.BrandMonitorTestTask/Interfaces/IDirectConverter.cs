// ReSharper disable UnusedMemberInSuper.Global

namespace SharedLayer.BrandMonitorTestTask.Interfaces;

/// <summary>
/// Simple one-direct conversion of some <typeparamref name="TSource" /> value to <typeparamref name="TTarget" /> one interface.
/// </summary>
/// <typeparam name="TSource">Source value type.</typeparam>
/// <typeparam name="TTarget">Target value type.</typeparam>
public interface IDirectConverter<in TSource, out TTarget>
{
    /// <summary>
    /// Value conversion method.
    /// </summary>
    /// <param name="source">Source value to convert.</param>
    /// <returns>Result/converted value.</returns>
    TTarget Convert(TSource source);
}