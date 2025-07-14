
namespace KJohnsonFinalProject
{
    /// <summary>
    /// Represents an item in the shopping cart with product details and quantity selected.
    /// </summary>
    public class CartItem
    {
        public int ProductID { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int QuantitySelected { get; set; }
        public int Stock { get; set; }
    }
}
