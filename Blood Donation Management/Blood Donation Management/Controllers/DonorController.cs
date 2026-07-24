using Microsoft.AspNetCore.Mvc;

namespace Blood_Donation_Management.Controllers
{
    public class DonorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
