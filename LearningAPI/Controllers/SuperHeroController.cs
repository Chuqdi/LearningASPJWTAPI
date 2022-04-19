using LearningAPI.Data;
using LearningAPI.Models;
using LearningAPI.Services;
using LearningAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly Services.SuperHero superHeroServices;
        private readonly JwtTokenManager jwtTokenManger;
        public SuperHeroController(AppDbContext db, IConfiguration configuration)
        {
            superHeroServices = new Services.SuperHero(db);
            jwtTokenManger = new JwtTokenManager(configuration);
        }

        [HttpGet("generateToken")]
        public String GetAuthToken()
        {
            return jwtTokenManger.GenerateJwtToken("Morgan",new List<String> {"User", "Admin"});
        }

        [Authorize( Roles ="User")]
        [HttpGet]
        public ActionResult<List<Models.SuperHero>> Get()
        {
            return superHeroServices.getAll();
        }

        [HttpGet("{Id}")]
        public Models.SuperHero GetSingleHero(int Id)
        {
            return superHeroServices.getSingle(Id);
        }

        [HttpPost]
        public Models.SuperHero Post([FromBody] Models.SuperHero superHero)
        {
            return superHeroServices.create(superHero);
        }


        [HttpPut("{Id}")]
        public Models.SuperHero Patch([FromBody] Models.SuperHero superHero, int Id)
        {
            return superHeroServices.update(Id, superHero);
        }

        [HttpDelete("{Id}")]
        public Models.SuperHero Delete(int Id)
        {
            return superHeroServices.delete(Id);
        }
    }
}
