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
    }
}
