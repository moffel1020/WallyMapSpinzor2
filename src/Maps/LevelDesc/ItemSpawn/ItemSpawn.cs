using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class ItemSpawn : AbstractItemSpawn, IDeserializable<ItemSpawn>
{
    public ItemSpawn() : base() { }
    private ItemSpawn(XElement e) : base(e) { }
    public static ItemSpawn Deserialize(XElement e) => new(e);

    public override double DefaultX => 1.79769313486231e+308;
    public override double DefaultY => 1.79769313486231e+308;
    public override double DefaultW => 1.79769313486231e+308;
    public override double DefaultH => 10;

    public override Color GetColor(RenderConfig config) => config.ColorItemSpawn;
}