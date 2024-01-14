using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.About
{
	public class _BecomeDriverComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
