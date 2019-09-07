using System.ComponentModel.DataAnnotations;

namespace SayHello.Web.Database
{
    public class Hello
    {
        [Key]
        public string ISO639LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string HelloText { get; set; }
    }
}