using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortlandAnimalShelterApi.Entities;
using PortlandAnimalShelterApi.Helpers;
using PortlandAnimalShelterApi.Models;

namespace PortlandAnimalShelterApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CatsController : ControllerBase
  {
    private PortlandAnimalShelterApiContext _db;
    public CatsController(PortlandAnimalShelterApiContext db)
    {
      _db = db;
    }

    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Cat>> Get(string breed, string gender)
    {
      var query = _db.Cats.AsQueryable();

      if (breed != null)
      {
        query = query.Where(entry => entry.Breed == breed);
      }
      if (gender != null)
      {
        query = query.Where(entry => entry.Gender == gender);
      }
      return query.ToList();
    }
    [Authorize(Roles = Role.Admin)]
    [HttpPost]
    public void Post([FromBody] Cat cat)
    {
      _db.Cats.Add(cat);
      _db.SaveChanges();
    }
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Cat> Get(int id)
    {
      return _db.Cats.FirstOrDefault(entry => entry.CatId == id);
    }

    [Authorize(Roles = Role.Admin)]
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Cat cat)
    {
      cat.CatId = id;
      _db.Entry(cat).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [Authorize(Roles = Role.Admin)]
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var catToDelete = _db.Cats.FirstOrDefault(entry => entry.CatId == id);
      _db.Cats.Remove(catToDelete);
      _db.SaveChanges();
    }
    [Authorize]
    [HttpGet]
    [Route("random")]
    public ActionResult <Dog> Random()
    {
      Random random = new Random();
      int randomDog = random.Next(_db.Dogs.ToList().Count());
      return _db.Dogs.FirstOrDefault(entry => entry.DogId == randomDog);
    }
  }
}