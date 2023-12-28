using System;
using System.Runtime.Serialization;

namespace PresentationLayer.BrandMonitorTestTask.Cqrs.DataTransferObjects.UpdateState;

/// <summary>
/// <see cref="Commands.UpdateState.Execute(Request)">UpdateState</see> command request describing DTO class.
/// </summary>
[DataContract]
public sealed class Request
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id">Task ID value.</param>
    /// <param name="state">Task state value.</param>
    public Request(
        Guid id,
        string state
    ) {
        this.ID = id;
        this.State = state;
    }

    /// <summary>
    /// Task ID property.
    /// </summary>
    [DataMember]
    public Guid ID { get; }

    /// <summary>
    /// Task state property.
    /// </summary>
    [DataMember]
    public string State { get; }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        // ReSharper disable once UseStringInterpolation
        return string.Format(
            "ID: {0}, State: {1}",
            this.ID,
            this.State
        );
    }
}