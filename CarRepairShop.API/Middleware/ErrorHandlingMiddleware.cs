using CarRepairShop.Application.Common.Responses;
using FluentValidation;
using System.Net;
using System.Security.Authentication;
using System.Text.Json;

namespace CarRepairShop.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (UnauthorizedAccessException ex)
            {
                await WriteErrorResponse(context, new List<string> { ex.Message }, HttpStatusCode.Unauthorized);
            }
            catch (AuthenticationException ex)
            {
                await WriteErrorResponse(context, new List<string> { ex.Message }, HttpStatusCode.Forbidden);
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    await WriteErrorResponse(context, new List<string> { ex.Message }, HttpStatusCode.NotFound);
                }
            }
            catch (ValidationException ex)
            {
                var errors = new List<string>();
                errors.AddRange(ex.Errors.Select(x => x.ErrorMessage));
                await WriteErrorResponse(context, errors, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                await WriteErrorResponse(context, new List<string> { ex.Message }, HttpStatusCode.InternalServerError);
            }
        }

        private static async Task WriteErrorResponse(HttpContext context, List<string> errors, HttpStatusCode statusCode)
        {
            var errorViewModel = new BaseResponse() { Errors = errors };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var result = JsonSerializer.Serialize(errorViewModel, jsonSerializerOptions);
            await context.Response.WriteAsync(result);
        }
    }
}