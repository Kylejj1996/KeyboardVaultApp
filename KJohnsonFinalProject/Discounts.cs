
namespace KJohnsonFinalProject
{
    /// <summary>
    /// Represents discount details including discount code, type, value, applicable item or category, and dates.
    /// </summary>
    public class Discounts
    {
        //Getters and Setters for Discounts
        public int DiscountID { get; set; }
        public string DiscountCode { get; set; }
        public string Description { get; set; }
        public int DiscountLevel { get; set; }
        public int InventoryID { get; set; }
        public int DiscountType { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountDollarAmount { get; set; }
        public string StartDate { get; set; }
        public string ExpirationDate { get; set; }
        public bool isDiscontinued { get; set; }
        public int CategoryID { get; set; }
        public string ItemName {  get; set; }
    }
}
