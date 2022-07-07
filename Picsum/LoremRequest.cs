namespace Picsum;

public class LoremRequest
{
    public int? Id { get; set; }

    public string Seed { get; set; } = string.Empty;

    public bool GrayScale { get; set; }

    public int Width { get; set; } = 256;

    public int? Height { get; set; }
}