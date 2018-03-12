namespace Store.Models.Base
{
    /// <summary>Defines common properties for entity based DTOs.</summary>
    public interface IEntityDto
    {
        /// <summary>Id of the entity.</summary>
        int Id { get; set; }
    }
}