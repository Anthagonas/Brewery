using BeerManager.Models;
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
        #region DataSet
        List<Beer> beers = new List<Beer>{
                    new Beer
                    {
                        AlcoholContent  = 6.0,
                        BreweryId       = "123456789",
                        Id              = "987654321",
                        BreweryName     = "a brewery",
                        Name            = "good Beer",
                        Price           = 3.4
                    },
                    new Beer
                    {
                        AlcoholContent  = 3.0,
                        BreweryId       = "000000001",
                        Id              = "100000000",
                        BreweryName     = "an other brewery",
                        Name            = "excellent Beer",
                        Price           = 2.6
                    }
        };
        #endregion

        // GET brewery/breweryId
        [HttpGet("{breweryId}")]
        public IActionResult GetBeersByBrewery(string breweryId)
        {
            List<Beer> result = beers.Where(beer => beer.BreweryId == breweryId).ToList();

            if (result?.Any() ?? false)
            {
                return Ok(beers.Where(beer => beer.BreweryId == breweryId).ToList());
            }
            return NotFound();
        }

        // POST brewery/breweryId
        [HttpPost("{breweryId}")]
        public IActionResult AddBeer(string breweryId, [FromBody] Beer newBeer)
        {
            newBeer.Id = Guid.NewGuid().ToString();
            newBeer.BreweryId = breweryId;
            beers.Add(newBeer);
            return CreatedAtAction(null, newBeer);
        }

        // DELETE brewery/breweryId/beerId
        [HttpDelete("{breweryId}/{beerId}")]
        public IActionResult DeleteBeer(string breweryId, string beerId)
        {
            beers.RemoveAll(beer => beer.Id == beerId && beer.BreweryId == breweryId);
            return NoContent();
        }
    }
}
