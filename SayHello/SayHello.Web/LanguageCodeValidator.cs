using SayHello.Web.Database;
using System.Linq;

namespace SayHello.Web
{
    public class LanguageCodeValidator : ILanguageCodeValidator
    {
        private readonly SayHelloDatabaseContext sayHelloDatabaseContext;

        public LanguageCodeValidator(SayHelloDatabaseContext sayHelloDatabaseContext)
        {
            this.sayHelloDatabaseContext = sayHelloDatabaseContext;
        }

        public bool Validate(string languageId)
        {
            return sayHelloDatabaseContext.Hellos.Any(h => h.ISO639LanguageId == languageId);
        }
    }
}
