using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MidAssignment.Entities;

public class Book: BaseEntity 
{
    [Required, MaxLength(50)]
    public string? Name{get;set;}
    [Required, MaxLength(50)]

    public string? Author{get;set;}
    public string? Summary{get;set;}
   [Required]
    public int CategoryId {get;set;}
    public virtual Category? Category {get;set;}

    public ICollection<BookBorrowingRequestDetails>? Details {get;set;}



}