using Bar_rating.Models;
using Microsoft.AspNetCore.Mvc;
using Bar_rating.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Bar_rating.Controllers
{
    public class MemberController : Controller
    {
        //[Authorize(Roles = "Admin")]
        private readonly IData data;
        public MemberController(IData _data)
        {
            data = _data;
        }
        public IActionResult Index()
        {
            var list = data.GetAllMembers();
            return View(list);
        }
        public IActionResult Delete(string id)
        {
            bool isDeleted = data.DeleteMember(id);
            if(isDeleted)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
