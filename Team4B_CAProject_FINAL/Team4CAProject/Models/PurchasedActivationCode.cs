using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team4CAProject.Models
{
    public class PurchasedActivationCode
    {
        public int Id { set; get; }
        public int CartItemId { get; set; }
        public string ActivationCode { get; set; }

        public PurchasedActivationCode (int cartItemId, string activationCode)
        {
            CartItemId = cartItemId;
            ActivationCode = activationCode;
        }
    }
}
