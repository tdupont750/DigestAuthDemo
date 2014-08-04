using System;

namespace DigestAuthDemo.Http
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class BasicAuthorizationFilterAttribute : BasicAuthorizationFilterAttributeBase
    {
        public BasicAuthorizationFilterAttribute(bool issueChallenge = true) 
            : base(issueChallenge)
        {
        }

        protected override bool IsUserAuthorized(string userName)
        {
            return true;
        }

        protected override bool IsPasswordValid(string userName, string password)
        {
            return userName == password;
        }
    }
}