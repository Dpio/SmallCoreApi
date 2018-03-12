using System.ComponentModel.DataAnnotations;

namespace Store.Models.Base
{
    public class EntityDto : IEntityDto
    {
        [Required]
        public int Id { get; set; }
    }
}