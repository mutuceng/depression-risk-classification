using Microsoft.AspNetCore.Mvc;

namespace DepressionPredictionUI.Controllers
{
    public class NoDepressionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
