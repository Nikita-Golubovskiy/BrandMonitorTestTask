using System.Threading.Tasks;

namespace PresentationLayer.BrandMonitorTestTask.Cqrs.Interfaces.Query.Parametric;

/// <summary>
/// Common parametric query interface.
/// </summary>
/// <typeparam name="TRequest">Request data presenting/containing type.</typeparam>
/// <typeparam name="TResponse">Response/result data presenting/containing type.</typeparam>
public interface IAsyncQuery<in TRequest, TResponse> : IQuery<TRequest, Task<TResponse>>
{
}