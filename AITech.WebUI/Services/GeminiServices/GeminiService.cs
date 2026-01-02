
using AITech.WebUI.DTOs.GeminiDtos;
using Newtonsoft.Json;
using System.Text;

namespace AITech.WebUI.Services.GeminiServices
{
    public class GeminiService : IGeminiService
    {
        private readonly HttpClient httpClient;
        private readonly string API_KEY;
        // burada secrets json üzerinden api key i çekebilirsin

        private const string ModelName = "gemini-2.0-flash";
        private const string baseUrl = "https://generativelanguages.googleapis.com/v1beta/models/";

        public GeminiService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            API_KEY = configuration["Gemini:ApiKey"];
        }

        public async Task<string> GetGeminiResponseAsync(string prompt)
        {
            var requestBody = new GeminiRequestDto
            {
                contents = new List<Content>
                {
                    new Content
                    {
                        role = "user",
                        parts = new List<Part>
                        {
                            new Part
                            {
                                text = prompt
                            }
                        }
                    }
                },
                generationconfig = new GenerationConfig
                {
                    temperature = 0.7f,
                    maxOutputTokens = 1024
                }
            };

            var jsonContent = JsonConvert.SerializeObject(requestBody);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");    

            var url = $"{baseUrl}{ModelName}:generateContent?key={API_KEY}";
            var response = await httpClient.PostAsync(url, httpContent);

            if (!response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                return message;
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var geminiResponse = JsonConvert.DeserializeObject<GeminiResponseDto>(responseContent);
            return geminiResponse.candidates.FirstOrDefault().content.parts.FirstOrDefault().text;
        }
    }
}
