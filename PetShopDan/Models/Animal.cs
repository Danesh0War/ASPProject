using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopDan.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        [Required(ErrorMessage = "The Name field is required")]
        [StringLength(30)]
        public string? AnimalName { get; set; }
        [Required]
        [Range(0, 120, ErrorMessage = "Please enter a valid age between 0 and 120.")]
        public int Age { get; set; }
        [Required]

        public string? PictureName { get; set; }
        [Required]
        [StringLength(120, ErrorMessage = "The text cannot exceed 120 characters.")]
        public string? Description { get; set; }
        [ForeignKey("Category")]
        [Required]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }

    }
}
