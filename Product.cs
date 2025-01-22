using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public virtual string GetDetails()
        {
            return $"Name: {Name}, Price: {Price:C}, Stock: {Stock}, Category: {Category}, Description: {Description}";
        }

        public bool IsInStock()
        {
            return Stock > 0;
        }
    }



}
