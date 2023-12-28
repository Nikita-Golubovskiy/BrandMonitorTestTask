namespace SharedLayer.BrandMonitorTestTask.Interfaces;

/// <summary>
/// Simple double-direct conversion of some <typeparamref name="TSource" /> value to <typeparamref name="TTarget" /> one interface.
/// </summary>
/// <typeparam name="TSource">Source value type.</typeparam>
/// <typeparam name="TTarget">Target value type.</typeparam>
public interface IConverter<TSource, TTarget>
{
    /// <summary>
    /// Value conversion method.
    /// </summary>
    /// <param name="source">Source value to convert.</param>
    /// <returns>Result/converted value.</returns>
    TTarget Convert(TSource source);

    /// <summary>
    /// Value reverse-conversion method.
    /// </summary>
    /// <param name="source">Source value to reverse-convert.</param>
    /// <returns>Result/reverse-converted value.</returns>
    TSource ConvertBack(TTarget source);
}