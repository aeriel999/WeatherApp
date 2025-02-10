using System.Text.Json.Serialization;

namespace WeatherApp.Models;

public class CurrentWeatherResponse
{
    [JsonPropertyName("coord")]
    public required Coordinate Coordinate {get; set;}

    [JsonPropertyName("weather")]
    public required List<WeatherInfo> Weather { get; set; }


    [JsonPropertyName("main")]
    public required CurrentWeatherInfo AboutWeather { get; set; }

    [JsonPropertyName("visibility")]
    public int Visibility { get; set; }

    [JsonPropertyName("wind")]
    public required WindInfo Wind { get; set; }

    [JsonPropertyName("sys")]
    public required SunInfo CurrentSunInfo { get; set; }

    public required string Name { get; set; }
}


public class Coordinate
{
    public double Lon { get; set; }

    public double Lat { get; set; }
}


public class WeatherInfo
{
    [JsonPropertyName("main")]
    public required string Name { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    
    [JsonPropertyName("icon")]
    public required string Icon { get; set; }
}


public class CurrentWeatherInfo
{
    public double Temp { get; set; }

    public int Humidity { get; set; }

    [JsonPropertyName("sea_level")]
    public int SeaLevelPressure { get; set; }

    [JsonPropertyName("grnd_level")]
    public int GroundLevelPressure { get; set; }
}


public class WindInfo
{ 
    public double Speed { get; set; }

    public int Deg { get; set; }

    public double Gust { get; set; }
}


public class SunInfo
{ 
    public int Sunrise { get; set; }

    public int Sunset { get; set; }

}
