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
            string? question = Console.ReadLine();
            if (string.IsNullOrEmpty(question)) break;

            string answer = await AskHint(animal, question);
            Console.WriteLine($"KI: {answer}");

            var lower = question.ToLower();

            if (lower.Contains(animal.ToLower()))
            {
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
            model = "google/gemma-4-e2b",
            messages = new[]
     {
        new
        {
            role = "user",
            content = "Nenne ein zufälliges Tier allen Tierarten weltweit auf deutsch. Kein Haustierfokus. Kein Nachdenken. Keine Erklärung. Nur das Wort."
        }
    },
            temperature = 1.0,
            max_tokens = 500
        };
        var jsonBody = JsonSerializer.Serialize(request);

        var response = await client.PostAsync("http://localhost:1234/v1/chat/completions",
        new StringContent(jsonBody, Encoding.UTF8, "application/json"));
        var json = await response.Content.ReadAsStringAsync();
        Console.WriteLine(json);
        using var doc = JsonDocument.Parse(json);
        string? word = doc.RootElement.GetProperty("choices")[0]
                                     .GetProperty("message")
                                     .GetProperty("content")
                                     .GetString();
        return word.Trim().ToLower();
    }

    private static async Task<string> AskHint(string animal, string question)
    {
        var client = new HttpClient();
        var prompt = $@"
                     Du bist ein Spielleiter.
                     das geheime Wort lautet: {animal}
                     Regeln:
                     - Nenne das Wort niemals
                     - Beschreibe es nur indirekt 
                     Frage: {question}
                     Antworte kurz in 1 Satz.";

        var request = new
        {
            model = "google/gemma-4-e2b",
            messages = new[]
            {
            new {role = "user", content = prompt}
        },
            temperature = 0.7,
            max_tokens = 700
        };

        var response = await client.PostAsync("http://localhost:1234/v1/chat/completions",
            new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json"));

        var json = await response.Content.ReadAsStringAsync();
        //Console.WriteLine(json);
        using var doc = JsonDocument.Parse(json);
        return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
    }
}