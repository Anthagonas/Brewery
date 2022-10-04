using Microsoft.AspNetCore.Mvc;
using System;

namespace BeerManager.Controllers
{
    [Route("wholesaler")]
    [ApiController]
    public class WholesalerController : ControllerBase
    {
        // PATCH wholesaler/wholesalerId/beerId
        [HttpPatch("{wholesalerId}")]
        public void ModifyBeerStock(string wholesalerId, string beerId, [FromBody] string newStockAmount)
        {
            throw new NotImplementedException();
        }

        // POST wholesaler/wholesalerId
        [HttpPost("{wholesalerId}")]
        public void AddBeer(string wholesalerId, [FromBody] string newBeerId)
        {
            throw new NotImplementedException();
        }
    }
}
