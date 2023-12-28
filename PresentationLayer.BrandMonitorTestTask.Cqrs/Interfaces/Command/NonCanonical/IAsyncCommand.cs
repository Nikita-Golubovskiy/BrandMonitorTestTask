using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace PresentationLayer.BrandMonitorTestTask.Cqrs.Interfaces.Command.NonCanonical;

/// <summary>
/// Common non-canonical (non-void-result-based) command interface.
/// </summary>
/// <typeparam name="TRequest">Request data presenting/containing type.</typeparam>
/// <typeparam name="TResponse">Response/result data presenting/containing type.</typeparam>
public interface IAsyncCommand<in TRequest, TResponse> : ICommand<TRequest, Task<TResponse>>
{
}