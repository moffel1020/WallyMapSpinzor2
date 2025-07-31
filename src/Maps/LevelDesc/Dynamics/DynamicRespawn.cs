using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class DynamicRespawn : AbstractDynamic<Respawn>, IDeserializable<DynamicRespawn>
{
    public DynamicRespawn() : base() { }
    private DynamicRespawn(XElement e) : base(e) { }
    public static DynamicRespawn Deserialize(XElement e) => new(e);

    public override void DeserializeChildren(XElement element)
    {
        Children = element.DeserializeChildrenOfType<Respawn>();
        foreach (Respawn r in Children)
            r.Parent = this;
    }
}