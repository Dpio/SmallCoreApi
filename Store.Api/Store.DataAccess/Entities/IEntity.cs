namespace Store.DataAccess.Entities
{
    /// <summary>
    /// Defines interface for base entity type. All entities in the system must implement this interface.
    /// </summary>
    public interface IEntity
    {
        /// <summary>Unique identifier for this entity.</summary>
        int Id { get; set; }
    }
}