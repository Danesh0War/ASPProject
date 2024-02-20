using PetShopDan.Models;

namespace PetShopDan.Repository
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAnimalsByCategoryId(int categoryId);
        IEnumerable<Animal> GetAllAnimal();
        Animal GetAnimalById(int AnimalId);

        void AddAnimal(Animal animal);

        void UpdateAnimal(Animal animal);
        void DeleteAnimal(int AnimalId);

    }
}
