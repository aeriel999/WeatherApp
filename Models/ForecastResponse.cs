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

    [JsonPropertyName("weather")]
    public required List<ForecastCurrentInfo> CurrentWeather { get; set; }

    [JsonPropertyName("wind")]
    public required ForecastWindInfo Wind { get; set; }
}

public class TemperatureInfo
{
    [JsonPropertyName("temp")]
    public double Temperature { get; set; }

    public int Humidity { get; set; }
}

public class ForecastCurrentInfo
{
    [JsonPropertyName("main")]
    public required string Name { get; set; }

    [JsonPropertyName("icon")]
    public required string Icon { get; set; }
}

public class ForecastWindInfo
{
    public double Speed { get; set; }
}
