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
            var document = Document.CreateDocument(TestConstants.TEST_DOCUMENT_NAME, TestConstants.TEST_DOCUMENT_CONTENT);

            document.CompleteReview(editor);

            Assert.True(DateTime.UtcNow - document.DateReviewed < TimeSpan.FromMilliseconds(500));
        }
    }
}
