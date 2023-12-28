using System.Runtime.Serialization;

namespace PresentationLayer.BrandMonitorTestTask.Cqrs.DataTransferObjects.GetTaskInformation;

/// <summary>
/// <see cref="Queries.GetTaskInformation.Execute(Request)">GetTaskInformation</see> command response describing DTO class.
/// </summary>
[DataContract]
public sealed class Response
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id">Task ID value.</param>
    /// <param name="state">Task state value.</param>
    /// <param name="taskIsExists">Task is exists flag value.</param>
    public Response(
        string id,
        string state,
        bool taskIsExists
    ) {
        this.ID = id;
        this.State = state;
        this.TaskIsExists = taskIsExists;
    }

    /// <summary>
    /// Task ID property.
    /// </summary>
    [DataMember]
    public string ID { get; }

    /// <summary>
    /// Task ID property.
    /// </summary>
    [DataMember]
    public string State { get; }

    /// <summary>
    /// Task is exists flag property.
    /// </summary>
    public bool TaskIsExists { get; }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        // ReSharper disable once UseStringInterpolation
        return string.Format(
            "ID: {0}, State: {1}, TaskIsExists: {2}",
            this.ID,
            this.State,
            this.TaskIsExists
        );
    }
}