using BeerManager.Models;
using System.Collections.Generic;

namespace BeerManager.Repository
{
    public class WholesalerRepository : IWholesalerRepository
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

        public void AddBeer(string wholesalerId, string beerId, int stockAmount)
        {
            throw new System.NotImplementedException();
        }
    }
}
