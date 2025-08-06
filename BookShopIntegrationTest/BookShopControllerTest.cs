using System.Net;
using BookShop.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace BookShopIntegrationTest;

public class BookShopControllerTest
{
    private WebApplicationFactory<Program> _webHost;
    private HttpClient _httpClient;
    
    [SetUp]
    public void SetUp()
    {
        _webHost = new WebApplicationFactory<Program>();
        _httpClient = _webHost.CreateClient();
    }
    
    [Test]
    public async Task BookGetAll_IsOkTest()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:5289/books");
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [Test]
    public async Task GetById_IsOkTest()
    {
        
    }
}

