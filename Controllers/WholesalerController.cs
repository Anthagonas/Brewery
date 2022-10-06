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
                return BadRequest("Invalid wholesaler ID");
            }
            if(wholesaler.Stock.Any(beer => beer.Key == beerId))
            {
                wholesaler.Stock[beerId] = int.Parse(newStockAmount);
            }
            else
            {
                return BadRequest("Invalid beer ID");
            }
            return NoContent();
        }

        // POST wholesaler/wholesalerId
        [HttpPost("{wholesalerId}")]
        public IActionResult AddBeer(string wholesalerId, [FromBody] Dictionary<string,int> newBeerStock)
        {
            var wholesaler = wholesalers.SingleOrDefault(wholesaler => wholesaler.Id == wholesalerId);
            if (wholesaler is null)
            {
                return BadRequest("Invalid wholesaler ID");
            }
            if(!newBeerStock?.Any()??true || newBeerStock.Keys.Count > 1)
            {
                return BadRequest("Invalid beer count");
            }
            var newBeer = newBeerStock.Single();
            if (wholesaler.Stock.ContainsKey(newBeer.Key))
            {
                return BadRequest("Beer already exists for this wholesaler");
            }
            wholesaler.Stock[newBeer.Key] = newBeer.Value;
            return CreatedAtAction(null, newBeer.Key);
        }
    }
}
