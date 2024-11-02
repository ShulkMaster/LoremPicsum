using System.Text;
using Picsum.Structs;

namespace Picsum;

/// <summary>
/// This is a wrapper class over the Lorem Picsum API
/// </summary>
public class LoremPic
{
  private const string ApiUrl = "https://picsum.photos/";
  private readonly string _api;

  public LoremPic(string baseUrl = ApiUrl)
  {
    _api = baseUrl;
  }

  private static void SetIfIdOrSeed(LoremRequest request, StringBuilder sb)
  {
    var id = request.Id;
    if (id.HasValue)
    {
      sb.Append("id/");
      sb.Append(id.Value);
      sb.Append('/');
    }
    else if (!string.IsNullOrWhiteSpace(request.Seed))
    {
      sb.Append("seed/");
      sb.Append(request.Seed);
      sb.Append('/');
    }
    // left to the server random img implementation
  }

  private static void SetDimensions(LoremRequest request, StringBuilder sb)
  {
    var w = request.Width;
    sb.Append(w);
    sb.Append('/');
    if (!request.Height.HasValue) return;
    sb.Append(request.Height.Value);
    sb.Append('/');
  }

  public LoremUrl BuildUrl(LoremRequest request)
  {
    var sb = new StringBuilder(256);
    sb.Append(_api);
    SetIfIdOrSeed(request, sb);
    SetDimensions(request, sb);

    if (request.Format is ImgFormat.WebP)
    {
      // by default is always a Jpeg
      sb.Append(".webp");
    }

    sb.Append('?');
    var useAnd = true;
    if (request.GrayScale)
    {
      useAnd = true;
      sb.Append("grayscale");
    }

    if (request.Blur is Blur.None)
    {
      return new LoremUrl(sb.ToString());
    }

    if (useAnd)
    {
      sb.Append('&');
    }

    sb.Append("blur=");
    sb.Append((int)request.Blur);

    return new LoremUrl(sb.ToString());
  }
}