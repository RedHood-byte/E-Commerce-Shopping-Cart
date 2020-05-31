using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Team4CAProject.Models;
using Team4CAProject.Services;

namespace Team4CAProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //---------Login-------------------------
        public IActionResult Index([FromServices] BrowseService bs, [FromServices] CartService cs, string query="")
        {
            List<Product> products = bs.GetProducts(query);
            ViewData["products"] = products;
            ViewData["username"] = HttpContext.Session.GetString("username");
            int customerId = HttpContext.Session.GetInt32("customerId") ?? 0;
            ViewData["ItemCount"] = cs.GetNumberOfCartItem(customerId);
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult AfterLogin([FromServices] LoginService ls, string username, string password, [FromServices] BrowseService bs, [FromServices] CartService cs, string query1 = "")
        {
            int val = ls.Login(username, password, HttpContext.Session);
            if (val == 1)
            {
                TempData["err"] = "Username does not exist";
                return RedirectToAction("Login", "Home");
            }
            else if (val == 2)
            {
                TempData["err"] = "Incorrect password";
                return RedirectToAction("Login", "Home");
            }
            else if (val == 3)
            {
                ViewData["username"] = username;
                HttpContext.Session.SetString("username", username);
                
                ViewData["username"] = HttpContext.Session.GetString("username");
            }
            if(ViewData["username"] != null)
            {
                List<Product> products = bs.GetProducts(query1);
                ViewData["products"] = products;
                var customerId = HttpContext.Session.GetInt32("customerId") ?? 0;
                var sessionCart = HttpContext.Session.GetString("Cart");
                if (sessionCart != null) 
                {
                    var cart = JsonConvert.DeserializeObject<Cart>(sessionCart);
                    cs.AddCartWithCustomer(customerId, cart);
                    ViewData["ItemCount"] = cart.Quantity;
                }
                else
                {
                    ViewData["ItemCount"] = cs.GetNumberOfCartItem(customerId);
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

        //---------------------Products-------------------------
        public IActionResult MyPurchases()
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
           
            return View();
        }

        public IActionResult AddToCart([FromServices] CartService srv, int prdId)
        {
            var customerId = HttpContext.Session.GetInt32("customerId") ?? 0;
            if (customerId == 0)
            {
                AddToCartForSession(srv, prdId, 1);
            }
            else
            {
                ViewData["ItemCount"] = srv.AddProductsToCart(customerId, prdId, 1);
            }
            return PartialView("_CartButton");
        }

        public IActionResult AddToCartFromDetail([FromServices] CartService srv, int prdId, int quantity)
        {
            var customerId = HttpContext.Session.GetInt32("customerId") ?? 0;
            if (customerId == 0)
            {
                AddToCartForSession(srv, prdId, quantity);
            }
            else
            {
                srv.AddProductsToCart(customerId, prdId, quantity);
            }
            return RedirectToAction("ViewCart", "Home");
        }

        private void AddToCartForSession([FromServices] CartService srv, int prdId, int quantity)
        {
            var sessionCart = HttpContext.Session.GetString("Cart");
            var cart = new Cart();
            if (sessionCart == null)
            {
                srv.AddCartItemForSession(prdId, quantity, cart);
            }
            else
            {
                cart = JsonConvert.DeserializeObject<Cart>(sessionCart);
                var prdCart = cart.CartItems.FirstOrDefault(x => x.ProductId == prdId);
                srv.AddCartItemForSession(prdId, quantity, cart);
            }
            var strCart = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("Cart", strCart);
            ViewData["ItemCount"] = cart.Quantity;
        }

        public ActionResult ViewCart([FromServices] CartService srv)
        {
            var customerId = HttpContext.Session.GetInt32("customerId") ?? 0;
            Cart cart;
            if (customerId == 0)
            {
                var sessionCart = HttpContext.Session.GetString("Cart");
                if (sessionCart == null)
                {
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    cart = JsonConvert.DeserializeObject<Cart>(sessionCart);
                }
            }
            else
            {
                cart = srv.GetCartForCustomer(customerId);
            }
            return View(cart);
        }

        public ActionResult CheckoutCart([FromServices] CartService srv)
        {
            var customerId = HttpContext.Session.GetInt32("customerId") ?? 0;
           
            {
                var cartId = srv.CheckoutCart(customerId);
                return RedirectToAction("MyPurchase", "Home", new { cartId =  cartId });
            }
        }

        public ActionResult MyPurchase([FromServices] CartService srv, int cartId)
        {
            var cart = srv.GetCartById(cartId);
            ViewData["ItemCount"] = 0;
            return View(cart);
        }

        public ActionResult PurchasedHistory([FromServices] CartService srv)
        {
            var customerId = HttpContext.Session.GetInt32("customerId") ?? 0;
            var carts = srv.GetPurchasedHistory(customerId);
            ViewData["ItemCount"] = srv.GetNumberOfCartItem(customerId);
            return View(carts);
        }

        public IActionResult BrowseNoLogin ([FromServices] BrowseService bs, [FromServices] CartService srv, string query="")
        {
            List<Product> products = bs.GetProducts(query);
            int customerId = HttpContext.Session.GetInt32("customerId") ?? 0;
            ViewBag.keyword = query;
            ViewData["ItemCount"] = srv.GetNumberOfCartItem(customerId);
            ViewData["products"] = products;

            return View("Index");
        }

        public IActionResult BrowseAftLogin([FromServices] BrowseService bs, [FromServices] CartService srv, string query1 = "")
        {
            List<Product> products = bs.GetProducts(query1);
            ViewData["products"] = products;
            ViewData["username"] = HttpContext.Session.GetString("username");
            int customerId = HttpContext.Session.GetInt32("customerId") ?? 0;
            ViewBag.keyword = query1;
            ViewData["ItemCount"] = srv.GetNumberOfCartItem(customerId);
            return View("AfterLogin");
        }

        //================================System Generated===========================================
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Payment()
        {
            var customerId = HttpContext.Session.GetInt32("customerId") ?? 0;
            if (customerId == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            { return View(); }
        }
        public IActionResult PaymentResult()
        {
            
             return View(); 
        }
    }
}
