using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class Goal : AbstractVolume, IDeserializable<Goal>
{
    public Goal() : base() { }
    private Goal(XElement e) : base(e) { }
    public static Goal Deserialize(XElement e) => new(e);

    public override bool ShouldShow(RenderConfig config) => config.ShowGoal;
}