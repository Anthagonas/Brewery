namespace BeerManager.Models
{
    public class Beer
    {
        #region Beer
        public string Id { get; set; }
        public string Name { get; set; }
        public double AlcoholContent { get; set; }
        public double Price { get; set; }
        #endregion

        #region Brewery
        public string BreweryId { get; set; }
        public string BreweryName { get; set; }
        #endregion
    }
}
