using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Car
{
    public class _CarSectionComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
