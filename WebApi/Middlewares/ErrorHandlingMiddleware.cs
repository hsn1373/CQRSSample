﻿using Application.Exceptions;
using Application.Models;
using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                Error error = new();

                switch(ex)
                {
                    case CustomValidationException validationException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        error.FriendlyMessage = validationException.FriendlyErrorMessage;
                        error.ErrorMessages = validationException.ErrorMessages;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        error.FriendlyMessage = ex.Message;
                        break;
                }
                var result = JsonSerializer.Serialize(error);
                await response.WriteAsync(result);
            }
        }
    }
}
