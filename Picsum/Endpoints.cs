namespace Picsum;

public static class Endpoints
{
    private const string BaseUrl = "https://picsum.photos";

    /// <summary>
    /// Builds the url for a random square image of the given size
    /// </summary>
    /// <param name="size">size of the image to request</param>
    /// <returns>random square image URL</returns>
    public static string Random(int size = 200) => $"{BaseUrl}/{size}";
    
    /// <summary>
    /// Builds the url for a random image of the given width and height
    /// </summary>
    /// <param name="width">width of the image</param>
    /// <param name="height">height of the image</param>
    /// <returns>random image URL of given width and height</returns>
    public static string Random(int width, int height) => $"{BaseUrl}/{width}/{height}";
    
    public static string ById(int id, int width, int? height = null) => $"{BaseUrl}/id/{id}/{width}/{height ?? width}";
    
    public static string BySeed(string seed, int width, int? height = null) => $"{BaseUrl}/seed/{seed}/{width}/{height ?? width}";

}