using BeerManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

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
        public List<Beer> GetBeersByBrewery(string breweryId)
        {
            return beers.Where(beer => beer.BreweryId == breweryId).ToList();
        }

        // POST brewery/breweryId
        [HttpPost("{breweryId}")]
        public void AddBeer(string breweryId, [FromBody] string newBeer)
        {
            beers.Add(JsonSerializer.Deserialize<Beer>(newBeer));
        }

        // DELETE brewery/breweryId/beerId
        [HttpDelete("{breweryId}/{beerId}")]
        public void DeleteBeer(string breweryId, string beerId)
        {
            beers.RemoveAll(beer => beer.Id == beerId && beer.BreweryId == breweryId);
        }
    }
}
