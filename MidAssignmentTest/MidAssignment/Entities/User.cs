using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MidAssignment.Entities;

public class User : BaseEntity 
{
    [Required, MaxLength(50)]
    public string? Username {get;set;}
    [Required, MaxLength(50)]

    public string? Password {get;set;}
    [Required, MaxLength(50)]
    public string? FirstName {get;set;}
    [Required, MaxLength(50)]

    public string? LastName {get;set;}

    public ICollection<BookBorrowingRequest>? BookBorrowingRequests {get;set;}

    public ICollection<BookBorrowingRequest>? ProcessedRequests {get;set;}





}