using Microsoft.AspNetCore.Mvc;

namespace OpenAIWeb3.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
