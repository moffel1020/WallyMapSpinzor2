using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class TeamItemInitSpawn : AbstractItemSpawn, IDeserializable<TeamItemInitSpawn>
{
    public TeamItemInitSpawn() : base() { }
    private TeamItemInitSpawn(XElement e) : base(e) { }
    public static TeamItemInitSpawn Deserialize(XElement e) => new(e);

    public override double DefaultX => 1.79769313486231e+308;
    public override double DefaultY => 1.79769313486231e+308;
    public override double DefaultW => 50;
    public override double DefaultH => 50;

    public override Color GetColor(RenderConfig config) => config.ColorTeamItemInitSpawn;
}