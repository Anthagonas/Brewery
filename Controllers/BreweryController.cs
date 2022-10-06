using BeerManager.Models;
using BeerManager.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerManager.Controllers
{
    [Route("brewery")]
    [ApiController]
    public class BreweryController : ControllerBase
    {
        IBeerRepository _beerRepository;

        public BreweryController(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository ?? throw new ArgumentNullException(nameof(beerRepository));
        }

        // GET brewery/breweryId
        [HttpGet("{breweryId}")]
        public IActionResult GetBeersByBrewery(string breweryId)
        {
            List<Beer> result = _beerRepository.FindBeersByBreweryId(breweryId);

            if (result?.Any() ?? false)
            {
                return Ok(result);
            }
            return NotFound();
        }

        // POST brewery/breweryId
        [HttpPost("{breweryId}")]
        public IActionResult AddBeer(string breweryId, [FromBody] Beer newBeer)
        {
            _beerRepository.AddBeer(breweryId, newBeer);
            return CreatedAtAction(null, newBeer);
        }

        // DELETE brewery/breweryId/beerId
        [HttpDelete("{breweryId}/{beerId}")]
        public IActionResult DeleteBeer(string breweryId, string beerId)
        {
            var removedBeersCount = _beerRepository.DeleteBeer(breweryId, beerId);
            if(removedBeersCount == 0)
            {
                return NotFound("No matching beer with the given brewery ID");
            }
            return NoContent();
        }
    }
}
