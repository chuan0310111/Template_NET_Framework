using _0.Template_NET_Framework.Common.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Unity;

namespace _1.Template_NET_Framework.Application.WebApi.Filters
{
    public class TimeLogAttribute : ActionFilterAttribute
    {
        private readonly Stopwatch _stopwatch;

        public TimeLogAttribute() { 

            this._stopwatch = new Stopwatch();
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            this._stopwatch.Start();
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var logger = UnityConfig.Container.Resolve<ILogger>();

            var controllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
            this._stopwatch.Stop();
            var ts = this._stopwatch.Elapsed;
            this._stopwatch.Reset();
            logger.Info($"ApiTimer: {ts.ToString()} from  {controllerName}/{actionName}", 
                new Dictionary<string, object>() {{ "spent", ts.TotalSeconds }}); 

            base.OnActionExecuted(actionExecutedContext);  
        }
    }
}