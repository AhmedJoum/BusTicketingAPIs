using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AdeelaAPI.Filters
{
    public class UserAuthorizeAttribute : AuthorizationFilterAttribute
    {
        private readonly AdeelaEntities Context = new AdeelaEntities();

        private readonly object NotValidEmpObj = new { Status = -1, ErrorMsg = "User Have no valid token key." };
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                string actionName = actionContext.ActionDescriptor.ActionName;
                if (actionName.Equals("Login"))
                    return;


                if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
                    return;

                var authHeader = actionContext.Request.Headers.Authorization;
                if (authHeader != null)
                {
                    if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!string.IsNullOrWhiteSpace(authHeader.Parameter))
                        {
                            var TokenKey = authHeader.Parameter;
                            int? UserID = Context.TokenManagerSelectByToken(Guid.Parse(TokenKey)).First();

                            if (UserID != 0)
                            {
                                var principal = new GenericPrincipal(new GenericIdentity(UserID.ToString()), null);
                                Thread.CurrentPrincipal = principal;
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                //  throw ex;
#endif
            }


            HandleUnauthorized(actionContext);
        }

        void HandleUnauthorized(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, NotValidEmpObj);
            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic Scheme='HrApi' location='User/login'");
        }
    }
}