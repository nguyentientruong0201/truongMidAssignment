using Microsoft.EntityFrameworkCore;
using MidAssignment.Entities;

public class MyDbContext : DbContext {
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    { 
        //book
        builder.Entity<User>(e=>e.ToTable("User"));
        //category
        builder.Entity<Category>(e=>e.ToTable("Category"));
        builder.Entity<Book>()
        .HasOne(b=>b.Category)
        .WithMany(c=>c.Books)
        .HasForeignKey(b=>b.CategoryId)
        .IsRequired();

        //BookBorrowingRequest
        builder.Entity<BookBorrowingRequest>(e=>e.ToTable("BookBorrowingRequest"));
        builder.Entity<BookBorrowingRequest>()
        .HasOne(b=>b.RequestedBy)
        .WithMany(c=>c.BookBorrowingRequests)
        .HasForeignKey(b=>b.RequestByUserId)
        .OnDelete(DeleteBehavior.Restrict)
        .IsRequired();

         builder.Entity<BookBorrowingRequest>()
        .HasOne(b=>b.ProcesseddBy)
        .WithMany(c=>c.ProcessedRequests)
        .HasForeignKey(b=>b.ProcessedByUserId)
        .OnDelete(DeleteBehavior.SetNull)
        .IsRequired(false);

        // Bookborrowingrequestdetails
        builder.Entity<BookBorrowingRequestDetails>(e=>e.ToTable("BookBorrowingRequestDetails"));
        builder.Entity<BookBorrowingRequestDetails>().HasKey(d=>new{d.BookBorrowingRequestId,d.BookId});
        
        builder.Entity<BookBorrowingRequestDetails>()
        .HasOne(b=>b.BookBorrowingRequest)
        .WithMany(c=>c.Details)
        .HasForeignKey(b=>b.BookBorrowingRequestId)
        .IsRequired();

         builder.Entity<BookBorrowingRequestDetails>()
        .HasOne(b=>b.Book)
        .WithMany(c=>c.Details)
        .HasForeignKey(b=>b.BookId)
        .IsRequired();

    }

}