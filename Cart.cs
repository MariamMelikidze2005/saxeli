using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    public class Cart
    {
        public List<Product> Items { get; set; }
        public decimal TotalPrice => Items.Sum(item => item.Price);

        public Cart()
        {
            Items = new List<Product>();
        }

        public void AddToCart(Product product)
        {
            Items.Add(product);
        }

        public void RemoveFromCart(Product product)
        {
            Items.Remove(product);
        }

        public string GetCartSummary()
        {
            var summary = Items.Select(item => item.GetDetails()).ToList();
            summary.Add($"Total Price: {TotalPrice:C}");
            return string.Join(Environment.NewLine, summary);
        }
    }


}
