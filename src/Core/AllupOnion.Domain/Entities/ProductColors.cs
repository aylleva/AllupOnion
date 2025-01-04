using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllupOnion.Domain.Entities
{
    public class ProductColors
    {
        public int ProductId {  get; set; }
        public int ColorId {  get; set; }
        public Product Product { get; set; }
        public Color Color { get; set; }
    }
}
