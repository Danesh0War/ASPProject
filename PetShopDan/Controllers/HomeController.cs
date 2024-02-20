using Microsoft.AspNetCore.Mvc;
using PetShopDan.Models;
using PetShopDan.Repository;

namespace PetShopDan.Controllers
{
    public class HomeController : Controller
    {
        IAnimalRepository animalRepository;
        ICategoryRepository categoryRepository;
        ICommentRepository commentRepository;
        IWebHostEnvironment webHostEnvironment;
        public HomeController(ICategoryRepository categoryRepository, ICommentRepository commentRepository, IAnimalRepository animalRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.categoryRepository = categoryRepository;
            this.commentRepository = commentRepository;
            this.animalRepository = animalRepository;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var animals = animalRepository.GetAllAnimal();
            var categories = categoryRepository.GetAllCategories();
            var comments = commentRepository.GetAllComments();

            // Sort animals based on the number of comments in descending order
            var sortedAnimals = animals.OrderByDescending(a => a.Comments?.Count ?? 0).Take(2).ToList();//action- dependency injection

            return View(sortedAnimals);
        }

        public IActionResult Catalog(int CategoryId = 0)
        {
            var categories = categoryRepository.GetAllCategories();
            var animals = animalRepository.GetAllAnimal();

            if (CategoryId != 0 && categories != null)
            {
                animals = animals.Where(a => a.CategoryId == CategoryId);

            }
            ViewBag.Animals = animals;
            return View(categories);
        }

        public IActionResult AnimalPage(int AnimalId)
        {
            var animals = animalRepository.GetAllAnimal();
            var animal = animals.Where(a => a.AnimalId == AnimalId).FirstOrDefault();
            return View(animal);
        }

        public IActionResult AddComment(int AnimalId, string newcomment)
        {

            var animals = animalRepository.GetAllAnimal();
            var animal = animals.Where(a => a.AnimalId == AnimalId).FirstOrDefault();
            if (newcomment.Length > 120)
            {
                ModelState.AddModelError("erorr", "Lenth Too Long");
                ViewBag.Error = "LENGTH TOO LONG";
                return View("AnimalPage", animal);

            }
            var comment = new Comment { AnimalId = AnimalId, Text = newcomment };
            commentRepository.AddComment(comment);
            return RedirectToAction("AnimalPage", new { AnimalId });

        }

        public IActionResult Admin(int CategoryId = 0)
        {
            var categories = categoryRepository.GetAllCategories();
            var animals = animalRepository.GetAllAnimal();

            if (CategoryId != 0 && categories != null)
            {
                animals = animals.Where(a => a.CategoryId == CategoryId);

            }
            ViewBag.Animals = animals;
            return View(categories);
        }
        public IActionResult AddAnimal()
        {
            var categories = categoryRepository.GetAllCategories();
            ViewBag.categories = categories;
            return View();
        }
        [HttpPost]

        public IActionResult AddAnimal(string AnimalName, int Age, IFormFile picture, string Description, int CategoryId)
        {
            if (Age > 120 || Age < 0)
            {
                ViewBag.Error = "age not in range";
                var categories = categoryRepository.GetAllCategories();
                ViewBag.categories = categories;
                return View();
            }
            var filename = Guid.NewGuid().ToString() + picture.FileName;
            var filepath = Path.Combine(webHostEnvironment.WebRootPath, "Images", filename);
            using (var fileStream = new FileStream(filepath, FileMode.Create))
            {
                picture.CopyTo(fileStream);
            }
            Animal animal = new Animal { AnimalName = AnimalName, Age = Age, PictureName = filename, Description = Description, CategoryId = CategoryId };
            animalRepository.AddAnimal(animal);
            return RedirectToAction("Admin");
        }
        public IActionResult Delete(int AnimalId)
        {
            animalRepository.DeleteAnimal(AnimalId);
            return RedirectToAction("Admin");
        }
        public IActionResult Edit(int AnimalId)
        {
            var categories = categoryRepository.GetAllCategories();
            ViewBag.categories = categories;

            var animal = animalRepository.GetAnimalById(AnimalId);
            return View(animal);
        }
        [HttpPost]
        public IActionResult Edit(int AnimalId, string AnimalName, int Age, IFormFile picture, string Description, int CategoryId)
        {


            var animal = animalRepository.GetAnimalById(AnimalId);
            if (Age > 120 || Age < 0)
            {
                ViewBag.Error = "age not in range";
                var categories = categoryRepository.GetAllCategories();
                ViewBag.categories = categories;
                return View(animal);
            }
            if (picture != null)
            {
                var filename = Guid.NewGuid().ToString() + picture.FileName;
                var filepath = Path.Combine(webHostEnvironment.WebRootPath, "Images", filename);
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    picture.CopyTo(fileStream);
                }
                animal.PictureName = filename;
            }
            animal.AnimalName = AnimalName;
            animal.Age = Age;
            animal.Description = Description;
            animal.CategoryId = CategoryId;
            animalRepository.UpdateAnimal(animal);
            return RedirectToAction("Admin");
        }
    }
}
