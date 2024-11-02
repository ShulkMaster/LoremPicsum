namespace Picsum.Structs;

public readonly ref struct LoremUrl
{
  public readonly string Url;

  internal LoremUrl(string url)
  {
    Url = url;
  }
}