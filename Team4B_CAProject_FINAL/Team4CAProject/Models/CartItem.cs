using System;
using System.Collections.Generic;

namespace Team4CAProject.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual DateTime CheckoutTime { get; set; }

        public virtual List<PurchasedActivationCode> ActivationCodes { set; get; }
        public CartItem()
        {
            ActivationCodes = new List<PurchasedActivationCode>();
        }

        public CartItem(int cartId, int productId)
        {
            CartId = cartId;
            ProductId = productId;
            Quantity = 1;
            ActivationCodes = new List<PurchasedActivationCode>();
        }
    }
}
