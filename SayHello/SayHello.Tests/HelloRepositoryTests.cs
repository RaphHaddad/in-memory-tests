using SayHello.Web;
using Xunit;
using SayHello.Web.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace SayHello.Tests
{
    public class HelloRepositoryTests : IDisposable
    {
        private readonly SayHelloDatabaseContext dbContext;
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public HelloRepositoryTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<SayHelloDatabaseContext>().UseInMemoryDatabase("inmemory")
                                            .Options;

            dbContext = new SayHelloDatabaseContext(dbContextOptions);
        }

        [Fact]
        public void ShouldSeedEnglishHelloOnDatabase()
        {
            var helloRepository = new HelloRepository(dbContext);

            var helloInEnglish = helloRepository.GetHello("eng");

            Assert.Equal("Hello", helloInEnglish.HelloText);
            Assert.Equal("English", helloInEnglish.LanguageName);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                dbContext.Database.EnsureDeleted();
            }

            disposed = true;
        }
    }
}
