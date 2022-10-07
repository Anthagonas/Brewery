using BeerManager.Exceptions;
using BeerManager.Models;
using BeerManager.Repository;
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
        IWholesalerRepository _wholesalerRepository;
        IBeerRepository _beerRepository;

        public WholesalerController(IWholesalerRepository wholesalerRepository, IBeerRepository beerRepository)
        {
            _wholesalerRepository = wholesalerRepository ?? throw new ArgumentNullException(nameof(wholesalerRepository));
            _beerRepository = beerRepository ?? throw new ArgumentNullException(nameof(beerRepository));
        }

        // PATCH wholesaler/wholesalerId/beerId
        [HttpPatch("{wholesalerId}/{beerId}")]
        public IActionResult ModifyBeerStock(string wholesalerId, string beerId, [FromBody] string newStockAmount)
        {
            try
            {
                _wholesalerRepository.SetBeerStockAmount(wholesalerId, beerId, newStockAmount);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        // POST wholesaler/wholesalerId
        [HttpPost("{wholesalerId}")]
        public IActionResult AddBeer(string wholesalerId, [FromBody] Dictionary<string,int> newBeerStock)
        {
            if (!newBeerStock?.Any() ?? true || newBeerStock.Keys.Count > 1)
            {
                return BadRequest("Invalid beer count");
            }
            var newBeer = newBeerStock.Single();
            if(!_beerRepository.HasBeer(newBeer.Key))
            {
                return BadRequest("Invalid beerId");
            }

            try { 
                _wholesalerRepository.AddBeer(wholesalerId, newBeer.Key, newBeer.Value);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction(null, newBeer.Key);
        }
    }
}
