using System.Text;
using Picsum.Request;

namespace Picsum;

/// <summary>
/// This is a wrapper class over the Lorem Picsum API
/// </summary>
public static class LoremPic
{
    public static string Request(LoremRequest request)
    {
        var sb = new StringBuilder();
        string url = Endpoints.Random(request.Width, request.Height ?? request.Width);

        int? id = request.Id;
        if (id.HasValue)
        {
            url = Endpoints.ById(id.Value, request.Width, request.Width);
        }

        if (!string.IsNullOrWhiteSpace(request.Seed))
        {
            url = Endpoints.BySeed(request.Seed, request.Width, request.Height);
        }

        sb.Append(url);

        if (request.GrayScale)
        {
            sb.Append("?grayscale");
        }

        return sb.ToString();
    }

    public static Imag RequestImage(LoremBitmapRequest request)
    {
        
    }
}