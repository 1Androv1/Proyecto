using Models;

namespace Interfaces;

public interface IHttpLoggingService
{
    Task LogHttpRequestResponse(HttpLog httpLog);
}