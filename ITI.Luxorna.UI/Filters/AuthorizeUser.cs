using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace ITI.Luxorna.UI
{
    public class AuthorizeUser : AuthorizationFilterAttribute
    {
        public string Roles { get; set; }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string jwt_token = actionContext.Request.Headers.Authorization?.Parameter;
            if (string.IsNullOrEmpty(jwt_token))
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized, "Not Authorized");
                return;
            }
            Dictionary<string, string>
                cliams = SecurityHelper.Validate(jwt_token);
            if (cliams == null)
            {
                actionContext.Response = actionContext.Request
                   .CreateResponse(HttpStatusCode.Unauthorized, "Not Authorized");
                return;
            }
            string roles = cliams.First(i => i.Key == "Roles").Value;

            string[] userRoles = roles.Split(new char[] { ',' });
            string[] requiredRoles = Roles.Split(new char[] { ',' });
            if (!requiredRoles.Intersect(userRoles).Any())
            {
                actionContext.Response
                    = actionContext.Request.CreateResponse
                    (HttpStatusCode.Unauthorized, "Not Authorized");
                return;
            }


        }
    }
}