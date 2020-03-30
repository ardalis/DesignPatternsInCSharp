using System;
using Xunit;

namespace DesignPatternsInCSharp.Proxy.ProtectiveProxy.Tests
{
    public class DocumentUpdateName
    {
        [Fact]
        public void UpdatesNameGivenUserInAuthorRole()
        {
            var author = new User { Role = Roles.Author };
            var document = new Document("test name", "test content");

            document.UpdateName("new name", author);

            Assert.Equal("new name", document.Name);
        }

        [Fact]
        public void ThrowsUnauthorizedExceptionGivenUserNotInAuthorRole()
        {
            var editor = new User { Role = Roles.Editor };
            var document = new ProtectedDocument("test name", "test content");

            Assert.Throws<UnauthorizedAccessException>(() => document.UpdateName("new name", editor));
        }
    }



    // Author can create a new document
    // Author can update the name of the document, modify its content, and assign initial tags
    // Author can submit document for review by an Editor
    // Editor can edit tags
    // Editor can mark the document reviewed (sets DateReviewed)
    // Editor cannot modify Name or Content directly
    // Maybe add Admin who can do anything (later)
}
