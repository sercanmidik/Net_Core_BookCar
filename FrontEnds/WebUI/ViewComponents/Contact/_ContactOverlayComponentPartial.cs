﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Contact
{
    public class _ContactOverlayComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
