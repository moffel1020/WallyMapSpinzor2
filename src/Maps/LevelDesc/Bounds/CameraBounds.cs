using System.Xml.Linq;

namespace WallyMapSpinzor2;

public class CameraBounds : IDeserializable, ISerializable, IDrawable
{
    public double H { get; set; }
    public double W { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public void Deserialize(XElement e)
    {
        H = e.GetFloatAttribute("H", 0);
        W = e.GetFloatAttribute("W", 0);
        X = e.GetFloatAttribute("X", 0);
        Y = e.GetFloatAttribute("Y", 0);
    }

    public void Serialize(XElement e)
    {
        e.SetAttributeValue("H", H);
        e.SetAttributeValue("W", W);
        e.SetAttributeValue("X", X);
        e.SetAttributeValue("Y", Y);
    }

    public void DrawOn(ICanvas canvas, Transform trans, RenderConfig config, RenderContext context, RenderState state)
    {
        context.BackgroundRect_X = X;
        context.BackgroundRect_Y = Y;
        context.BackgroundRect_W = W;
        context.BackgroundRect_H = H;

        if (!config.ShowCameraBounds) return;
        canvas.DrawRect(X, Y, W, H, false, config.ColorCameraBounds, trans, DrawPriorityEnum.DATA, this);
    }
}