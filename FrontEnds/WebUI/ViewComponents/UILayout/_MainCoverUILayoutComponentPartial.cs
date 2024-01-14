using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayout
{
    public class _MainCoverUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
