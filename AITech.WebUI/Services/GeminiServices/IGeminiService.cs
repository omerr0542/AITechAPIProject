namespace AITech.WebUI.Services.GeminiServices;

public interface IGeminiService
{
    Task<string> GetGeminiResponseAsync(string prompt);
}
