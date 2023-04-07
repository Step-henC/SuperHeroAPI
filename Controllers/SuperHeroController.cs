using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public SuperHeroController(DataContext dataContext) {
            _dataContext = dataContext;

        }


        [HttpGet]  
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            //to get this to work had to remove System.Data.Entity since .NET will default to it
            return Ok(await _dataContext.SuperHeroes.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateSuperHeroes(SuperHero hero)
        {
            hero.Id = 0; //circumvent identity error from user
            _dataContext.SuperHeroes.Add(hero);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero hero)
        {
            var existingHero = await _dataContext.SuperHeroes.FindAsync(hero.Id);
            if (existingHero == null) 
                return BadRequest("Hero not found"); 
            

            existingHero.Name = hero.Name;
            existingHero.FirstName = hero.FirstName;    
            existingHero.LastName = hero.LastName;  
            existingHero.Place = hero.Place;  
            
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.SuperHeroes.ToListAsync());   
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            var existingHero = await _dataContext.SuperHeroes.FindAsync(id);
            if (existingHero == null)
                return BadRequest("Hero not found");

            _dataContext.SuperHeroes.Remove(existingHero);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.SuperHeroes.ToListAsync());
        }
        
    }
}
