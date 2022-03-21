using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MidAssignment.Entities;

public class BookBorrowingRequestDetails 
{
    [Required]
    public int BookBorrowingRequestId {get;set;}
    public virtual BookBorrowingRequest? BookBorrowingRequest {get;set;}
    [Required]
    public int BookId {get;set;}
    public virtual Book? Book {get;set;}


}