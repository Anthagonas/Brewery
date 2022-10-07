using BeerManager.Models;
using System.Collections.Generic;

namespace BeerManager.Repository
{
    public interface IBeerRepository
    {
        public void AddBeer(string breweryId, Beer newBeer);
        List<Beer> FindBeersByBreweryId(string breweryId);
        int DeleteBeer(string breweryId, string beerId);
        double GetBeerPrice(string beerId);
        bool HasBeer(string beerId);
    }
}
