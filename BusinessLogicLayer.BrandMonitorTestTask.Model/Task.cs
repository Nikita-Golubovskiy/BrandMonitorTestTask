using System;
using BusinessLogicLayer.BrandMonitorTestTask.Model.Exceptions;
using BusinessLogicLayer.BrandMonitorTestTask.Model.Interfaces;

using DomainErrors = BusinessLogicLayer.BrandMonitorTestTask.Model.Assets.Strings.Errors.Domain;

namespace BusinessLogicLayer.BrandMonitorTestTask.Model;

/// <summary>
/// Task model class.
/// </summary>
public sealed class Task : IAggregationRoot
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id">Task ID value.</param>
    /// <param name="state">Task state value.</param>
    /// <param name="currentDateTime">Current date time value.</param>
    public Task(
        Guid id,
        string state,
        DateTime currentDateTime
    ) {
        this.ID = id;
        this.State = state;
        this.CurrentDateTime = currentDateTime;

        if (string.IsNullOrEmpty(state))
        {
            throw new DomainModelException(DomainErrors.TASK_STATE_IS_MISSING);
        }
    }


    /// <summary>
    /// Task ID property.
    /// </summary>
    public Guid ID { get; }

    /// <summary>
    /// Task state property.
    /// </summary>
    public string State { get; private set; }

    /// <summary>
    /// Current date time property.
    /// </summary>
    public DateTime CurrentDateTime { get; private set; }

    /// <summary>
    /// Task state updating method.
    /// </summary>
    /// <param name="state">Task state value.</param>
    public void UpdateState(string state)
    {
        this.State = state;

        if (string.IsNullOrEmpty(state))
        {
            throw new DomainModelException(DomainErrors.TASK_STATE_IS_MISSING);
        }
    }

    /// <summary>
    /// Current date time updating method.
    /// </summary>
    public void UpdateCurrentDateTime()
    {
        this.CurrentDateTime = DateTime.Now;
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        // ReSharper disable once UseStringInterpolation
        return string.Format(
            "ID: {0}, State: {1}, CurrentDateTime: {2}",
            this.ID,
            this.State,
            this.CurrentDateTime
        );
    }
}