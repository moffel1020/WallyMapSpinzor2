using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class BouncyHardCollision : AbstractCollision, IDeserializable<BouncyHardCollision>
{
    public BouncyHardCollision() : base() { }
    private BouncyHardCollision(XElement e) : base(e) { }
    public static BouncyHardCollision Deserialize(XElement e) => new(e);

    public override Color GetColor(RenderConfig config) => config.ColorBouncyHardCollision;
    public override CollisionTypeFlags CollisionType => CollisionTypeFlags.HARD | CollisionTypeFlags.BOUNCY;
}