using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models.ViewModels
{
    public class PurchaseViewModel
    {
        public string Item { get; set; }
        public int ItemsQuantity { get; set; }
        public double AllPrice { get; set; }
    }
}
