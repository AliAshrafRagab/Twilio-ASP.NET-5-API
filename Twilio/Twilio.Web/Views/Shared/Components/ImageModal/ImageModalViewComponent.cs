using Microsoft.AspNetCore.Mvc;

namespace Twilio.Web.Views.Shared.Components.ImageModal
{
    public class ImageModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}