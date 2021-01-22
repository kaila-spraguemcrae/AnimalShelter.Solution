using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public ActionResult<IEnumerable<Cat>> GetAction()
    {
      return _db.Cats.ToList();
    }

    [HttpPost]
    public void Post([FromBody] Cat cat)
    {
      _db.Cats.Add(cat);
      _db.SaveChanges();
    }

    [HttpGet("{id}")]
    public ActionResult<Cat> GetAction(int id)
    {
      return _db.Cats.FirstOrDefault(entry => entry.CatId == id);
    }
  }
}