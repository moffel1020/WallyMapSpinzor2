using System.Xml.Linq;

namespace WallyMapSpinzor2;

public class DynamicItemSpawn : AbstractDynamic<AbstractItemSpawn>
{
    public override void DeserializeChildren(XElement element)
    {
        Children = element.DeserializeItemSpawnChildren();
        foreach (AbstractItemSpawn i in Children)
            i.Parent = this;
    }
}