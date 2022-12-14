namespace BeerManager.Repository
{
    public interface IWholesalerRepository
    {
        public void AddBeer(string wholesalerId, string beerId, int stockAmount);
        void SetBeerStockAmount(string wholesalerId, string beerId, string newStockAmount);
        int GetBeerStockAmount(string wholesalerId, string beerId);
    }
}
