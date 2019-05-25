using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models.ViewModels
{
    public class StageViewModel
    {
        public int StageNumber { get; set; }
        public int StageStarts { get; set; }
        public int StageEnds { get; set; }
        public int WinsQuantity { get; set; }
        public int AllIncome { get; set; }
    }
}
