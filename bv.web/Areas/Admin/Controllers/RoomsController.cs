using Microsoft.AspNetCore.Mvc;
using Hospital.Services;
using cloudscribe.Pagination.Models;
using Hospital.ViewModels;

namespace bv.web.Areas.Admin.Controllers
{
   
    [Area("admin")]
    public class RoomController : Controller
    {
        
        private IRoomService _room;
        private IHospitalInfo _hospitalInfo;
     
        public RoomController(IRoomService room, IHospitalInfo hospitalInfo)
        {
            _room = room;
            _hospitalInfo = hospitalInfo;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_room.GetAll(pageNumber,pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            var viewModel = _room.GetRoomById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(RoomViewModels vm) 
        {
            _room.UpdateRoom(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RoomViewModels vm)
        {
            _room.InsertRoom(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _room.DeleteRoom(id);
            return RedirectToAction("Index");
        }
    }
}
