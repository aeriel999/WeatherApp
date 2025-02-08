using System.Text.Json.Serialization;

namespace WeatherApp.Models;

public class ForecastResponse
{
    [JsonPropertyName("list")]
    public List<ForecastItem> List { get; set; } = new();
}

public class ForecastItem
{
    [JsonPropertyName("dt_txt")]
    public string DateTime { get; set; } = string.Empty;

    [JsonPropertyName("main")]
    public TemperatureInfo Main { get; set; } = new();
}

public class TemperatureInfo
{
    [JsonPropertyName("temp")]
    public double Temperature { get; set; }
}
