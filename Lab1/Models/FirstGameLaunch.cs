using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class FirstGameLaunch : JsonModel
    {
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
    }
}
