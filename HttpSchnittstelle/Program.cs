
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HttpSchnittstelle;

namespace HttpSchnittstelle
{
    public interface IHttpClientFactory
    {
        HttpClient CreateClient();
    }

    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient()
        {
            return new HttpClient();
        }
    }

    public class HttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<string> GetAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"HTTP GET Request failed. Status code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Request failed: {ex.Message}");
            }
        }

        public async Task<string> PostAsync(string url, string jsonContent)
        {
            try
            {
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"HTTP POST Request failed. Status code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Request failed: {ex.Message}");
            }
        }
    }
}



public class Program
{
    public static async Task Main(string[] args)
    {
        try
        {
            string getUrl = "https://jsonplaceholder.typicode.com/todos/1";
            var httpService = new HttpService(new HttpClientFactory());
            string getResponseBody = await httpService.GetAsync(getUrl);  // wegen dem await muss die
                                                                       // Main Methode ein Task und async sein
            Console.WriteLine($"GET Response Body: {getResponseBody}");

            string postUrl = "https://jsonplaceholder.typicode.com/posts";
            string jsonContent = "{\"title\":\"foo\",\"body\":\"bar\",\"userId\":1}";
            string postResponseBody = await httpService.PostAsync(postUrl, jsonContent);

            Console.WriteLine($"POST Response Body: {postResponseBody}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured: {ex.Message}");
        }
    }
}
