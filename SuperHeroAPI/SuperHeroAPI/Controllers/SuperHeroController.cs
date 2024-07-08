using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heros = new List<SuperHero>
        {

                new SuperHero{Id=1,Name="SpiderMan",FirstName="Spider",LastName="Man",Place="UKUS"},


                new SuperHero{Id=2,Name="SuperMan",FirstName="Superr",LastName="Man",Place="Maldive"}
         };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heros.Find(h=>h.Id==id);
            if (hero == null)
                return BadRequest("Hero Not Found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heros.Add(hero);
            return Ok(heros);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = heros.Find(h => h.Id == request.Id);
            if (hero == null)
                return BadRequest("Hero Not Found");
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(heros);


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> Deletehero(int id)
        {
            var hero = heros.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("No Hero details are present with the Entered ID");
            heros.Remove(hero);
            return Ok(heros);
        }
    }
}
