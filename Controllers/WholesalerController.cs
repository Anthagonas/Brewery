﻿using BeerManager.Exceptions;
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
            if (newBeerStock is null || !newBeerStock.Any() || newBeerStock.Keys.Count > 1)
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

        //TODO : A client can request a quote from a wholesaler
        /*
         * 1- If successful, the method returns a price and a summary of the quote.
                o A 10% discount is applied above 10 drinks
                o A 20% discount is applied above 20 drinks
         * 2- If there is an error, it returns an exception and a message to explain the reason:
                o The order cannot be empty
                o The wholesaler must exist
                o There can't be any duplicate in the order
                o The number of beers ordered cannot be greater than the wholesaler's stock
                o The beer must be sold by the wholesaler
         */
        // POST wholesaler/wholesalerId/quote
        [HttpPost("{wholesalerId}/quote")]
        public IActionResult RequestQuote(string wholesalerId, [FromBody] Dictionary<string, int> order)
        {
            if (order is null || !order.Any())
            {
                return BadRequest("The order cannot be empty");
            }
            //TODO : Check duplicate beerId in order
            //return BadRequest("There can't be any duplicate in the order");

            QuoteSummary quoteSummary = new QuoteSummary();
            foreach (KeyValuePair<string,int> beer in order)
            {
                string beerId = beer.Key;
                int amountOfBeerOrdered = beer.Value;

                int availableStock = _wholesalerRepository.GetBeerStockAmount(wholesalerId, beerId);
                if(availableStock < amountOfBeerOrdered)
                {
                    return BadRequest("The number of beers ordered cannot be greater than the wholesaler's stock");
                } 
                else if (amountOfBeerOrdered < 1)
                {
                    return BadRequest("The number of beers ordered cannot be lower than 1");
                }
                else
                {
                    double beerUnitPrice = _beerRepository.GetBeerPrice(beerId);
                    quoteSummary.AddNewElement(beerId, amountOfBeerOrdered, beerUnitPrice);
                }
            }

            return Ok(quoteSummary);
        }
    }
}
