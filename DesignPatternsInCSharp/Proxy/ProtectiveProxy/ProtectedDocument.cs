using System;

namespace DesignPatternsInCSharp.Proxy.ProtectiveProxy
{
    public class ProtectedDocument : Document
    {
        public ProtectedDocument(string name, string content) : base(name, content)
        {
        }

        public override void UpdateName(string newName, User user)
        {
            if(user.Role != Roles.Author)
            {
                throw new UnauthorizedAccessException("Cannot update name unless in Author role.");
            }
            base.UpdateName(newName, user);
        }
    }
}
