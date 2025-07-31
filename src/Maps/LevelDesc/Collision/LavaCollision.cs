using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class LavaCollision : AbstractCollision, IDeserializable<LavaCollision>
{
    public string LavaPower { get; set; } = null!;

    public LavaCollision() : base() { }
    private LavaCollision(XElement e) : base(e)
    {
        LavaPower = e.GetAttribute("LavaPower");
    }

    public static LavaCollision Deserialize(XElement e) => new(e);

    public override void Serialize(XElement e)
    {
        e.SetAttributeValue("LavaPower", LavaPower);
        base.Serialize(e);
    }

    public override Color GetColor(RenderConfig config) => config.ColorLavaCollision;
    public override CollisionTypeFlags CollisionType => CollisionTypeFlags.HARD | CollisionTypeFlags.GAMEMODE | CollisionTypeFlags.LAVA;
}