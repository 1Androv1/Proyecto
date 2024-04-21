namespace Dtos;

public class HttpLogDto
{     
    public string RequestMethod { get; set; } = null!;
    public string RequestPath { get; set; } = null!;
    public string? RequestHeaders { get; set; }
    public string? RequestBody { get; set; }
    public int ResponseStatusCode { get; set; }
    public string? ResponseHeaders { get; set; } = null!;
    public string ResponseBody { get; set; } = null!;
    public DateTime LoggedAt { get; set; }
}