using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class LevelSetType : IDeserializable<LevelSetType>, ISerializable
{
    private const string LEVEL_SET_TYPE_TEMPLATE_NAME = "Auto";
    private const string SKIP_ORDER_VALIDATION_TEMPLATE_STRING = "Don't abuse this to be lazy. It's for special cases like Bubble Tag where we explicitly want the order to be different.";

    public string LevelSetName { get; set; } = null!;

    public string DisplayNameKey { get; set; } = null!;
    public uint LevelSetID { get; set; }
    public string[] LevelTypes { get; set; } = null!;
    public bool? SkipOrderValidation { get; set; }

    private LevelSetType(XElement e)
    {
        LevelSetName = e.GetAttribute("LevelSetName");
        DisplayNameKey = e.GetElement("DisplayNameKey");
        LevelSetID = e.GetUIntElement("LevelSetID", 0);
        LevelTypes = e.GetElementOrNull("LevelTypes")?.Split(",") ?? [];
        SkipOrderValidation = e.GetBoolElementOrNull("SkipOrderValidation");
    }
    public static LevelSetType Deserialize(XElement e) => new(e);

    public void Serialize(XElement e)
    {
        e.SetAttributeValue("LevelSetName", LevelSetName);

        e.AddChild("DisplayNameKey", DisplayNameKey);
        e.AddChild("LevelSetID", LevelSetID);

        if (LevelSetName == LEVEL_SET_TYPE_TEMPLATE_NAME)
        {
            e.AddChild("SkipOrderValidation", SKIP_ORDER_VALIDATION_TEMPLATE_STRING);
            return;
        }

        e.AddIfNotNull("SkipOrderValidation", SkipOrderValidation);
        if (LevelTypes.Length > 0)
            e.AddChild("LevelTypes", string.Join(",", LevelTypes));
    }
}