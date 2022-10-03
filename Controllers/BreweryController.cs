using Microsoft.AspNetCore.Mvc;
using System;

namespace BeerManager.Controllers
{
    [Route("brewery")]
    [ApiController]
    public class BreweryController : ControllerBase
    {
        // GET brewery/breweryId
        [HttpGet("{breweryId}")]
        public string Get(string breweryId)
        {
            throw new NotImplementedException("Get method at brewery not implemented");
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
