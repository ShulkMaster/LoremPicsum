namespace Picsum;

///<include file='Docs/LoremRequest.xml' path='docs/class/*'/>
public class LoremRequest
{
    ///<include file='Docs/LoremRequest.xml' path='docs/member[@name="Id"]'/>
    public int? Id { get; set; }

    ///<include file='Docs/LoremRequest.xml' path='docs/member[@name="Seed"]'/>
    public string Seed { get; set; } = string.Empty;

    ///<include file='Docs/LoremRequest.xml' path='docs/member[@name="GrayScale"]'/>
    public bool GrayScale { get; set; }

    ///<include file='Docs/LoremRequest.xml' path='docs/member[@name="Width"]'/>
    public int Width { get; set; } = 256;

    ///<include file='Docs/LoremRequest.xml' path='docs/member[@name="Height"]'/>
    public int? Height { get; set; }
}