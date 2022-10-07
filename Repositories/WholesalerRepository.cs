using BeerManager.Exceptions;
using BeerManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace BeerManager.Repository
{
    public class WholesalerRepository : IWholesalerRepository
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

        public void AddBeer(string wholesalerId, string beerId, int stockAmount)
        {
            var wholesaler = wholesalers.SingleOrDefault(wholesaler => wholesaler.Id == wholesalerId);
            if (wholesaler is null)
            {
                throw new BadRequestException("Invalid wholesaler ID");
            }
            if (wholesaler.Stock.ContainsKey(beerId))
            {
                throw new BadRequestException("Beer already exists for this wholesaler");
            }
            wholesaler.Stock[beerId] = stockAmount;
        }

        public void SetBeerStockAmount(string wholesalerId, string beerId, string newStockAmount)
        {
            var wholesaler = wholesalers.SingleOrDefault(wholesaler => wholesaler.Id == wholesalerId);
            if (wholesaler is null)
            {
                throw new BadRequestException("Invalid wholesaler ID");
            }
            if (wholesaler.Stock.Any(beer => beer.Key == beerId))
            {
                wholesaler.Stock[beerId] = int.Parse(newStockAmount);
            }
            else
            {
                throw new BadRequestException("Invalid beer ID");
            }
        }
    }
}
