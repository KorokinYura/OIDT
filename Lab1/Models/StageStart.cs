using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class StageStart : JsonModel
    {
        public int Stage { get; set; }
    }
}
