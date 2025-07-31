using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class NoDodgeZone : AbstractVolume, IDeserializable<NoDodgeZone>
{
    public NoDodgeZone() : base() { }
    private NoDodgeZone(XElement e) : base(e) { }
    public static NoDodgeZone Deserialize(XElement e) => new(e);

    public override bool ShouldShow(RenderConfig config) => config.ShowNoDodgeZone;
}