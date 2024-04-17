
using Engine.Procedures;
using Xunit;

namespace Engine.Tests.Unit
{
    public class IndexTest
    {
        [Fact]
        public void Test()
        {
            Assert.Equal("1", new IndexId().Next().Value());
            Assert.Equal("2", new IndexId().Next().Next().Value());
            Assert.Equal("1.1", new IndexId().Next().Down().Value());
            Assert.Equal("1.2", new IndexId().Next().Down().Next().Value());
            Assert.Equal("1", new IndexId().Next().Down().Next().Up().Value());
        }
    }
}
