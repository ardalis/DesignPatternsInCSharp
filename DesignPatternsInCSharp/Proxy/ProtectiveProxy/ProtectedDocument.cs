using System;

namespace DesignPatternsInCSharp.Proxy.ProtectiveProxy
{
    public class ProtectedDocument : Document
    {
        public ProtectedDocument(string name, string content) : base(name, content)
        {
        }

        internal override void UpdateName(string newName, User user)
        {
            if(user.Role != Roles.Author)
            {
                throw new UnauthorizedAccessException("Cannot update name unless in Author role.");
            }
            base.UpdateName(newName, user);
        }

        internal override void CompleteReview(User editor)
        {
            if (editor.Role != Roles.Editor)
            {
                throw new UnauthorizedAccessException("Cannot review documents unless you are an Editor.");
            }
            base.CompleteReview(editor);
        }
    }
}
