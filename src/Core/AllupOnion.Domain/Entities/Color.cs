

namespace AllupOnion.Domain.Entities
{
    public class Color:BaseNamebleEntity
    {
        public ICollection<ProductColors> ProductColors { get; set; }
    }
}
