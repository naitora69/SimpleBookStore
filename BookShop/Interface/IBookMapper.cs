using BookShop.Dtos.Book;
using BookShop.Models;

namespace BookShop.Interface;

public interface IBookMapper
{
    public Book FromBookCreateDtoToBook(BookCreateDto bookDto);
    public Book FromBookUpdateDtoToBook(BookUpdateDto bookDto, Book book);
    public  BookCreateDto FromBookTOBookDto(Book book);
}