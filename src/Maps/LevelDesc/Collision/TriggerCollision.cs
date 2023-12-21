namespace WallyMapSpinzor2;

public class TriggerCollision : AbstractCollision
{
    public override Color GetColor(RenderConfig config) => config.ColorTriggerCollision;
    public override CollisionTypeEnum CollisionType => CollisionTypeEnum.TRIGGER;
}
