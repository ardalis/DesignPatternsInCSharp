using System;
using System.Collections.Generic;

namespace DesignPatternsInCSharp.Proxy.ProtectiveProxy
{
    public class Document
    {
        public static Document CreateDocument(string name, string content)
        {
            return new ProtectedDocument(name, content);
        }

        protected Document(string name, string content)
        {
            Name = name;
            Content = content;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<string> Tags { get; private set; }
        public string Content { get; private set; }
        public DateTime DateCreated { get; private set; } = DateTime.UtcNow;
        public DateTime? DateReviewed { get; private set; }

        internal virtual void CompleteReview(User editor)
        {
            DateReviewed = DateTime.UtcNow;
        }

        internal virtual void UpdateName(string newName, User user)
        {
            Name = newName;
        }
    }
}
