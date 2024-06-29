using Microsoft.AspNetCore.Mvc;
using Hospital.Services;

namespace bv.web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UsersController : Controller
    {
        private IApplicationUserService _userService;

        public UsersController(IApplicationUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int PadeNumber = 1, int PageSize = 10)
        {
            return View(_userService.GetAll(PadeNumber, PageSize));
        }
        public IActionResult AllDoctors(int PadeNumber = 1, int PageSize = 10)
        {
            return View(_userService.GetAllDoctor(PadeNumber, PageSize));
        }
    }
}
