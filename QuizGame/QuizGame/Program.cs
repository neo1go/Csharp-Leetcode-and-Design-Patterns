using System.Text;
using System.Text.Json;

class Program
{
    // AI-Model    Gemma 4 E2B      von Google DeepMind in LMStudio
    static async Task Main(string[] args)
    {
        string animal = await GetWordFromAI();
        Console.WriteLine("Ein Tier wurde generiert. Stelle deine Fragen");
        int n = 20;
        while (n > 0)
        {
            Console.WriteLine($"\nDeine {n}te Frage:");
            string question = Console.ReadLine();
            if (string.IsNullOrEmpty(question)) break;

            string answer = await AskHint(animal, question);
            Console.WriteLine($"KI: {answer}");

            var lower = question.ToLower();

            if (lower.Contains(animal.ToLower())) {
                Console.WriteLine("Das ist das richtige Tier.");
                break;
            }
            n--;
        }
    }



    private static async Task<string> GetWordFromAI()
    {
        var client = new HttpClient();
        var request = new
        {
            messages = new[]
     {
        new { role = "system", content = "Generiere ein einzelnes deutsches Tierwort." },
        new { role = "user", content = "Ein zufälliges Wort bitte" }
    },
            temperature = 0.9,
            max_tokens = 10
        };
        var response = await client.PostAsync("http://localhost:1234/v1/chat/completions",
        new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json"));
        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        string word = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
        return word.Trim().ToLower();
    }

    private static async Task<string> AskHint(string animal, string question)
    {
        var client = new HttpClient();
        var prompt = $@"Das geheime Wort ist: {animal}
                     Der Spieler fragt: {question}
                     Gib nur einen hilfreichen Hinweis (1-2 Sätze), ohne das Wort direkt zu nennen.";

        var request = new
        {
            messages = new[]
            {
            new {role = "user", content = prompt}
        },
            temperature = 0.7,
            max_tokens = 100
        };

        var response = await client.PostAsync("http://localhost:1234/v1/chat/completions",
            new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json"));

        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
    }
}