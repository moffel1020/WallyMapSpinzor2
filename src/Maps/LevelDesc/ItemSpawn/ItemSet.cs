using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class ItemSet : AbstractItemSpawn, IDeserializable<ItemSet>
{
    public ItemSet() : base() { }
    private ItemSet(XElement e) : base(e) { }
    public static ItemSet Deserialize(XElement e) => new(e);

    public override double DefaultX => 1.79769313486231e+308;
    public override double DefaultY => 1.79769313486231e+308;
    public override double DefaultW => 40;
    public override double DefaultH => 40;

    public override Color GetColor(RenderConfig config) => config.ColorItemSet;
}