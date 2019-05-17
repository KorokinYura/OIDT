using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class IngamePurchase : JsonModel
    {
        public string Item { get; set; }
        public double Price { get; set; }
    }
}
