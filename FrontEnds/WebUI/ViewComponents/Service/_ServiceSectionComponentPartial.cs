using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Service
{
    public class _ServiceSectionComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
