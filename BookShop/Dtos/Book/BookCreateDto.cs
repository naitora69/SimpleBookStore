namespace BookShop.Dtos.Book;

public class BookCreateDto
{
    public string Author { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public long ISBN { get; set; } = 0;
}