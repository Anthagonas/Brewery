using BeerManager.Models;

namespace BeerManager.Repository
{
    public interface IBeerRepository
    {
        public void AddBeer(string breweryId, Beer newBeer);
    }
}
