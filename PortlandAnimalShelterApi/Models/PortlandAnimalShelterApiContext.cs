using Microsoft.EntityFrameworkCore;

namespace PortlandAnimalShelterApi.Models
{
    public class PortlandAnimalShelterApiContext : DbContext
    {
        public PortlandAnimalShelterApiContext(DbContextOptions<PortlandAnimalShelterApiContext> options)
            : base(options)
        {
        }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Cat>()
            .HasData(
              new Cat { CatId = 1, Name = "Bulma", AdoptFee = 25, Breed = "Short-Hair Domestic", Gender = "Female", Color = "Grey, White", Age = 10, Weight = 11, Personality = "affectionate and social"},
              new Cat { CatId = 2, Name = "Dusty", AdoptFee = 100,Breed = "Short-Hair Domestic", Gender = "Male", Color = "Black with stars", Age = 12, Weight = 8, Personality = "loyal, independent" },
              new Cat { CatId = 3, Name = "Spot" , AdoptFee = 170,Breed = "Short-Hair Domestic", Gender = "Female", Color= "Orange Tabby", Age= 6, Weight= 8, Personality= "cautious of strangers, affectionate" }
            );
          builder.Entity<Dog>()
            .HasData(
              new Dog { DogId = 1, Name = "Ein", AdoptFee = 250, Breed = "Pembroke Corgi", Gender = "Male", Color = "Red", Age = 3, Weight = 27, Personality = "affectionate and social"},
              new Dog { DogId = 2, Name = "Hachiko", AdoptFee = 200,Breed = "Shiba Inu", Gender = "Male", Color = "Red, Tan", Age = 8, Weight = 20, Personality = "loyal, independent" },
              new Dog { DogId = 3, Name = "Balto" , AdoptFee = 170,Breed = "Siberian Husky", Gender = "Male", Color= "Black, White", Age= 7, Weight= 48, Personality= "active, loyal, strong willed" }
            );
        }
    }
}