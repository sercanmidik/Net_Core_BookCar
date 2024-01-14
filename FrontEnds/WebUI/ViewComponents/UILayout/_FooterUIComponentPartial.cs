using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayout
{
    public class _FooterUIComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
