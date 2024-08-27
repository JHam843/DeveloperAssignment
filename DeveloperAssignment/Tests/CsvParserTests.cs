using DeveloperAssignment.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeveloperAssignment.Tests
{
    [TestClass]
    public class CsvParserTests
    {
        [TestMethod]
        public void RemoveQuote_ShouldRemoveQuotes()
        {
            Assert.AreEqual("hello", "\"hello\"".RemoveQuote());
            Assert.AreEqual("world", "world\"".RemoveQuote());
            Assert.AreEqual("test", "\"test".RemoveQuote());
            Assert.AreEqual("", "".RemoveQuote());
            Assert.AreEqual("example", "example".RemoveQuote());
        }
    }
}
