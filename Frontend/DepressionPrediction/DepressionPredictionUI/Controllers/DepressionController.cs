using Microsoft.AspNetCore.Mvc;

namespace DepressionPredictionUI.Controllers
{
    public class DepressionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
