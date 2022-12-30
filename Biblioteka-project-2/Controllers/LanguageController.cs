using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Biblioteka_project_2.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult Index(string language)
        {
            if (string.IsNullOrEmpty(language))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            }
            
            return View();
        }
    }
}
