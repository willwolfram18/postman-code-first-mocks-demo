using DownstreamApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DownstreamApi.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController : ControllerBase
    {
        private static readonly IReadOnlyCollection<Actor> ActorsDb = new Actor[]
        {
            new()
            {
                Id = 1001,
                Name = "Mark Hamill"
            },
            new()
            {
                Id = 1002,
                Name = "Carrie Fisher"
            },
            new()
            {
                Id = 1003,
                Name = "Harrison Ford"
            },
            new()
            {
                Id = 1004,
                Name = "Ewan McGregor"
            },
            new()
            {
                Id = 1005,
                Name = "Liam Neeson"
            },
            new()
            {
                Id = 1006,
                Name = "Hayden Christensen"
            },
            new()
            {
                Id = 1007,
                Name = "Natalie Portman"
            },
            new()
            {
                Id = 1008,
                Name = "Ian McDiarmid"
            }
        };

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Actor>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public ActionResult<IEnumerable<Actor>> GetActors([FromQuery] IEnumerable<int>? ids = null)
        {
            ids ??= new List<int>();
            if (!ids.Any())
            {
                return Ok(ActorsDb);
            }

            var matchingActors = ActorsDb.Where(a => ids.Contains(a.Id));

            return Ok(matchingActors);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Actor), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public ActionResult<Actor?> GetActor(int id)
        {
            Actor? actor = ActorsDb.FirstOrDefault(a => a.Id == id);

            if (actor == null)
            {
                return NotFound();
            }

            return Ok(actor);
        }
    }
}
