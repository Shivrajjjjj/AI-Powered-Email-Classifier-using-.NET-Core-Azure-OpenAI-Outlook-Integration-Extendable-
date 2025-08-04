using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using AI_PoweredEmailClassifier.Models;

namespace AI_PoweredEmailClassifier.Services
{
    public class GeminiEmailClassifier
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GeminiEmailClassifier(IConfiguration config)
        {
            _httpClient = new HttpClient();
            _apiKey = config["Gemini:ApiKey"];
        }

        public async Task<string> ClassifyEmailAsync(EmailRequest email)
        {
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={_apiKey}";

            var prompt = $"Classify the following email into one of these categories: Support, Sales, Urgent, Spam, Other.\n\n" +
                         $"Subject: {email.Subject}\nBody: {email.Body}\n\n" +
                         $"Return only the category name as plain text.";

            var payload = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return $"Error: {response.StatusCode}";

            var resultJson = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(resultJson);

            var category = doc.RootElement
                              .GetProperty("candidates")[0]
                              .GetProperty("content")
                              .GetProperty("parts")[0]
                              .GetProperty("text")
                              .GetString();

            return category?.Trim();
        }
    }
}
