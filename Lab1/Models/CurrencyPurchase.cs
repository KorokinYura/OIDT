﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class CurrencyPurchase : JsonModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Income { get; set; }
    }
}
