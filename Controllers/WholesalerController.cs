using BeerManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerManager.Controllers
{
    [Route("wholesaler")]
    [ApiController]
    public class WholesalerController : ControllerBase
    {
        #region DataSet
        List<Wholesaler> wholesalers = new List<Wholesaler>{
                    new Wholesaler
                    {
                        Id = "777777777",
                        Name = "A wholesaler",
                        Stock = new Dictionary<string, int>{ { "987654321", 10 } }
                    }
        };
        #endregion

        // PATCH wholesaler/wholesalerId/beerId
        [HttpPatch("{wholesalerId}/{beerId}")]
        public IActionResult ModifyBeerStock(string wholesalerId, string beerId, [FromBody] string newStockAmount)
        {
            var wholesaler = wholesalers.SingleOrDefault(wholesaler => wholesaler.Id == wholesalerId);
            if(wholesaler is null)
            {
                throw new NotImplementedException(); //TODO no wholesaler matching
            }
            if(wholesaler.Stock.Any(beer => beer.Key == beerId))
            {
                wholesaler.Stock[beerId] = int.Parse(newStockAmount);
            }
            else
            {
                throw new NotImplementedException(); //TODO no beer matching
            }
            return NoContent();
        }

        // POST wholesaler/wholesalerId
        [HttpPost("{wholesalerId}")]
        public void AddBeer(string wholesalerId, [FromBody] string newBeerId)
        {
            throw new NotImplementedException();
        }
    }
}
