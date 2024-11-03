using ShulkMaster.Picsum.Url;

namespace Picsum.Test;

public class LoremBuilderTest
{
  private static string MakeUrl(string path)
  {
    return $"{LoremUrlBuilder.ApiUrl}{path}";
  }

  [Fact]
  public void Should_Append_Id_When_Set()
  {
    var builder = new LoremUrlBuilder();
    var url = builder.SetId(15).Build();
    var expected = MakeUrl("id/15/256?");

    Assert.Equal(expected, url.Value);
  }

  [Fact]
  public void Should_Append_Seed_When_Set()
  {
    var builder = new LoremUrlBuilder();
    var url = builder.SetSeed("hello").Build();
    var expected = MakeUrl("seed/hello/256?");

    Assert.Equal(expected, url.Value);
  }

  [Fact]
  public void Should_Override_Id_Over_Seed()
  {
    var builder = new LoremUrlBuilder();
    var url = builder
      .SetId(18)
      .SetSeed("over")
      .Build();
    var expected = MakeUrl("id/18/256?");

    Assert.Equal(expected, url.Value);
  }
}