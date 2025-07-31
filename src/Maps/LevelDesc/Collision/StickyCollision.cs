using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class StickyCollision : AbstractCollision, IDeserializable<StickyCollision>
{
    public StickyCollision() : base() { }
    private StickyCollision(XElement e) : base(e) { }
    public static StickyCollision Deserialize(XElement e) => new(e);

    public override Color GetColor(RenderConfig config) => config.ColorStickyCollision;
    public override CollisionTypeFlags CollisionType => CollisionTypeFlags.HARD | CollisionTypeFlags.STICKY;
}