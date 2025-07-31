using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class GameModeHardCollision : AbstractCollision, IDeserializable<GameModeHardCollision>
{
    public GameModeHardCollision() : base() { }
    private GameModeHardCollision(XElement e) : base(e) { }
    public static GameModeHardCollision Deserialize(XElement e) => new(e);

    public override Color GetColor(RenderConfig config) => config.ColorGameModeHardCollision;
    public override CollisionTypeFlags CollisionType => CollisionTypeFlags.HARD | CollisionTypeFlags.GAMEMODE;
}