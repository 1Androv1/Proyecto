using System.ComponentModel.DataAnnotations;

namespace Models;

public class HttpLog
{
    [Key]
    public int Id { get; set; }

    [MaxLength(5)] 
    public string RequestMethod { get; set; } = null!;

    [MaxLength(200)] 
    public string RequestPath { get; set; } = null!;

    [MaxLength(Int16.MaxValue)] 
    public string? RequestHeaders { get; set; }
    
    [MaxLength(Int16.MaxValue)]
    public string? RequestBody { get; set; }
    
    public int ResponseStatusCode { get; set; }

    [MaxLength(Int16.MaxValue)] 
    public string? ResponseHeaders { get; set; } = null!;

    [MaxLength(Int16.MaxValue)] 
    public string ResponseBody { get; set; } = null!;
    
    public DateTime LoggedAt { get; set; }
}