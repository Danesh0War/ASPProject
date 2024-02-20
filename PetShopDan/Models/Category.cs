namespace PetShopDan.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Animal>? Animals { get; set; } = new List<Animal>();

    }
}
