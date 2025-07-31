using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class SoftCollision : AbstractCollision, IDeserializable<SoftCollision>
{
    public SoftCollision() : base() { }
    private SoftCollision(XElement e) : base(e) { }
    public static SoftCollision Deserialize(XElement e) => new(e);

    public override Color GetColor(RenderConfig config) => config.ColorSoftCollision;
    public override CollisionTypeFlags CollisionType => CollisionTypeFlags.SOFT;
}