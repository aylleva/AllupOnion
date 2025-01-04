
namespace AllupOnion.Domain.Entities
{
    public class Product:BaseNamebleEntity
    {
        public decimal Price {  get; set; }
        public string ProductCode {  get; set; }
        public string Description {  get; set; }
        public bool IsAvailable { get; set; }

        public int CategoryId {  get; set; }
        public Category Category { get; set; }
        public ICollection<ProductColors> ProductColors { get; set; }
    }
}
