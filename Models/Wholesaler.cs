using System.Collections.Generic;

namespace BeerManager.Models
{
    public class Wholesaler
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string,int> Stock { get; set; }
    }
}
