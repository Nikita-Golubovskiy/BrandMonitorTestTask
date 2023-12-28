using SharedLayer.BrandMonitorTestTask.Interfaces;

using EntityObject = DataAccessLayer.BrandMonitorTestTask.Database.Entities.Task;
using ModelObject = BusinessLogicLayer.BrandMonitorTestTask.Model.Task;

namespace DataAccessLayer.BrandMonitorTestTask.Repository.Converters.Tasks.LoadTask;

/// <summary>
/// <see cref="EntityObject">EntityObject</see> repository parameter objects to <see cref="ModelObject">ModelObject</see> object converter.
/// </summary>
internal sealed class Converter : IDirectConverter<EntityObject, ModelObject>
{
    /// <summary>
    /// Value conversion method.
    /// </summary>
    /// <param name="source">Source value to convert.</param>
    /// <returns>Result/converted value.</returns>
    public ModelObject Convert(EntityObject source)
    {
        if (source is null)
        {
            return null;
        }
        var result = new ModelObject(
            // ReSharper disable once PossibleInvalidOperationException
            source.ID.Value,
            source.State,
            source.CurrentDateTime
        );

        return result;
    }
}