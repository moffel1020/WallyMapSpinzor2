using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class DynamicItemSpawn : AbstractDynamic<AbstractItemSpawn>, IDeserializable<DynamicItemSpawn>
{
    public DynamicItemSpawn() : base() { }
    private DynamicItemSpawn(XElement e) : base(e) { }
    public static DynamicItemSpawn Deserialize(XElement e) => new(e);

    public override void DeserializeChildren(XElement element)
    {
        Children = element.DeserializeItemSpawnChildren();
        foreach (AbstractItemSpawn i in Children)
            i.Parent = this;
    }
}