using Microsoft.AspNetCore.Mvc;

namespace SayHello.Web.Controllers
{
    public class SayHelloController : Controller
    {
        private readonly ILanguageCodeValidator languageCodeValidator;
        private readonly IHelloRepository hellosRepository;

        public SayHelloController(ILanguageCodeValidator languageCodeValidator,
            IHelloRepository hellosRepository)
        {
            this.languageCodeValidator = languageCodeValidator;
            this.hellosRepository = hellosRepository;
        }

        [Route("SayHello/{languageId}")]
        public IActionResult Index(string languageId)
        {
            var isValid = languageCodeValidator.Validate(languageId);

            if (!isValid)
            {
                return View("UserError", languageId);
            }

            var hello = hellosRepository.GetHello(languageId);

            return View(nameof(Index), hello.HelloText);
        }
    }
}
