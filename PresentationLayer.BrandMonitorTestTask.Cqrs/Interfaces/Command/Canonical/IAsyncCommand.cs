using System.Threading.Tasks;
using PresentationLayer.BrandMonitorTestTask.Cqrs.Interfaces.Command.NonCanonical;

// ReSharper disable UnusedMember.Global

namespace PresentationLayer.BrandMonitorTestTask.Cqrs.Interfaces.Command.Canonical;

/// <summary>
/// Common canonical (void-result-based) asynchronous command interface.
/// </summary>
/// <typeparam name="TRequest">Request data presenting/containing type.</typeparam>
public interface IAsyncCommand<in TRequest> : ICommand<TRequest, Task>
{
}