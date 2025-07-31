using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class BouncyNoSlideCollision : AbstractCollision, IDeserializable<BouncyNoSlideCollision>
{
    public BouncyNoSlideCollision() : base() { }
    private BouncyNoSlideCollision(XElement e) : base(e) { }
    public static BouncyNoSlideCollision Deserialize(XElement e) => new(e);

    public override Color GetColor(RenderConfig config) => config.ColorBouncyNoSlideCollision;
    public override CollisionTypeFlags CollisionType => CollisionTypeFlags.HARD | CollisionTypeFlags.NO_SLIDE | CollisionTypeFlags.BOUNCY;
}