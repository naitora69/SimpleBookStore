using System.Net;
using System.Net.Http.Json;
using System.Runtime.InteropServices.JavaScript;
using ClientHttp;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    private static HttpClient httpClient = new HttpClient();
    private const string Uri = "http://localhost:5289/books";
    static async Task Main()
    {
        
        BooksService services = new BooksService();
        while (true)
        {
            Console.WriteLine("Выберите режим работы");
            string answer = Console.ReadLine();
            if (answer == "GETALL")
            {
                await services.GetAll(Uri, httpClient);
            }


            else if (answer == "GETID")
            {
                Console.WriteLine("Вывод одиночной книги");
                string n = Console.ReadLine();
                await services.GetById(Uri, n, httpClient);
            }
            else if (answer == "POST")
            {
                Console.WriteLine("Напишите автора");
                string author = Console.ReadLine();
                Console.WriteLine("Напишите название");
                string title = Console.ReadLine();
                Console.WriteLine("Напишите ISBN");
                string isbnstr = Console.ReadLine();
                long isbn = Int64.Parse(isbnstr);
                BooksDto bookToPost = new BooksDto { Title = title, Author = author, Isbn = isbn };
                await services.Post(Uri, httpClient, bookToPost);
            }

            else if (answer == "PUT")
            {
                Console.WriteLine("Напишите id объекта который хотите изменить");
                int id1 = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Напишите автора");
                string authori = Console.ReadLine();
                Console.WriteLine("Напишите название");
                string titlei = Console.ReadLine();
                Console.WriteLine("Напишите ISBN");
                string isbnstri = Console.ReadLine();
                long isbni = Int64.Parse(isbnstri);
                BooksDto bookToPut = new BooksDto() { Author = authori, Title = titlei, Isbn = isbni };
                await services.Put(Uri, httpClient, bookToPut, id1);
            }
            else if (answer == "DELETE")
            {
                Console.WriteLine("Напишите id объекта который хотите удалить");
                int id1 = Int32.Parse(Console.ReadLine());
                await services.Delete(Uri, httpClient, id1);
                
                
            }
        }
        
    }
    public record Error(string Message);
}
