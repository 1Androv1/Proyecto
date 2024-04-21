using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Dtos.Returns;

public class BasicReturnCreatedDto
{
    [DefaultValue("Saved successfully.")] 
    [JsonPropertyName("message")]
    public string Message { get; set; } = "Saved successfully.";
}