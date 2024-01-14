using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayout
{
    public class _NavbarUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
