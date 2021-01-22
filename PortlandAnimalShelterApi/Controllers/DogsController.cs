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
  public class DogsController : ControllerBase
  {
    private PortlandAnimalShelterApiContext _db;
    public DogsController(PortlandAnimalShelterApiContext db)
    {
      _db = db;
    }
    
    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Dog>> Get(string breed, string gender)
    {
      var query = _db.Dogs.AsQueryable();

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
    public void Post([FromBody] Dog dog)
    {
      _db.Dogs.Add(dog);
      _db.SaveChanges();
    }
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Dog> Get(int id)
    {
      return _db.Dogs.FirstOrDefault(entry => entry.DogId == id);
    }

    [Authorize(Roles = Role.Admin)]
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Dog dog)
    {
      dog.DogId = id;
      _db.Entry(dog).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [Authorize(Roles = Role.Admin)]
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var dogToDelete = _db.Dogs.FirstOrDefault(entry => entry.DogId == id);
      _db.Dogs.Remove(dogToDelete);
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