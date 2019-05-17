using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class StageEnd : JsonModel
    {
        public int Stage { get; set; }
        public bool Win { get; set; }
        public int Time { get; set; }
        public int Income { get; set; }
    }
}
