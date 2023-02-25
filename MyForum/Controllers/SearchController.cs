using Microsoft.AspNetCore.Mvc;

namespace MyForum.Web.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
