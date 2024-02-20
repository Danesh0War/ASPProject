using PetShopDan.Data;
using PetShopDan.Models;

namespace PetShopDan.Repository
{
    public class AnimalRepository : IAnimalRepository
    {

        private DataContext _context;

        public AnimalRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Animal> GetAllAnimal()
        {
            return _context.Animals!.ToList();
        }
        public IEnumerable<Animal> GetAnimalsByCategoryId(int categoryId)
        {
            return _context.Animals!.Where(a => a.CategoryId == categoryId).ToList();
        }
        public Animal GetAnimalById(int AnimalId)
        {
            return (_context.Animals!.Single(a => a.AnimalId == AnimalId));
        }
        public void AddAnimal(Animal animal)
        {
            _context.Animals!.Add(animal);
            _context.SaveChanges();
        }
        public void DeleteAnimal(int AnimalId)
        {
            var AnimalInDb = GetAnimalById(AnimalId);
            _context.Animals?.Remove(AnimalInDb);
            _context.SaveChanges();
        }
        public void UpdateAnimal(Animal animal)
        {
            var AnimalInDb = GetAnimalById(animal.AnimalId);
            AnimalInDb.AnimalName = animal.AnimalName;
            AnimalInDb.Age = animal.Age;
            AnimalInDb.PictureName = animal.PictureName;
            AnimalInDb.Description = animal.Description;
            AnimalInDb.CategoryId = animal.CategoryId;
            _context.SaveChanges();
        }
    }
}
