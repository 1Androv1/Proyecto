using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Interfaces;
using Dtos;
using Models;
using Helpers.Objects;

namespace Middlewares;

public class HttpLoggingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, IHttpLoggingService httpLoggingService)
    {
        var request = context.Request;
        var response = context.Response;
        var originalBodyStream = response.Body;
        var httpLogDto = new HttpLogDto();

        try
        {
            request.EnableBuffering();

            httpLogDto.RequestMethod = request.Method;
            httpLogDto.RequestPath = request.Path;
            httpLogDto.RequestHeaders = JsonSerializer.Serialize(request.Headers);
            httpLogDto.RequestBody = await new StreamReader(request.Body).ReadToEndAsync();

            request.Body.Seek(0, SeekOrigin.Begin);

            using (var responseBody = new MemoryStream())
            {
                response.Body = responseBody;

                await next(context);

                response.Body.Seek(0, SeekOrigin.Begin);

                httpLogDto.ResponseStatusCode = response.StatusCode;
                httpLogDto.ResponseHeaders = JsonSerializer.Serialize(response.Headers);
                httpLogDto.ResponseBody = await new StreamReader(response.Body).ReadToEndAsync();
                httpLogDto.LoggedAt = DateTime.UtcNow;

                response.Body.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }
        finally
        {
            response.Body = originalBodyStream;
            var httpLog = httpLogDto.ConvertDtoToModel<HttpLogDto, HttpLog>();
            await httpLoggingService.LogHttpRequestResponse(httpLog);
        }
    }
}