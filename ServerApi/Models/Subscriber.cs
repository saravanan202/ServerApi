using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("subscriber")]
public class Subscriber
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("email_id")]
    public int EmailId { get; set;}
    [Column("email")]
    public string? Email { get; set; }
}