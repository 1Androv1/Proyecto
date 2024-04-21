using System.ComponentModel;

namespace Dtos;

public class ValidationProblemDetailsDto
{
    [DefaultValue("https://tools.ietf.org/html/rfc9110#section-15.5.1")]
    public string Type { get; set; } = "https://tools.ietf.org/html/rfc9110#section-15.5.1";

    [DefaultValue("One or more validation errors occurred.")]
    public string Title { get; set; } = "One or more validation errors occurred.";

    [DefaultValue(400)]
    public int Status { get; set; } = 400;

    public string TraceId { get; set; } = string.Empty;

    public Dictionary<string, string[]> Errors { get; set; } = new();
}