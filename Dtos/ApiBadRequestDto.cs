using System.ComponentModel;

namespace Dtos;

public class ApiBadRequestDto
{
    [DefaultValue("We have a bad request.")]
    public string? Message { get; set; }
}