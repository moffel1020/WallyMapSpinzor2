using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class Asset : AbstractAsset, IDeserializable<Asset>
{
    public Asset() : base() { }
    private Asset(XElement e) : base(e) { }
    public static Asset Deserialize(XElement e) => new(e);
}