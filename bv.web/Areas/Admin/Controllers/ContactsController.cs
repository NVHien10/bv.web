using Microsoft.AspNetCore.Mvc;
using Hospital.Services;
using cloudscribe.Pagination.Models;
using Hospital.ViewModels;

namespace bv.web.Areas.Admin.Controllers
{
   
    [Area("admin")]
    public class ContactController : Controller
    {
        
        private IContactService _contact;
        private IHospitalInfo _hospitalInfo;
     
        public ContactController(IContactService contact, IHospitalInfo hospitalInfo)
        {
            _contact = contact;
            _hospitalInfo = hospitalInfo;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_contact.GetAll(pageNumber,pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            var viewModel = _contact.GetContactById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(ContactViewModel vm) 
        {
            _contact.UpdateContact(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ContactViewModel vm)
        {
            _contact.InsertContact(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _contact.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}
