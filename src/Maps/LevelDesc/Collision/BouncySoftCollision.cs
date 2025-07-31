using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class BouncySoftCollision : AbstractCollision, IDeserializable<BouncySoftCollision>
{
    public BouncySoftCollision() : base() { }
    private BouncySoftCollision(XElement e) : base(e) { }
    public static BouncySoftCollision Deserialize(XElement e) => new(e);

    public override Color GetColor(RenderConfig config) => config.ColorBouncySoftCollision;
    public override CollisionTypeFlags CollisionType => CollisionTypeFlags.SOFT | CollisionTypeFlags.BOUNCY;
}