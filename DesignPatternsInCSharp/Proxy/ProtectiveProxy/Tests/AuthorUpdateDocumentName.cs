using System;
using Xunit;

namespace DesignPatternsInCSharp.Proxy.ProtectiveProxy.Tests
{
    public class AuthorUpdateDocumentName
    {
        [Fact]
        public void UpdatesNameGivenUserInAuthorRole()
        {
            var author = new User { Role = Roles.Author };
            var document = Document.CreateDocument(TestConstants.TEST_DOCUMENT_NAME, TestConstants.TEST_DOCUMENT_CONTENT);

            string newName = "new name";
            document.UpdateName(newName, author);

            Assert.Equal(newName, document.Name);
        }

        [Fact]
        public void ThrowsUnauthorizedExceptionGivenUserNotInAuthorRole()
        {
            var editor = new User { Role = Roles.Editor };
            var document = new ProtectedDocument(TestConstants.TEST_DOCUMENT_NAME, TestConstants.TEST_DOCUMENT_CONTENT);

            Assert.Throws<UnauthorizedAccessException>(() => document.UpdateName(TestConstants.TEST_DOCUMENT_NAME, editor));
        }
    }
}
