using System.Net;
using System.Net.Http.Json;

namespace ClientHttp;

public class BooksService
{
    public async Task GetAll(string uri, HttpClient httpClient)
    {
        var books = await httpClient.GetFromJsonAsync<List<Books>>(uri);
        foreach (var book in books)
        {
            Console.WriteLine($"Id: {book.Id}, Author: {book.Author}, Title: {book.Title}, ISBN: {book.Isbn}");
        }

    }

    public async Task GetById(string uri, string id, HttpClient httpClient)
    {
        
        using var response = await httpClient.GetAsync(uri + "/" + id);
        if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
        {
            Console.WriteLine(response.StatusCode);
        }
        else
        {
            var book = await response.Content.ReadFromJsonAsync<Books>();
            Console.WriteLine($"Author: {book.Author}, Title: {book.Title}, ISBN: {book.Isbn}");
        }
        
    }

    public async Task Post(string uri, HttpClient httpClient, BooksDto bookToPost )
    {
        JsonContent content = JsonContent.Create(bookToPost);

        using var responsee = await httpClient.PostAsync(uri, content);
    }

    public async Task Put(string uri, HttpClient httpClient, BooksDto bookToPut, int id)
    {
        
        using var responce = await httpClient.PutAsJsonAsync(uri + "/" + id.ToString(), bookToPut);
    }

    public async Task Delete(string uri, HttpClient httpClient, int id)
    {
        using var responce = await httpClient.DeleteAsync(uri + "/" + id);
    }
}