using Xunit;

namespace DesignPatternsInCSharp.Proxy.ProtectiveProxy.Tests
{
    public class AuthorAddDocument
    {
        [Fact]
        public void AddsDocumentToAuthoredDocuments()
        {
            var author = new User { Role = Roles.Author };

            author.AddDocument("test name", "test content");

            Assert.Contains(author.AuthoredDocuments, doc => doc.Name == "test name");
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
