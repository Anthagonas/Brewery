using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerManager.Models
{
    public class QuoteSummary
    {
        public double TotalPrice { get; set; }
        public int TotalItems { get; set; }
        public double AppliedDiscountInPercentage { get; set; }
        public List<QuoteDetail> Details { get; set; }

        public QuoteSummary()
        {
            Details = new List<QuoteDetail>();
        }

        public void AddNewElement(string name, int amount, double unitPrice)
        {
            TotalItems += amount;
            Details.Add(new QuoteDetail(name, amount, unitPrice));
            CalculateNewTotalPrice();
        }

        private void CalculateNewTotalPrice()
        {
            TotalPrice = Details.Sum(line => line.Price);
            if(TotalItems > 20)
            {
                AppliedDiscountInPercentage = 20;
                TotalPrice = CalculateDiscount(TotalPrice, 20);
            }
            else if (TotalItems > 10)
            {
                AppliedDiscountInPercentage = 10;
                TotalPrice = CalculateDiscount(TotalPrice, 10);
            }
        }

        private double CalculateDiscount(double initialPrice, double percentage)
        {
            return initialPrice - (initialPrice * percentage / 100);
        }

        public class QuoteDetail
        {
            public string Name { get; set; }
            public int Amount { get; set; }
            public double UnitPrice { get; set; }
            public double Price { get; set; }
            public QuoteDetail(string name, int amount, double unitPrice)
            {
                Name = name;
                Amount = amount;
                UnitPrice = unitPrice;
                Price = unitPrice * amount;
            }
        }
    }
}
