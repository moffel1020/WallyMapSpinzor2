using System.Collections.Generic;
using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class Phase : AbstractKeyFrame, IDeserializable<Phase>
{
    public int StartFrame { get; set; }

    public AbstractKeyFrame[] KeyFrames { get; set; } = null!;

    public Phase() { }
    private Phase(XElement e)
    {
        StartFrame = e.GetIntAttribute("StartFrame", 0);
        KeyFrames = e.DeserializeKeyFrameChildren();
        foreach (AbstractKeyFrame k in KeyFrames)
            k.Parent = this;
    }
    public static Phase Deserialize(XElement e) => new(e);

    public override void Serialize(XElement e)
    {
        e.SetAttributeValue("StartFrame", StartFrame);
        e.AddManySerialized(KeyFrames);
    }

    public override void GetImplicitKeyFrames(List<KeyFrame> output, int index, int startFrame)
    {
        for (int i = 0; i < KeyFrames.Length; ++i)
            KeyFrames[i].GetImplicitKeyFrames(output, i, StartFrame);
    }
}