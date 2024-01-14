using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayout
{
    public class _HeaderUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
