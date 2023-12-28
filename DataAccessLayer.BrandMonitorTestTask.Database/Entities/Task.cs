using System;

namespace DataAccessLayer.BrandMonitorTestTask.Database.Entities;

/// <summary>
/// Task POCO entity for EF Core ORM.
/// </summary>
public sealed class Task
{
    /// <summary>
    /// Task ID property.
    /// </summary>
    public Guid? ID { get; set; }

    /// <summary>
    /// Task state property.
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// Current date time property.
    /// </summary>
    public DateTime CurrentDateTime { get; set; }
}