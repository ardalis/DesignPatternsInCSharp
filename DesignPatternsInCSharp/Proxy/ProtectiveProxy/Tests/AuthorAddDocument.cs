using Xunit;

namespace DesignPatternsInCSharp.Proxy.ProtectiveProxy.Tests
{
    public class AuthorAddDocument
    {
        [Fact]
        public void AddsDocumentToAuthoredDocuments()
        {
            var author = new User { Role = Roles.Author };

            author.AddDocument(TestConstants.TEST_DOCUMENT_NAME, TestConstants.TEST_DOCUMENT_CONTENT);

            Assert.Contains(author.AuthoredDocuments, doc => doc.Name == TestConstants.TEST_DOCUMENT_NAME);
        }
    }
}
