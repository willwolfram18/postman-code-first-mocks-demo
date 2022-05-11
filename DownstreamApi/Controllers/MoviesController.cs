using DownstreamApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DownstreamApi.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private static readonly IReadOnlyCollection<Movie> MoviesDb = new Movie[]
        {
            new ()
            {
                Id = 101,
                Title = "Star Wars: Episode I - The Phantom Menace",
                Description = "Two Jedi escape a hostile blockade to find allies and come across a young boy who " +
                              "may bring balance to the Force, but the long dormant Sith resurface to claim their " +
                              "original glory.",
                Rating = 3.25f,
                Actors = new []
                {
                    1004,
                    1005,
                    1006,
                    1007,
                    1008
                }
            },
            new()
            {
                Id = 102,
                Title = "Star Wars: Episode II - Attack of the Clones",
                Description = "Ten years after initially meeting, Anakin Skywalker shares a forbidden romance with " +
                              "Padmé Amidala, while Obi-Wan Kenobi investigates an assassination attempt on the " +
                              "senator and discovers a secret clone army crafted for the Jedi.",
                Rating = 3.3f,
                Actors = new []
                {
                    1004,
                    1006,
                    1007,
                    1008
                }
            },
            new ()
            {
                Id = 103,
                Title = "Star Wars: Episode III - Revenge of the Sith",
                Description = "Three years into the Clone Wars, the Jedi rescue Palpatine from Count Dooku. As Obi-Wan " +
                              "pursues a new threat, Anakin acts as a double agent between the Jedi Council and " +
                              "Palpatine and is lured into a sinister plan to rule the galaxy.",
                Rating = 3.8f,
                Actors = new []
                {
                    1004,
                    1006,
                    1007,
                    1008
                }
            },
            new()
            {
                Id = 104,
                Title = "Star Wars: Episode IV - A New Hope",
                Rating = 4.3f,
                Description = "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two " +
                              "droids to save the galaxy from the Empire's world-destroying battle station, while " +
                              "also attempting to rescue Princess Leia from the mysterious Darth Vader.",
                Actors = new []
                {
                    1001,
                    1002,
                    1003
                }
            },
            new()
            {
                Id = 105,
                Title = "Star Wars: Episode V - The Empire Strikes Back",
                Description = "After the Rebels are brutally overpowered by the Empire on the ice planet Hoth, Luke " +
                              "Skywalker begins Jedi training with Yoda, while his friends are pursued across the " +
                              "galaxy by Darth Vader and bounty hunter Boba Fett.",
                Rating = 4.35f,
                Actors = new []
                {
                    1001,
                    1002,
                    1003,
                    1008
                }
            },
            new ()
            {
                Id = 106,
                Title = "Star Wars: Episode VI - Return of the Jedi",
                Description = "After a daring mission to rescue Han Solo from Jabba the Hutt, the Rebels dispatch to " +
                              "Endor to destroy the second Death Star. Meanwhile, Luke struggles to help Darth Vader " +
                              "back from the dark side without falling into the Emperor's trap.",
                Rating = 4.15f,
                Actors = new []
                {
                    1001,
                    1002,
                    1003,
                    1008
                }
            }
        };

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Movie>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]

        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            return Ok(MoviesDb.AsEnumerable());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public ActionResult<Movie?> GetMovie(int id)
        {
            Movie? movie = MoviesDb.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
    }
}