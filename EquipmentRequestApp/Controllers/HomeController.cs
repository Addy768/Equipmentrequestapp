using Microsoft.AspNetCore.Mvc;
using EquipmentRequestApp.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace EquipmentRequestApp.Controllers
{
    public class HomeController : Controller
    {
        
        public static List<Request> requests = new List<Request>();

        
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet("Home/AllEquipment")]
        public IActionResult AllEquipment()
        {
            var equipmentList = GetMockEquipment();
            return View(equipmentList);
        }

        
        [HttpGet("Home/AvailableEquipment")]
        public IActionResult AvailableEquipment()
        {
            var equipmentList = GetMockEquipment().FindAll(e => e.IsAvailable);
            return View(equipmentList);
        }

        
        [HttpGet("Home/RequestForm")]
        public IActionResult RequestForm()
        {
            return View();
        }

     
        [HttpPost("Home/RequestForm")]
        public IActionResult SubmitRequest(Request model)
        {
            if (ModelState.IsValid)
            {
                model.Id = requests.Count + 1;
                model.Status = RequestStatus.Pending; 
                requests.Add(model);
                return RedirectToAction("Confirmation");
            }
            return View("RequestForm", model);
        }

      
        public IActionResult Confirmation()
        {
            return View();
        }


        [HttpGet("Home/Requests")]
        public IActionResult Requests()
        {
            return View(requests); 
        }

       
        private List<Equipment> GetMockEquipment()
        {
            return new List<Equipment>
            {
                new Equipment { Id = 1, Type = EquipmentType.Laptop, Description = "Dell XPS 13", IsAvailable = true },
                new Equipment { Id = 2, Type = EquipmentType.Phone, Description = "iPhone 13", IsAvailable = false },
                new Equipment { Id = 3, Type = EquipmentType.Tablet, Description = "iPad Pro", IsAvailable = true }
            };
        }
    }
}
