using System;
using Xunit;

namespace DesignPatternsInCSharp.Proxy.ProtectiveProxy.Tests
{
    public class AuthorReviewDocument
    {
        [Fact]
        public void ThrowsUnauthorizedExceptionAndDoesNotSetDateReviewed()
        {
            var author = new User { Role = Roles.Author };
            var document = Document.CreateDocument("test name", "test content");

            Assert.Throws<UnauthorizedAccessException>(() => document.CompleteReview(author));
            Assert.Null(document.DateReviewed);
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
