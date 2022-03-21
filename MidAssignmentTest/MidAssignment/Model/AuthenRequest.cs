using System.ComponentModel.DataAnnotations;

namespace MidAssignment.Model;

public class AuthenRequest {
    [Required]
    public string? Username {get;set;}
    [Required]
    public string? Password {get;set;}
}