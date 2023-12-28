namespace PresentationLayer.BrandMonitorTestTask.Cqrs.Interfaces.Query.Parametric;

/// <summary>
/// Common parametric query interface.
/// </summary>
/// <typeparam name="TRequest">Request data presenting/containing type.</typeparam>
/// <typeparam name="TResponse">Response/result data presenting/containing type.</typeparam>
public interface IQuery<in TRequest, out TResponse>
{
    /// <summary>
    /// Query handling/execution method.
    /// </summary>
    /// <param name="request">Request data describing/containing object reference value.</param>
    /// <returns>Result data describing/containing object value.</returns>
    TResponse Execute(TRequest request);
}