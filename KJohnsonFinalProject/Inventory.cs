using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJohnsonFinalProject
{
    /// <summary>
    /// Represents an inventory product with details such as name, price, quantity, and category.
    /// </summary>
    public class Inventory
    {
        //Getters and Setters for Inventory Products
        public int InventoryID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int CategoryID { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public int RestockThreshold { get; set; }
        public byte[] ItemImage { get; set; }
        public bool Discontinued { get; set; }
    }
}
