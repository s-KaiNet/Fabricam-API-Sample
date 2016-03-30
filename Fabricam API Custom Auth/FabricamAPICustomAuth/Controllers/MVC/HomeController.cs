using System.Web.Mvc;

namespace FabricamAPICustomAuth.Controllers.MVC
{
	public class HomeController : Controller
	{
		[Route]
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";

			return View();
		}
	}
}
