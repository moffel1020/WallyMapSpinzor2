using System.Xml.Linq;

namespace WallyMapSpinzor2;

public class SpawnBotBounds : IDeserializable, ISerializable
{
    public double X{get; set;}
    public double Y{get; set;}
    public double W{get; set;}
    public double H{get; set;}
    public void Deserialize(XElement element)
    {
        X = element.GetFloatAttribute("X");
        Y = element.GetFloatAttribute("Y");
        W = element.GetFloatAttribute("W");
        H = element.GetFloatAttribute("H");
    }

    public XElement Serialize()
    {
        XElement e = new("SpawnBotBounds");

        e.SetAttributeValue("X", X.ToString());
        e.SetAttributeValue("Y", Y.ToString());
        e.SetAttributeValue("W", W.ToString());
        e.SetAttributeValue("H", H.ToString());

        return e;
    }
}