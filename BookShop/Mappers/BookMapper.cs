using BookShop.Dtos.Book;
using BookShop.Interface;
using BookShop.Models;

namespace BookShop.Mappers;

public class BookMapper : IBookMapper
{
    public Book FromBookCreateDtoToBook(BookCreateDto bookDto)
    {
        var book = new Book()
        {
            Title = bookDto.Title,
            Author = bookDto.Author,
            ISBN = bookDto.ISBN,
        };
        return book;
    }
    public Book FromBookUpdateDtoToBook(BookUpdateDto bookDto, Book book)
    {
        book.Author = bookDto.Author;
        book.Title = bookDto.Title;
        book.ISBN = bookDto.ISBN;
        return book;
    }

    public BookCreateDto FromBookTOBookDto(Book book)
    {
        return new BookCreateDto()
        {
            Author = book.Author,
            Title = book.Title,
            ISBN = book.ISBN
        };
    }
}