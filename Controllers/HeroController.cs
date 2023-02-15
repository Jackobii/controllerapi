using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperheroAPI.Models;

namespace SuperheroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private static List<Hero> _heroes = new List<Hero>()
        {
            new Hero() { Id = 1, Name = "Tony Stark", Team = "Avengers", SuperheroName = "Iron Man"}, 
            new Hero() {Id = 2, Name = "Bruce Wayne", Team = "Justice League", SuperheroName = "Batman"}
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_heroes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_heroes.FirstOrDefault(h => h.Id == id));
        }

        [HttpPost]
        public IActionResult Post(Hero hero)
        {
            _heroes.Add(hero);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Hero hero)
        {
            var heroToUpdate = _heroes.FirstOrDefault(h => h.Id == hero.Id);
            if (heroToUpdate == null)
            {
                return NotFound();
            }

            heroToUpdate.Name = hero.Name;
            heroToUpdate.Team = hero.Team;
            heroToUpdate.SuperheroName = hero.SuperheroName;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var heroToDelete = _heroes.FirstOrDefault(h => h.Id == id);
            if (heroToDelete == null)
            {
                return NotFound();
            }
            _heroes.Remove(heroToDelete);
            return Ok();
        }
    }
}
