using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApiClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static async Task<List<Repository>> ProcessRepositoriesAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")
            );
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
            
            return repositories;
        }
        
        static async Task Main(string[] args)
        {
            var repositories = await ProcessRepositoriesAsync();
            foreach(var repository in repositories)
                Console.WriteLine(repository.Name);
        }
    }
}
