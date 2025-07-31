using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class TriggerCollision : AbstractCollision, IDeserializable<TriggerCollision>
{
    public TriggerCollision() : base() { }
    private TriggerCollision(XElement e) : base(e) { }
    public static TriggerCollision Deserialize(XElement e) => new(e);

    public override Color GetColor(RenderConfig config) => config.ColorTriggerCollision;
    public override CollisionTypeFlags CollisionType => CollisionTypeFlags.TRIGGER;
}