using PetShopDan.Models;

namespace PetShopDan.Repository
{
    public interface ICategoryRepository
    {

        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int CategoryId);

        void AddCategory(Category catrgory);

        void UpdateCategory(Category category);
        void DeleteCategory(int CategoryId);
    }
}
