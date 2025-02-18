using ErrorOr;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Text.Json;
using WeatherApp.Models;

namespace WeatherApp.Services;

public class ImageService(HttpClient HttpClient, IConfiguration Configuration, IJSRuntime JSRuntime)
{
    private readonly string ApiKey = Configuration["OpenImageApiKey"]!;

    public async Task<ErrorOr<ImageResponse>> GetImageAsync(string orientation)
    {
        var rand = new Random();    

        var key = DateTime.Now.ToString("MMMM");

        try
        {
            var storedTotalString = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "Total");

            int Total = string.IsNullOrEmpty(storedTotalString) ? 10 : int.Parse(storedTotalString);

            var page = rand.Next(Total == 0 ? 1 : Total);

            var result = await HttpClient.GetFromJsonAsync<ImageResponse>(
                                  $"https://api.unsplash.com/search/photos?" +
                                  $"query={key}" +
                                  $"&page={page}" +
                                  $"&per_page=1" +
                                  $"&orientation={orientation}" +
                                  $"&client_id={ApiKey}");

            if (result != null)
                await JSRuntime.InvokeVoidAsync("localStorage.setItem", "Total", result.Total);

            return result!;
        }
        catch (HttpRequestException ex)
        {
            // Помилки, пов'язані з HTTP-запитами
            return Error.Validation($"Error fetching weather data: {ex.Message}");
        }
        catch (JsonException ex)
        {
            // Помилки парсингу JSON
            return Error.Validation($"Error parsing weather data: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Будь-які інші помилки
            return Error.Validation($"An unexpected error occurred: {ex.Message}");
        }
    }

   
}
