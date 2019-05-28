using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models.ViewModels
{
    public class User
    {
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }

        public double Revenue { get; set; }
        public int Earned { get; set; }
        public int Spend { get; set; }
    }
}
