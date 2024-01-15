using Microsoft.AspNetCore.Mvc;

namespace Shop.YandexKassa.Areas.YandexKassa.Controllers
{
    [Area("YandexKassa")]
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        
        //  /Yandex.Kassa/Home/Callback
        public IActionResult Callback()
        {
            return View();
        }
    }
}
