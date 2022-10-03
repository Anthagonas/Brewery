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
        [HttpPost]
        public void Post(string breweryId, [FromBody] string newBeer)
        {
            throw new NotImplementedException("Post method at brewery not implemented");
        }

        // DELETE brewery/breweryId/beerId
        [HttpDelete("{breweryId}/{beerId}")]
        public void Delete(string breweryId, string beerId)
        {
            throw new NotImplementedException("Delete method at brewery not implemented");
        }
    }
}
