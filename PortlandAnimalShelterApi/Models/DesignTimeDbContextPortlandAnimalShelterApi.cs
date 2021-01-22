using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PortlandAnimalShelterApi.Models
{
  public class PortlandAnimalShelterApiContextFactory : IDesignTimeDbContextFactory<PortlandAnimalShelterApiContext>
  {

    PortlandAnimalShelterApiContext IDesignTimeDbContextFactory<PortlandAnimalShelterApiContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<PortlandAnimalShelterApiContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new PortlandAnimalShelterApiContext(builder.Options);
    }
  }
}