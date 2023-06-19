
namespace API.Entities
{
    public class Batch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public DateOnly DeliveryDate  { get; set; }

        public DateOnly ExpirationDate  { get; set; }
    }
}
