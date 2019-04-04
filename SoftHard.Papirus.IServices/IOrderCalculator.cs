using System;
using System.Collections.Generic;
using System.Text;

namespace SoftHard.Papirus.IServices
{
    public interface IOrderCalculator
    {
        decimal Calculate(Location location, decimal amount); 
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }


    public class MyOrderCalculator : IOrderCalculator
    {
        public decimal Calculate(Location location, decimal amount)
        {
            if (location == null)
                throw new ArgumentNullException(nameof(location));

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }



     
            return (decimal) location.Latitude - (decimal) location.Longitude;

        }
    }
}
