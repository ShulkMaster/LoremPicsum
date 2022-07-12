namespace Picsum.Request;

public sealed class LoremFileRequest: LoremRequest
{
    public string FilePath { get; set; } = string.Empty;
}