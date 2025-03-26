using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models;

[Table("Books")]
public class Book
{
    [Key] public int BookID { get; set; }

    [Required] public string Title { get; set; }

    [Required] public string Author { get; set; }

    [Required] public string Genre { get; set; }

    public int? PublishedYear { get; set; }

    // Navigation property
    public ICollection<Loan> Loans { get; set; }
}