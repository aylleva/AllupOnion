using AllupOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllupOnion.Domain.Entities
{
    public class Category:BaseNamebleEntity
    {
        public ICollection<Product> Products { get; set; }
    }
}
