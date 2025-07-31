using System;
using System.Linq;
using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class LevelTypes : IDeserializable<LevelTypes>, ISerializable
{
    public LevelType[] Levels { get; set; } = null!;

    public const uint MAX_LEVEL_ID = 319;

    private LevelTypes(XElement e)
    {
        Levels = e.DeserializeChildrenOfType<LevelType>();
    }
    public static LevelTypes Deserialize(XElement e) => new(e);

    public void Serialize(XElement e)
    {
        e.AddManySerialized(Levels);
    }

    public void AddOrUpdateLevelType(LevelType lt)
    {
        int index = Array.FindIndex(Levels, l => l.LevelName == lt.LevelName);
        if (index == -1)
        {
            uint id = GetLargestLevelId() + 1;
            if (id > MAX_LEVEL_ID)
            {
                throw new ArgumentException($"Tried to add a leveltype with id bigger than {MAX_LEVEL_ID}");
            }

            lt.LevelID = id;
            Levels = [.. Levels, lt];
            return;
        }

        lt.LevelID = Levels[index].LevelID;
        Levels[index] = lt;
    }

    public uint GetLargestLevelId() => Levels.Select(l => l.LevelID).DefaultIfEmpty(0u).Max();
}