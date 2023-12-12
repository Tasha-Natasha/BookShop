using BookShop;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.Models;

namespace Shop.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IBookRepository bookRepository;

        public CartController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IActionResult Add(int id)
        {
            var book = bookRepository.GetById(id);
            Cart cart;

            if(!HttpContext.Session.TryGetCart(out cart)) 
            {
                cart = new Cart();
            }

            if(cart.Items.ContainsKey(id)) 
            {
                cart.Items[id]++;
                cart.Amount += book.Price;
            }
            else
            {
                cart.Items[id] = 1;
                cart.Amount += book.Price;
            }

            

            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Book", new {id});
        }
    }
}
