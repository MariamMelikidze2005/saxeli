using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    public class Laptop : Product
    {
        public double Weight { get; set; }
        public string Dimensions { get; set; }

        public override string GetDetails()
        {
            return base.GetDetails() + $", Weight: {Weight} kg, Dimensions: {Dimensions}";
        }
    }

}
