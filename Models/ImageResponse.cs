using System;
using System.Text.Json.Serialization;

namespace WeatherApp.Models;

public class ImageResponse
{
    public int Total { get; set; }

    [JsonPropertyName("results")]
    public required List<Image> ImagesList { get; set; }
}

public class Image
{
    [JsonPropertyName("urls")]
    public required UrlContainer Urls { get; set; }
}

public class UrlContainer
{
    [JsonPropertyName("full")]
    public required string Full { get; set; }
}


//public class Url
//{ 
//    public required string Full { get; set; }
//}