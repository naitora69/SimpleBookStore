using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public long ISBN { get; set; } = 0;
}