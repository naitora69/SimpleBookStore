namespace BookShop.Dtos.Book;

public class BookUpdateDto
{
    public string Author { get; set; } = string.Empty;
    
    public string Title { get; set; } = string.Empty;
    
    public long ISBN { get; set; } = 0;
}