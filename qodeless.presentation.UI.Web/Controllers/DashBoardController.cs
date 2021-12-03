using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace qodeless.presentation.UI.Web.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        }
}