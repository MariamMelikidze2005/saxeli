using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    public class EBook : Product
    {
        public double FileSizeInMB { get; set; }

        public override string GetDetails()
        {
            return base.GetDetails() + $", File Size: {FileSizeInMB} MB";
        }
    }

}
