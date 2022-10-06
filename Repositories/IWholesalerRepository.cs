namespace BeerManager.Repository
{
    public interface IWholesalerRepository
    {
        public void AddBeer(string wholesalerId, string beerId, int stockAmount);
    }
}
