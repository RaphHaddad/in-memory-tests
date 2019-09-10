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
            var hello = hellosRepository.GetHello(languageId);

            if (hello == null)
            {
                return View("UserError", languageId);
            }

            return View(nameof(Index), hello);
        }
    }
}
