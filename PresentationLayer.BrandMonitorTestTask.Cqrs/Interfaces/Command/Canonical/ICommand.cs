// ReSharper disable UnusedMember.Global

namespace PresentationLayer.BrandMonitorTestTask.Cqrs.Interfaces.Command.Canonical;

/// <summary>
/// Common canonical (void-result-based) command interface.
/// </summary>
/// <typeparam name="TRequest">Request data presenting/containing type.</typeparam>
public interface ICommand<in TRequest>
{
    /// <summary>
    /// Command handling/execution method.
    /// </summary>
    /// <param name="request">Request data describing/containing object reference value.</param>
    void Execute(TRequest request);
}