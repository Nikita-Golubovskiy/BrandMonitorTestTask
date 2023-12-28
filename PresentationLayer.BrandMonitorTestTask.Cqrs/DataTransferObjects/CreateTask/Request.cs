using System;
using System.Runtime.Serialization;

namespace PresentationLayer.BrandMonitorTestTask.Cqrs.DataTransferObjects.CreateTask;

/// <summary>
/// <see cref="Commands.CreateTask.Execute(Request)">CreateTask</see> command request describing DTO class.
/// </summary>
[DataContract]
public sealed class Request
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id">Task ID value.</param>
    public Request(Guid id)
    {
        this.ID = id;
    }

    /// <summary>
    /// Task ID property.
    /// </summary>
    [DataMember]
    public Guid ID { get; }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        // ReSharper disable once UseStringInterpolation
        return string.Format("ID: {0}", this.ID);
    }
}