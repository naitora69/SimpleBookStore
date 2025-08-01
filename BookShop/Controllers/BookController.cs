using BookShop.Data;
using BookShop.Dtos.Book;
using BookShop.Interface;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Controllers;


[ApiController]
[Route("books/")]
public class BookController :ControllerBase
{
    protected readonly ApplicationDbContext _context;
    protected readonly IBookMapper _bookMapper;
    public BookController(ApplicationDbContext context, IBookMapper bookMapper)
    {
        _context = context;
        _bookMapper = bookMapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _context.Books.ToListAsync();
        return Ok(books);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBookById([FromRoute] int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        if (book == null)
        {
            return NotFound("Book is not found");
        }
        return Ok(_bookMapper.FromBookTOBookDto(book));
    }
    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] BookCreateDto bookDto)
    {
        Book book = _bookMapper.FromBookCreateDtoToBook(bookDto);
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, _bookMapper.FromBookTOBookDto(book));
        
        /*
         Метод CreatedAtAction создает ответ с кодом 201, который по стилю Rest должно быть отправлено при создании какой-то сущности
         у этого метода есть три параметра первый - это actionName(имя метода на который мы будем ссылаться, того метода в котором можно
         будет найти созданную сущность, второй - routeValues(опеределяет как будет роутиться наш маршрут), и третий и последний - это
         value(данные созданного объекта или тело ответа)
        */
        
        //Ef core автоматически за нас определит Id книги, если будет знать что это Primary Key
        

    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] BookUpdateDto updateDto)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound("Book Not Found");
        }
        //основная задача здесь это изменить буквально найденный объект и сохранить в БД    
        book = _bookMapper.FromBookUpdateDtoToBook(updateDto, book);
        await _context.SaveChangesAsync();
        
        return Ok(_bookMapper.FromBookTOBookDto(book));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteBook([FromRoute] int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound("Book not found");
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    
}