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
    }
}