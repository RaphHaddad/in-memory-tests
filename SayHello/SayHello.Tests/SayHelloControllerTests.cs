using Xunit;
using SayHello.Web.Controllers;
using SayHello.Web;
using NSubstitute;
using SayHello.Web.Database;

namespace SayHello.Tests
{
    public class SayHelloControllerTests
    {
        private readonly ILanguageCodeValidator languageCodeValidator;
        private readonly IHelloRepository hellosRepository;
        private readonly SayHelloController controller;

        public SayHelloControllerTests()
        {
            languageCodeValidator = Substitute.For<ILanguageCodeValidator>();
            hellosRepository = Substitute.For<IHelloRepository>();
            controller = new SayHelloController(languageCodeValidator, hellosRepository);
        }

        [Fact]
        public void DoesCallHellosRepositoryIfValid()
        {
            var language = "eng";

            languageCodeValidator
                .Validate(Arg.Any<string>())
                .Returns(true);
            hellosRepository
                .GetHello(language)
                .Returns(new Hello());

            controller.Index(language);

            hellosRepository
                .Received(1)
                .GetHello(language);
        }
    }
}
