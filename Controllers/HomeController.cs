using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR_Demo.Models;
using SignalR_Demo.SignalR;
using System.Diagnostics;

namespace SignalR_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ChatHub _chatHub;

        public HomeController(ILogger<HomeController> logger,ChatHub chatHub)
        {
            _logger = logger;
            _chatHub = chatHub;
           
        }

        public IActionResult Index()
        {
            return View();
        }

 
        [HttpPost]
        public async Task<bool> testAsync()
        {
           await _chatHub.SendMessage("test","QQ");
           return true;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}