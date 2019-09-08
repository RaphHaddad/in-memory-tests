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
        public void DoesValidateLanguageId()
        {
            var language = "eng";

            controller.Index(language);

            languageCodeValidator
                .Received(1)
                .Validate(language);
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

        [Fact]
        public void DoesNotCallHellosRepositoryIfValid()
        {
            var language = "eng";

            languageCodeValidator
                .Validate(Arg.Any<string>())
                .Returns(false);

            controller.Index(language);

            hellosRepository
                .DidNotReceive()
                .GetHello(language);
        }
    }
}
