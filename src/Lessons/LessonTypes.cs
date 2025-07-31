using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class LessonTypes : IDeserializable<LessonTypes>, ISerializable
{
    public LessonType[] Lessons { get; set; } = null!;

    private LessonTypes(XElement e)
    {
        Lessons = e.DeserializeChildrenOfType<LessonType>();
    }
    public static LessonTypes Deserialize(XElement e) => new(e);

    public void Serialize(XElement e)
    {
        e.AddManySerialized(Lessons);
    }
}