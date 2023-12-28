// ReSharper disable UnusedMember.Global

namespace PresentationLayer.BrandMonitorTestTask.Cqrs.Interfaces.Command.NonCanonical;

/// <summary>
/// Common non-canonical (non-void-result-based) command interface.
/// </summary>
/// <typeparam name="TRequest">Request data presenting/containing type.</typeparam>
/// <typeparam name="TResponse">Response/result data presenting/containing type.</typeparam>
public interface ICommand<in TRequest, out TResponse>
{
    /// <summary>
    /// Command handling/execution method.
    /// </summary>
    /// <param name="request">Request data describing/containing object reference value.</param>
    /// <returns>Result data describing/containing object value.</returns>
    TResponse Execute(TRequest request);
}