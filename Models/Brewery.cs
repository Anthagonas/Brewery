using System;
using System.Collections.Generic;

namespace BeerManager.Models
{
    public class Brewery
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<Beer> Beers { get; set; }
    }
}
