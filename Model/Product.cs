using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }
        public double TotalCost { get { return Cost * Quantity; } }
    }
}
