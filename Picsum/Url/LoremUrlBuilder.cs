using System.Text;
using System.Web;
using ShulkMaster.Picsum.Client;
using ShulkMaster.Picsum.Option;

namespace ShulkMaster.Picsum.Url;

using Self = LoremUrlBuilder;

/// <summary>
/// This is a wrapper class over the Lorem Picsum API
/// </summary>
public class LoremUrlBuilder
{
  public const string ApiUrl = "https://picsum.photos/";
  private readonly PicsumConfig _config;
  private readonly Uri _api;

  public LoremUrlBuilder(string baseUrl = ApiUrl)
  {
    _config = new PicsumConfig();
    _api = new Uri(baseUrl);
  }

  private static void SetIfIdOrSeed(PicsumConfig request, StringBuilder sb)
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
      var encoded = HttpUtility.UrlEncode(request.Seed);
      sb.Append(encoded);
      sb.Append('/');
    }
    // left to the server random img implementation
  }

  private static void SetDimensions(PicsumConfig request, StringBuilder sb)
  {
    var w = request.Width;
    sb.Append(w);
    if (!request.Height.HasValue) return;
    sb.Append('/');
    sb.Append(request.Height.Value);
    sb.Append('/');
  }

  public LoremUrl BuildFromConfig(PicsumConfig request)
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

  public LoremUrl Build()
  {
    return BuildFromConfig(_config);
  }

  public Self SetId(uint id)
  {
    _config.Id = id;
    return this;
  }

  public Self SetSeed(string seed)
  {
    _config.Seed = seed;
    return this;
  }

  public Self SetGrayScale(bool grayScale)
  {
    _config.GrayScale = grayScale;
    return this;
  }

  public Self SetHeight(int height)
  {
    if (height < 0)
    {
      throw new ArgumentOutOfRangeException(nameof(height), "Height cannot be negative.");
    }

    return SetHeight((uint)height);
  }

  public Self SetHeight(uint height)
  {
    _config.Height = height;
    return this;
  }

  public Self SetWith(int width)
  {
    if (width < 0)
    {
      throw new ArgumentOutOfRangeException(nameof(width), "Width cannot be negative.");
    }

    return SetWith((uint)width);
  }

  public Self SetWith(uint width)
  {
    _config.Width = width;
    return this;
  }

  public Self SetSize(int width, int? height = null)
  {
    return SetWith(width).SetHeight(height ?? width);
  }

  public Self SetBlur(Blur blur)
  {
    _config.Blur = blur;
    return this;
  }

  public Self SetFormat(ImgFormat f)
  {
    _config.Format = f;
    return this;
  }
}