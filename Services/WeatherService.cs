using ErrorOr;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using WeatherApp.Models;

namespace WeatherApp.Services;


public class WeatherService(HttpClient HttpClient, IConfiguration Configuration)
{
    private readonly string ApiKey = Configuration["OpenWeatherApiKey"]!;

    //https://api.openweathermap.org/data/2.5/weather?lat=57&lon=-2.15&appid={API key}&units=metric
    //https://api.openweathermap.org/data/2.5/weather?lat=57&lon=-2.15&appid={API key}&units=imperial

    public async Task<ErrorOr<CurrentWeatherResponse>> GetWeatherAsync(string city)
    {
        try
        {
            var result = await HttpClient.GetFromJsonAsync<CurrentWeatherResponse>(
            $"https://api.openweathermap.org/data/2.5/weather?q={city}" +
            $"&units=metric&appid={ApiKey}");

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

    public async Task<ErrorOr<ForecastResponse>> GetWeatherForecastAsync(string city)
    {
        try
        {
            var result = await HttpClient.GetFromJsonAsync<ForecastResponse>(
                $"https://api.openweathermap.org/data/2.5/forecast?q={city}&units=metric&appid={ApiKey}");

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
