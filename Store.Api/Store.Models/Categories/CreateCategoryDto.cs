using System.ComponentModel.DataAnnotations;
using Store.Models.Base;

namespace Store.Models.Categories
{
    public class CreateCategoryDto : ICreateEntityDto
    {
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}