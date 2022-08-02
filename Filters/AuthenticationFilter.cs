
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMVC.Filters
{

    public class AuthenticationFilter : ActionFilterAttribute
    {


        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Session.TryGetValue("Email", out byte[] email);
            if (email == null)
            {
                context.Result = new RedirectToRouteResult(
                                new RouteValueDictionary {
                                { "Controller", "User" },
                                { "Action", "Login" }
                                });
            }

        }
    }
}
