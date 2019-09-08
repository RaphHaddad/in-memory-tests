using SayHello.Web.Database;

namespace SayHello.Web
{
    public interface IHelloRepository
    {
        Hello GetHello(string languageId);
    }
}