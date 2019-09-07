using Microsoft.AspNetCore.Mvc;

namespace SayHello.Web.Controllers
{
    public class SayHelloController : Controller
    {
        private readonly ILanguageCodeValidator languageCodeValidator;

        public SayHelloController(ILanguageCodeValidator languageCodeValidator)
        {
            this.languageCodeValidator = languageCodeValidator;
        }

        public IActionResult Index(string languageId)
        {
            var isValid = languageCodeValidator.Validate(languageId);
            return View();
        }
    }
}
