// Product.cs
using System.ComponentModel.DataAnnotations;

namespace MarketPuan.Data
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(255)] // Change the value according to your needs
        public string Name { get; set; }
        
    }
}