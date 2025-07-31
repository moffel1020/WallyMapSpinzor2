using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class PressurePlateCollision : AbstractPressurePlateCollision, IDeserializable<PressurePlateCollision>
{
    public PressurePlateCollision() : base() { }
    private PressurePlateCollision(XElement e) : base(e) { }
    public static PressurePlateCollision Deserialize(XElement e) => new(e);

    public override Color GetColor(RenderConfig config) => config.ColorPressurePlateCollision;
    public override CollisionTypeFlags CollisionType => CollisionTypeFlags.HARD | CollisionTypeFlags.PRESSURE_PLATE;
}