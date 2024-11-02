using ShulkMaster.Picsum.Url;

namespace ShulkMaster.Picsum.Client;

public static class PicsumClient
{
  private static readonly HttpClient Client = new();

  public static Task<Stream> GetStream(LoremUrl url, CancellationToken token = default)
  {
    return Client.GetStreamAsync(url.Value, token);
  }

  public static async Task SaveToFileAsync(LoremUrl url, string filePath, CancellationToken token = default)
  {
    Directory.CreateDirectory(filePath);
    var fStream = new FileStream(filePath, FileMode.Create);
    await SaveToStreamAsync(url, fStream, token);
    fStream.Close();
    await fStream.DisposeAsync();
  }
  
  public static void SaveToFile(LoremUrl url, string filePath)
  {
    Directory.CreateDirectory(filePath);
    var fStream = new FileStream(filePath, FileMode.Create);
    SaveToStream(url, fStream);
    fStream.Close();
    fStream.Dispose();
  }

  public static async Task SaveToStreamAsync(LoremUrl url, Stream outStream, CancellationToken token = default)
  {
    await using var stream = await Client.GetStreamAsync(url.Value, token);
    await stream.CopyToAsync(outStream, token);
    await outStream.FlushAsync(token);
  }
  
  public static void SaveToStream(LoremUrl url, Stream outStream)
  {
    using var stream = Client
      .GetStreamAsync(url.Value)
      .ConfigureAwait(false)
      .GetAwaiter()
      .GetResult();
    stream.CopyTo(outStream);
    outStream.Flush();
  }
}
