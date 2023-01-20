using Biblioteka_project_2.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Biblioteka_project_2.Controllers
{
    public class LanguageController:Controller
    {
        private readonly IStringLocalizer<SharedResource> _sharedResourceLocalizer;

        public LanguageController(IStringLocalizer<SharedResource> sharedResourceLocalizer)
        {
            _sharedResourceLocalizer = sharedResourceLocalizer;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
