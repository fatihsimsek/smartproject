using System;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using SmartProject.Api.ActionResults;

namespace SmartProject.Api.Middleware
{
	public class ExceptionHandlerMiddleware
	{
		private readonly ILogger<ExceptionHandlerMiddleware> _logger;
		private readonly RequestDelegate _next;

		public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
		{
			_logger = logger;
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch(Exception exp)
			{
				_logger.LogError(exp.Message, exp);
				await HandleExceptionAsync(context, exp);
			}
		}

        private async Task HandleExceptionAsync(HttpContext context, Exception exp)
        {
			context.Response.ContentType = MediaTypeNames.Application.Json;
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			var response = Envelope.Create(exp.Message, HttpStatusCode.InternalServerError);
			await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}

