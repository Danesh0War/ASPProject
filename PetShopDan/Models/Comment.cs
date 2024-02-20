using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopDan.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        [StringLength(120, ErrorMessage = "The text cannot exceed 120 characters.")]
        public string? Text { get; set; }

    }
}
