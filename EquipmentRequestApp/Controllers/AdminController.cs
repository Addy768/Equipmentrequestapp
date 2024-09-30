using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EquipmentRequestApp.Models;
using System.Collections.Generic;

namespace EquipmentRequestApp.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public static List<Request> Requests => HomeController.requests;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

       
        [HttpGet("Requests")]
        public IActionResult RequestsList()
        {
            return View(Requests);
        }

        
        [HttpPost("Accept/{id}")]
        public IActionResult AcceptRequest(int id)
        {
            var request = Requests.Find(r => r.Id == id);
            if (request != null)
            {
                request.Status = RequestStatus.Accepted; 
            }
            return RedirectToAction("RequestsList");
        }

        
        [HttpPost("Deny/{id}")]
        public IActionResult DenyRequest(int id)
        {
            var request = Requests.Find(r => r.Id == id);
            if (request != null)
            {
                request.Status = RequestStatus.Denied; 
            }
            return RedirectToAction("RequestsList");
        }
    }
}
