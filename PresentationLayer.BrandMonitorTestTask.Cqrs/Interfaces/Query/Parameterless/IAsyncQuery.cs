using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace PresentationLayer.BrandMonitorTestTask.Cqrs.Interfaces.Query.Parameterless;

/// <summary>
/// Common parameterless asynchronous query interface.
/// </summary>
/// <typeparam name="TResponse">Response/result data presenting/containing type.</typeparam>
public interface IAsyncQuery<TResponse> : IQuery<Task<TResponse>>
{
}