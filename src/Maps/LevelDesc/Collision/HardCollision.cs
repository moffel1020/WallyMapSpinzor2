using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class HardCollision : AbstractCollision, IDeserializable<HardCollision>
{
    public HardCollision() : base() { }
    private HardCollision(XElement e) : base(e) { }
    public static HardCollision Deserialize(XElement e) => new(e);

    public override Color GetColor(RenderConfig config) => config.ColorHardCollision;
    public override CollisionTypeFlags CollisionType => CollisionTypeFlags.HARD;
}