using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GitHubEventNamespace;

class MainClass
{
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {   
        //Ingresa y guarda el nombre de usuario
        Console.WriteLine("Github username: ");
        string? username = Console.ReadLine();
        string url = $"https://api.github.com/users/{username}/events/public";

        //Configuracion de cliente HTTP
        client.DefaultRequestHeaders.Add("User-Agent", "GitHubActivityNotifier");
        client.DefaultRequestHeaders.Add("Authorization", "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");

        //Realizar la solicitud
        HttpResponseMessage response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode) 
        {
            string responseData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<GitHubEvent>? events = JsonSerializer.Deserialize<List<GitHubEvent>>(responseData, options);

            Console.WriteLine($"{"Type", -25} | {"Repository", -40} | {"Date",-30 } | {"Commit",-25} | {"Message"}");
            foreach(var ev in events)
            {
                Console.Write($"Type: {ev.Type, -20} Repository: {ev.Repo.Name, -25} Date: {ev.CreatedAt,10}");
                if (ev.Payload.Commits != null)
                {
                    foreach (var commit in ev.Payload.Commits) 
                    {
                        Console.WriteLine($"Commit: {commit.Sha, -25} Message: {commit.Message}");  
                    }
                   
                }
            }

        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode}");
        }
    }
}
