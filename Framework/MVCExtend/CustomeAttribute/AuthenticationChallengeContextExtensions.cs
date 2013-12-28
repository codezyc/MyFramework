using MVCExtend.CustomeActionResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;

namespace MVCExtend.CustomeAttribute
{
    public static class AuthenticationChallengeContextExtensions
    {
        public static void ChallengeWith(this AuthenticationChallengeContext filterContext, string challenge)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            filterContext.Result = new AddChallengeOnUnauthorizedResult(challenge, filterContext.Result);
        }
    }
}