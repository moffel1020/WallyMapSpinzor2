using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class SoftPressurePlateCollision : AbstractPressurePlateCollision, IDeserializable<SoftPressurePlateCollision>
{
    public SoftPressurePlateCollision() : base() { }
    private SoftPressurePlateCollision(XElement e) : base(e) { }
    public static SoftPressurePlateCollision Deserialize(XElement e) => new(e);

    public override Color GetColor(RenderConfig config) => config.ColorSoftPressurePlateCollision;
    public override CollisionTypeFlags CollisionType => CollisionTypeFlags.SOFT | CollisionTypeFlags.PRESSURE_PLATE;
}