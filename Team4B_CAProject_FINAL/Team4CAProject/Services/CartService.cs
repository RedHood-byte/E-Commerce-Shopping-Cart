using System;
using System.Collections.Generic;
using System.Linq;
using Team4CAProject.DB;
using Team4CAProject.Models;

namespace Team4CAProject.Services
{
    public class CartService
    {
        private readonly CADb _db;
        public CartService(CADb db)
        {
            _db = db;
        }

        public int AddProductsToCart(int userId, int prdId, int quantity)
        {
            using (var trn = _db.Database.BeginTransaction())
            {
                try
                {
                    AddCart(userId);
                    Cart cart = _db.Cart.FirstOrDefault(x => x.CustomerId == userId && !x.IsCheckOut);
                    AddCartItem(prdId, quantity, cart);
                    _db.SaveChanges();
                    trn.Commit();
                    return cart.Quantity;
                }
                catch (Exception e)
                {
                    trn.Rollback();
                    throw new Exception(e.Message);
                }
            }
        }

        private void AddCart(int userId)
        {
            Cart cart = _db.Cart.FirstOrDefault(x => x.CustomerId == userId && !x.IsCheckOut);
            if (cart == null)
            {
                cart = new Cart(userId);
                _db.Cart.Add(cart);
            }
            _db.SaveChanges();
        }

        public int GetNumberOfCartItem(int userId)
        {
            return _db.Cart.FirstOrDefault(x => x.CustomerId == userId && !x.IsCheckOut)?.Quantity ?? 0;
        }

        public void AddCartItem(int prdId, int quantity, Cart cart)
        {
            Product product = _db.Products.First(x => x.Id == prdId);
            CartItem cartItem = _db.CartItem.FirstOrDefault(x => x.CartId == cart.Id && x.ProductId == prdId);

            if (cartItem == null)
            {
                cartItem = new CartItem(cart.Id, prdId);
                _db.CartItem.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            if (cartItem.Quantity == 0)
            {
                _db.CartItem.Remove(cartItem);
            }
            cart.Quantity += quantity;
            cart.Value += quantity * product.UnitPrice;
        }

        public void AddCartItemForSession(int prdId, int quantity, Cart cart)
        {
            Product product = _db.Products.First(x => x.Id == prdId);
            CartItem cartItem = cart.CartItems.FirstOrDefault(x => x.ProductId == prdId);

            if (cartItem == null)
            {
                cartItem = new CartItem(cart.Id, prdId);
                cartItem.Product = product;
                cart.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            if (cartItem.Quantity == 0)
            {
                cart.CartItems.Remove(cartItem);
            }
            cart.Quantity += quantity;
            cart.Value += quantity * product.UnitPrice;
        }

        public Cart GetCartForCustomer(int customerId)
        {
            var cart = _db.Cart.Where(cart => cart.CustomerId == customerId && !cart.IsCheckOut).FirstOrDefault();
            if (cart != null)
            {
                cart.CartItems = _db.CartItem.Where(x => x.CartId == cart.Id).ToList<CartItem>();
            }
            return cart ?? new Cart();
        }

        public void AddCartWithCustomer(int customerId, Cart cart)
        {
            using (var trn = _db.Database.BeginTransaction())
            {
                try
                {
                    var newCart = new Cart(customerId);
                    newCart.Quantity = cart.Quantity;
                    newCart.CreationTime = cart.CreationTime;
                    newCart.Value = cart.Value;
                    _db.Cart.Add(newCart);
                    _db.SaveChanges();
                    foreach (var item in cart.CartItems)
                    {
                        var cartitem = new CartItem 
                        { 
                            CartId = newCart.Id,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity
                        };
                        _db.CartItem.Add(cartitem);
                    }
                    _db.SaveChanges();
                    trn.Commit();
                }
                catch (Exception e)
                {
                    trn.Rollback();
                }
            }
        }

        public int CheckoutCart(int customerId)
        {
            Cart cart = _db.Cart.First(x=>x.CustomerId == customerId && !x.IsCheckOut);
            cart.IsCheckOut = true;
            cart.CheckoutTime = DateTime.Now;
            _db.Cart.Update(cart);
            _db.SaveChanges();

            //cartitem
            List<CartItem> cartItems =  _db.CartItem.Where(x=>x.CartId == cart.Id).ToList();
            foreach(var item in cartItems)
            {
                //stock reduce
                var product = _db.Products.First(x=>x.Id == item.Id);
                product.Stock -= item.Quantity;
                _db.Update(product);

                //activation
                for (int i = 0; i < item.Quantity; i++)
                {
                    string activationCode = GetActivationCode(item.CartId, item.ProductId);
                    PurchasedActivationCode pac = new PurchasedActivationCode(item.Id, activationCode);
                    _db.PurchasedActivationCode.Add(pac);
                }
                //update checkout time
                item.CheckoutTime = DateTime.Now;
                _db.Update(item);
            }
            _db.SaveChanges();
            return cart.Id;
        }

        public Cart GetCartById(int cartId)
        {
            Cart cart = _db.Cart.First(x=>x.Id == cartId);
            cart.CartItems = _db.CartItem.Where(x=>x.CartId == cartId).ToList();
            foreach(var item in cart.CartItems)
            {
                item.ActivationCodes = _db.PurchasedActivationCode.Where(x => 
                x.CartItemId == item.Id).ToList();
            }
            return cart;
        }

        public List<Cart> GetPurchasedHistory(int customerId)
        {
            var carts = _db.Cart.Where(x=>x.CustomerId == customerId && x.IsCheckOut).ToList();
            return carts;
        }

        private static string GetActivationCode(int cartId, int productId)
        {
            return cartId + "-" + productId + "-" + Guid.NewGuid().ToString();
        }
    }
}
