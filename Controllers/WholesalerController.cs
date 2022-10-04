using BeerManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BeerManager.Controllers
{
    [Route("wholesaler")]
    [ApiController]
    public class WholesalerController : ControllerBase
    {
        #region DataSet
        List<Wholesaler> beers = new List<Wholesaler>{
                    new Wholesaler
                    {
                        Id = "777777777",
                        Name = "A wholesaler",
                        Stock = new Dictionary<string, int>{ { "987654321", 10 } }
                    }
        };
        #endregion

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
