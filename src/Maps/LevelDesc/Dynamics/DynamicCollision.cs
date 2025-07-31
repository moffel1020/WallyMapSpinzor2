using System;
using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class DynamicCollision : AbstractDynamic<AbstractCollision>, IDeserializable<DynamicCollision>
{
    public DynamicCollision() : base() { }
    DynamicCollision(XElement e) : base(e) { }
    public static DynamicCollision Deserialize(XElement e) => new(e);

    public override void DeserializeChildren(XElement element)
    {
        Children = element.DeserializeCollisionChildren();
        foreach (AbstractCollision c in Children)
            c.Parent = this;
    }

    public void ClaimPlatIDOwnership(RenderContext context)
    {
        context.DynamicCollisionPlatIDOwner[PlatID] = this;
    }

    public override (double, double) GetOffset(RenderContext context)
    {
        if (!context.DynamicCollisionPlatIDOwner.TryGetValue(PlatID, out DynamicCollision? owner))
            throw new InvalidOperationException($"Make sure to call {nameof(ClaimPlatIDOwnership)} before rendering DynamicCollision");
        if (owner != this)
            return (0, 0);
        return base.GetOffset(context);
    }
}