using System;
using System.Linq;
using SayHello.Web.Database;

namespace SayHello.Web
{
    public class HelloRepository : IHelloRepository
    {
        private readonly SayHelloDatabaseContext sayHelloDatabaseContext;

        public HelloRepository(SayHelloDatabaseContext sayHelloDatabaseContext)
        {
            this.sayHelloDatabaseContext = sayHelloDatabaseContext;
        }

        public Hello GetHello(string languageId)
        {
            return sayHelloDatabaseContext.Hellos
                        .Where(hello => hello.ISO639LanguageId == languageId)
                        .First();
        }
    }
}
