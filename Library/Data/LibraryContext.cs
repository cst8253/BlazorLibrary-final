using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data;

public class LibraryContext : DbContext
{
    // This constructor is necessary so that we can pass the instance of
    // the DbContextOptions created in Program.cs to the DBContext base class.
    // All of the heavy lifting is done automatically, simply by passing this
    // parameter to the base class - it will handle opening the connection
    // for us.
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    // Define the DbSets that will represent the tables in the database
    public DbSet<Book> Books { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Loan> Loans { get; set; }

    // Here we use the OnModelCreating event to configure the relationships
    // between the entities in our context model.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships...

        // From the SQLite database we see that the Loans table has
        // foreign key relationships to the Member and Book tables, so
        // we will define the relationships using the model that derives from
        // the Loans table - the Loan entity (see Models/Loan.cs).

        // First, we will specify the relationship for the foreign key BookID.
        // Consider a record in the Loan table - it will have a reference to exactly ONE book
        // denoted by the BookID for that record. In the Loan model we defined a Navigation
        // Property to point to the ONE book that is being loaned to a Member. Therefore, we 
        // can say that "a Loan has ONE book". Consider also that the same book can be loaned
        // to another Member after it has been returned - so we can say that a Book has MANY loans.

        // The following code declares this relationship in Entity Framework:
        modelBuilder.Entity<Loan>() // For a given Loan entity
            .HasOne(l => l.Book) // There will be a single Book
            .WithMany(b => b.Loans) // A Book can have many Loans
            .HasForeignKey(l => l.BookID); // The relationship between a Book
        // and a Loan is the BookID.

        // Likewise, we can make a similar observation about the Member who borrows
        // the Book. Again, for a given Book, there is only ONE Member borrowing the book
        // and that Member may borrow other books, so they will have MANY Loans.

        // Here is the code for the Member relationship:
        modelBuilder.Entity<Loan>()
            .HasOne(l => l.Member)
            .WithMany(m => m.Loans)
            .HasForeignKey(l => l.MemberID);

        // Why was this code important? It tells Entity Framework how to get the data to
        // populate the Navigation Properties in our Model classes.

        // The Member model has an "ICollection<Loan> Loans" property. With this code Entity Framework
        // now knows to populate that collection with Loan entities that have the matching MemberID.
        // So, Entity Framework is going to query the database and retrieve the records from the
        // Loan table where the MemberID matches a given Member.

        // Likewise, the Book model has an "ICollection<Loan> Loans" property that provides
        // all of that Book's Loan history - which is all of the Loan records where the BookID
        // matches for a given Book.

        // Finally - if you examine the Loan model you will both a "public Book" property
        // and a public Member property. Notice, that are not collections - but single instances
        // of each. This is because a specific instance of a Loan is ONE Book to ONE Member!

        // Again, because we define the relationship here in the "OnModelCreating" method,
        // Entity Framework knows to populate this property with the Book and Member with the 
        // matching BookID and MemberID for a given Loan.
    }
}