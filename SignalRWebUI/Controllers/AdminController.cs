using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
