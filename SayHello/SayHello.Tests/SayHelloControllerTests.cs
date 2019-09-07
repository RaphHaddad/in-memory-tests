using System;
using Xunit;
using SayHello.Web.Controllers;
using SayHello.Web;
using NSubstitute;

namespace SayHello.Tests
{
    public class SayHelloControllerTests
    {
        [Fact]
        public void DoesValidateLanguageId()
        {
            var language = "eng";
            var languageCodeValidator = Substitute.For<ILanguageCodeValidator>();
            var controller = new SayHelloController(languageCodeValidator);

            controller.Index(language);

            languageCodeValidator
                .Received(1)
                .Validate(language);
        }
    }
}
