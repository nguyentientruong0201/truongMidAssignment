using System.Net.Sockets;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MidAssignment.Entities;

public class BookBorrowingRequest : BaseEntity 
{
    [Required]
    public int RequestByUserId {get;set;}
    public virtual User? RequestedBy {get;set;}
    
    public int? ProcessedByUserId {get;set;}
    public virtual User? ProcesseddBy {get;set;}

[Required, DefaultValue(RequestStatus.Waiting)]
    public RequestStatus Status{get;set;}

    public ICollection<BookBorrowingRequestDetails>? Details {get;set;}


}