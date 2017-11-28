using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLabs_V3.Models;
using WebLabs_V3.DAL.Interfaces;
using WebLabs_V3.DAL.Entities;

namespace WebLabs_V3.Controllers
{
    public class CartController : Controller
    {

        IRepository<Dish> repository;

        public CartController(IRepository<Dish> repo)
        {
            repository = repo;
        }
        [Authorize]
        // GET: Cart
        public ActionResult Index(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View(GetCart());
        }
        /// <summary>
        /// Получение корзины из сессии
        /// </summary>
        /// <returns></returns>
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="id">id добавляемого элемента</param>
        /// <param name="returnUrl">URL страницы для возврата</param>
        /// <returns></returns>
        public RedirectResult AddToCart(int id, string returnUrl)
        {
            var item = repository.Get(id);
            if (item != null)
                GetCart().AddItem(item);
            return Redirect(returnUrl);
        }

        public PartialViewResult CartSummary(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return PartialView(GetCart());
        }
    }
}