using System;
using Xunit;

namespace DesignPatternsInCSharp.Proxy.ProtectiveProxy.Tests
{
    public class EditorReviewDocument
    {
        [Fact]
        public void SetsDateReviewedToCurrentDateTime()
        {
            var editor = new User { Role = Roles.Editor };
            var document = Document.CreateDocument("test name", "test content");

            document.CompleteReview(editor);

            Assert.True(DateTime.UtcNow - document.DateReviewed < TimeSpan.FromMilliseconds(500));
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
