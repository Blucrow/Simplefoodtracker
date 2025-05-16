namespace Blucrow.Foodtracker.Objects
{
    public class ProductsConsumed
    {
        public Product Product { get; set; } = null!;
        public DateOnly Date { get; set; }
    }
}
