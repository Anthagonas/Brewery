using BeerManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerManager.Repository
{
    public class BeerRepository: IBeerRepository
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

        public void AddBeer(string breweryId, Beer newBeer)
        {
            newBeer.Id = Guid.NewGuid().ToString();
            newBeer.BreweryId = breweryId;
            beers.Add(newBeer);
        }

        public int DeleteBeer(string breweryId, string beerId)
        {
            return beers.RemoveAll(beer => beer.Id == beerId && beer.BreweryId == breweryId);
        }

        public List<Beer> FindBeersByBreweryId(string breweryId)
        {
            return beers.Where(beer => beer.BreweryId == breweryId).ToList();
        }

        public double GetBeerPrice(string beerId)
        {
            return beers.Single(beer => beer.Id == beerId).Price;
        }
    }
}
