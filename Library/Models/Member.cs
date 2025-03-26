using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models;

[Table("Members")]
public class Member
{
    [Key] public int MemberID { get; set; }

    [Required] public string Name { get; set; }

    [EmailAddress] [Required] public string Email { get; set; }

    public DateTime MembershipStartDate { get; set; }

    // Navigation property
    public ICollection<Loan> Loans { get; set; }
}