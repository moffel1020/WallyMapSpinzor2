using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class NoSlideCollision : AbstractCollision, IDeserializable<NoSlideCollision>
{
    public NoSlideCollision() : base() { }
    private NoSlideCollision(XElement e) : base(e) { }
    public static NoSlideCollision Deserialize(XElement e) => new(e);

    public override Color GetColor(RenderConfig config) => config.ColorNoSlideCollision;
    public override CollisionTypeFlags CollisionType => CollisionTypeFlags.HARD | CollisionTypeFlags.NO_SLIDE;
}