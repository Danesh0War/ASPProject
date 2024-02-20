using Microsoft.EntityFrameworkCore;
using PetShopDan.Models;

namespace PetShopDan.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Category>? Categories { get; set; }

        public DbSet<Comment>? Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(new
            {
                AnimalId = 1,
                AnimalName = "dog",
                Age = 2,
                PictureName = "licensed-image.jpeg",
                Description = "This is donny the dog he is eight years old and he would be happy to find a new home",
                CategoryId = 1
            },
         new { AnimalId = 2, AnimalName = "Lizard", Age = 4, PictureName = "Inland-Bearded-Dragon-Lizard-1.jpg", Description = "This Liza the Lizard she like to eat flys and sit in the sun ", CategoryId = 2 }, new { AnimalId = 3, AnimalName = "Bird", Age = 12, PictureName = "הורדה.jpeg", Description = "Bili the bird came to the store from the jungle", CategoryId = 3 });

            modelBuilder.Entity<Category>().HasData(new { CategoryId = 1, CategoryName = "Mamal" }
              , new { CategoryId = 2, CategoryName = "Reptiles" }, new { CategoryId = 3, CategoryName = "Birds" });

            modelBuilder.Entity<Comment>().HasData(new { CommentId = 1, AnimalId = 1, Text = "hello do doggy" },
                new { CommentId = 2, AnimalId = 2, Text = "Wow what a Lizard" }, new { CommentId = 3, AnimalId = 3, Text = "What A beutiful bird" }, new { CommentId = 4, AnimalId = 1, Text = "thats a cute dog" });

        }
    }
}
