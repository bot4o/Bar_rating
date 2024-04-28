using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Bar_rating.Controllers
{
    public class RatingController : Controller
    {
        //[Authorize(Roles = "Member")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
