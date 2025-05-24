using OpenAI.Chat;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace OpenAIChat
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var apiKey = Constants.OpenAIKey;
            var model = "deepseek/deepseek-chat-v3-0324:free";

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://openrouter.ai");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            httpClient.DefaultRequestHeaders.Add("HTTP-Referer", "https://your-app.com"); // Bắt buộc, dùng tên trang của bạn
            httpClient.DefaultRequestHeaders.Add("X-Title", "Test Chat App");             // Tên ứng dụng bạn tạo

            var requestData = new
            {
                model = model,
                messages = new[]
                {
                new { role = "user", content = "Xin chào, bạn có biết c# là gì không?" }
            }
            };

            var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/api/v1/chat/completions", content);
            var responseJson = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(responseJson);
            var messageContent = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            Console.WriteLine(messageContent);
        }
    }
}
