using System.ComponentModel.DataAnnotations;

namespace MidAssignment.Entities;

public class Category 
{

    [Key]
    public int Id {get;set; }
    [Required, MaxLength(50)]
    public string? Name{get;set;}
    [Required, MaxLength(50)]

    public string? Description{get;set;}

    public ICollection<Book>? Books {get;set;}

}