using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models;

[Table("Loans")]
public class Loan
{
    [Key] public int LoanID { get; set; }

    [ForeignKey("Book")] public int BookID { get; set; }

    [ForeignKey("Member")] public int MemberID { get; set; }

    public DateTime LoanDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    // Navigation properties
    public Book Book { get; set; }
    public Member Member { get; set; }
}