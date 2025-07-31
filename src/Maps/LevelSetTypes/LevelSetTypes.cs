using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class LevelSetTypes : IDeserializable<LevelSetTypes>, ISerializable
{
    public LevelSetType[] Playlists { get; set; } = null!;

    private LevelSetTypes(XElement e)
    {
        Playlists = e.DeserializeChildrenOfType<LevelSetType>();
    }
    public static LevelSetTypes Deserialize(XElement e) => new(e);

    public void Serialize(XElement e)
    {
        e.AddManySerialized(Playlists);
    }
}