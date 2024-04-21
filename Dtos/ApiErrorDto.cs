using System.ComponentModel;

namespace Dtos;

public class ApiErrorDto
{
    [DefaultValue("A problem occurred on the server.")]
    public string? Error { get; set; }
}