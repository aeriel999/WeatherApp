namespace WeatherApp.Models;

public class ImageRequest
{
    public required string Month { get; set; }
    public int PageNum { get; set; }
    public int TotalPage { get; set; }
    public required string Orientation { get; set; }
}
