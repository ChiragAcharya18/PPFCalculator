using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPFCalculator.Model
{
    public class Data
    {
        public int Year { get; set; }
        public DateTime Date { get; set; }
        public double Opening { get; set; }
        public double Deposite { get; set; }
        public double Interest { get; set; }
        public double Closing { get; set; }
    }
}
