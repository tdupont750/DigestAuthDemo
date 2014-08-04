using System;

namespace DigestAuthDemo.Http
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class DigestAuthorizationFilterAttribute : DigestAuthorizationFilterAttributeBase
    {
        public DigestAuthorizationFilterAttribute(bool issueChallenge = true) : base(issueChallenge)
        {
        }

        protected override bool IsUserAuthorized(string userName)
        {
            return true;
        }

        protected override string GetPassword(string userName)
        {
            return userName;
        }
    }
}