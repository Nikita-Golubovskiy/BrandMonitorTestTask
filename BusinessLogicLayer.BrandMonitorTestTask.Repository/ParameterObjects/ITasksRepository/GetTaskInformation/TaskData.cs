using System;

namespace BusinessLogicLayer.BrandMonitorTestTask.Repository.ParameterObjects.ITasksRepository.GetTaskInformation;

/// <summary>
/// <see cref="Interfaces.ITasksRepository.GetTaskInformation">GetTaskInformation</see> response task describing parameter object DTO class.
/// </summary>
public record TaskData(
    Guid ID,
    string State
) {
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
