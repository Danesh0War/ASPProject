using PetShopDan.Data;
using PetShopDan.Models;

namespace PetShopDan.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories!.ToList();
        }



        public Category? GetCategoryById(int CategoryId)
        {
            var category = _context.Categories!.SingleOrDefault(a => a.CategoryId == CategoryId);
            return (category);
        }

        public void AddCategory(Category catrgory)
        {
            _context.Categories!.Add(catrgory);
            _context.SaveChanges();
        }

        public void DeleteCategory(int CategoryId)
        {
            var CategoryInDb = GetCategoryById(CategoryId);
            _context.Categories?.Remove(CategoryInDb!);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            var CategoryInDb = GetCategoryById(category.CategoryId);

        }
    }
}
