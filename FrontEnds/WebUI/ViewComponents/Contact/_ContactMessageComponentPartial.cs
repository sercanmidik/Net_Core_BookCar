using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Contact
{
    public class _ContactMessageComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
