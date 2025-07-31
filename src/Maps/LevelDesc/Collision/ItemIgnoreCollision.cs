using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class ItemIgnoreCollision : AbstractCollision, IDeserializable<ItemIgnoreCollision>
{
    public ItemIgnoreCollision() : base() { }
    private ItemIgnoreCollision(XElement e) : base(e) { }
    public static ItemIgnoreCollision Deserialize(XElement e) => new(e);

    public override Color GetColor(RenderConfig config) => config.ColorItemIgnoreCollision;
    //yes, item ignore collision is a no-slide collision
    public override CollisionTypeFlags CollisionType => CollisionTypeFlags.HARD | CollisionTypeFlags.NO_SLIDE | CollisionTypeFlags.ITEM_IGNORE;
}