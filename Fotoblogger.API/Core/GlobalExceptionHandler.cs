using FluentValidation;
using Fotoblogger.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fotoblogger.API.Core
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.ContentType = "applicaiton/json";
                object response = null;
                var statusCode = StatusCodes.Status500InternalServerError;
                var messageDetails = "";

                switch (ex)
                {
                    case UnauthorizedUseCaseException _:
                        statusCode = StatusCodes.Status403Forbidden;
                        response = new
                        {
                            message = "You are not allowed to execute this operation."
                        };
                        break; 

                    case WrongPasswordException _:
                        statusCode = StatusCodes.Status422UnprocessableEntity;

                        response = new
                        {
                            message = "Incorrect password."
                        };
                        break;

                    case NotAllowedException notAllowedException:
                        statusCode = StatusCodes.Status403Forbidden;

                        if (notAllowedException.getDetails() != "")
                            messageDetails += " Details: " + notAllowedException.getDetails();

                        response = new
                        {
                            message = "Only administrator/moderator can execute this operation on this specific resource." + messageDetails
                        };
                        break;

                    case ActionNotRepeatableException _:
                        statusCode = StatusCodes.Status409Conflict;
                        response = new
                        {
                            message = "You have already executed this operation on this specific resource. Action is not repeatable on same resource."
                        };
                        break;

                    case DependencyException dependencyException:
                        statusCode = StatusCodes.Status409Conflict;

                        if (dependencyException.getDetails() != "")
                            messageDetails += " Details: " + dependencyException.getDetails() ;

                        response = new
                        {
                            message = "Performing this operation on this specific resource would cause other resource to malfunction." + messageDetails
                        };
                        break;

                    case EntityNotFoundException _:
                        statusCode = StatusCodes.Status404NotFound;
                        response = new
                        {
                            message = "Resource not found."
                        };
                        break;

                    case ValidationException validationException:
                        statusCode = StatusCodes.Status422UnprocessableEntity;

                        response = new
                        {
                            message = "Failed due to validation errors.",
                            erros = validationException.Errors.Select(x => new
                            {
                                x.PropertyName,
                                x.ErrorMessage
                            })
                        };

                        break;
                }

                httpContext.Response.StatusCode = statusCode;

                if (response != null)
                {
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    return;
                }

                await Task.FromResult(httpContext.Response);
            }
        }
    }
}
