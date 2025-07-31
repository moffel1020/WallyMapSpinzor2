using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class Volume : AbstractVolume, IDeserializable<Volume>
{
    public Volume() : base() { }
    private Volume(XElement e) : base(e) { }
    public static Volume Deserialize(XElement e) => new(e);

    public override bool ShouldShow(RenderConfig config) => config.ShowVolume;
}