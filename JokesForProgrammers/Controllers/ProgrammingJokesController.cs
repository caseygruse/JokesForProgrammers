using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokesForProgrammers.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JokesForProgrammers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingJokesController : ControllerBase
    {
        //only constructor can modify a readonly field
        private readonly JokeDBContext _db;

        public ProgrammingJokesController(JokeDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetJokes()
        {
            //method syntax for linq
            List<Joke> jokes = await JokeDb.GetAllJokes(_db);
            //linq syntax  (query)
            ////List<Joke> jokes2 = (from j in _db.Jokes select j).ToList();
            return Ok(jokes);
        }

        [HttpGet("category/{category}")]
        public IActionResult GetJokesByCategory([FromRoute]string category)
        {
            List<Joke> jokes = JokeDb.GetAllJokesByCategory(_db, category);
            return Ok(jokes);
        }

        [HttpPost]
        public IActionResult PostJoke([FromBody]Joke j)
        {
            if (ModelState.IsValid)
            {
                JokeDb.AddJoke(_db, j);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExistingJoke([FromRoute] int id)
        {
            if (JokeDb.DoesExist(id))
            {
                JokeDb.DeleteJoke(_db, id);
                return Ok();
            }

            return NotFound();
            

        }

       
    }
}