﻿using Entities.LogModel;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ActionFilters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private readonly ILoggerService _logger;

        public LogFilterAttribute(ILoggerService loggerService)
        {
            _logger = loggerService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInfo(Log("OnActionExecuting", context.RouteData));
        }

        private string Log(string modelName, RouteData routeData)
        {
            var logDeails = new LogDetails()
            {
                ModelName = modelName,
                Controller = routeData.Values["controller"],
                Action = routeData.Values["action"]
            };

            if (routeData.Values.Count >= 3)
                logDeails.Id = routeData.Values["Id"];

            return logDeails.ToString();
        }
    }
}
