using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Dtos;
using Microsoft.AspNetCore.Http;

namespace Helpers.Errors;

public static class HelperError
{
    public static ApiErrorDto GetErrorAndInnerError(Exception e)
    {
        var messageError = e.Message;
        
        var error = new ApiErrorDto()
        {
            Error = messageError + 
            (
                e.InnerException != null ? 
                " InnerException: " + e.InnerException.Message :
                ""
            ) + 
            (
                e.InnerException != null && e.InnerException.InnerException != null ? 
                " InnerException: " + e.InnerException.InnerException :
                ""
            )
        };

        return error;
    }
    
    public static string GetInnerExceptionString(Exception e)
    {
        return e.InnerException != null ? "InnerException: " + e.InnerException.Message : e.Message;
    }
    
    public static ApiBadRequestDto GetErrorAndInnerWithCode(Exception e, string glpsCode)
    {
        var messageError = e.Message;
        
        var message = new ApiBadRequestDto()
        {
            Message = glpsCode + ": " + messageError + (
                e.InnerException != null ? 
                " InnerException: " + e.InnerException.Message :
                ""
            )
        };

        return message;
    }
    
    public static ApiBadRequestDto BadRequestMessageWithCode(string errorMessage, string glpsCode)
    {
        var message = new ApiBadRequestDto()
        {
            Message = glpsCode + ": " + errorMessage
        };

        return message;
    }

    public static ValidationProblemDetailsDto BadRequestValidation(string fieldName, string message,  HttpContext httpContext)
    {
        var badRequest = new Dictionary<string, string[]>
        {
            { fieldName, [message] }
        };
        
        var validation = new ValidationProblemDetailsDto()
        {
            Errors = badRequest,
            TraceId = Activity.Current?.Id ?? httpContext.TraceIdentifier
        };
        
        return validation;
    }
    
    public static ValidationProblemDetailsDto BadRequestModelState(ModelStateDictionary modelState)
    {
        var errors = new Dictionary<string, string[]>();

        foreach (var (key, value) in modelState)
        {
            if (value.Errors.Count <= 0) continue;
            
            foreach (var error in value.Errors)
            {
                errors.Add(key, [error.ErrorMessage]);
            }
        }
        
        var validation = new ValidationProblemDetailsDto()
        {
            Errors = errors
        };
        
        return validation;
    }
    
    public static string GetErrorAndInnerErrorString(Exception e)
    {
        return e.Message + (
            e.InnerException != null ? " InnerException: " + e.InnerException.Message : ""
        );
    }
}