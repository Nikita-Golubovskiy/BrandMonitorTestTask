// ReSharper disable UnusedMember.Global

namespace PresentationLayer.BrandMonitorTestTask.Cqrs.Interfaces.Query.Parameterless;

/// <summary>
/// Common parameterless query interface.
/// </summary>
/// <typeparam name="TResponse">Response/result data presenting/containing type.</typeparam>
public interface IQuery<out TResponse>
{
    /// <summary>
    /// Query handling/execution method.
    /// </summary>
    /// <returns>Result data describing/containing object value.</returns>
    TResponse Execute();
}