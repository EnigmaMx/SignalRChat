using Microsoft.AspNetCore.Mvc;

namespace EnigmaChat.SignalR.Server.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}