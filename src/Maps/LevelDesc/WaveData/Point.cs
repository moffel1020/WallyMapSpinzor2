using System.Xml.Linq;

namespace WallyMapSpinzor2;

public sealed class Point : IDeserializable<Point>, ISerializable, IDrawable
{
    public double X { get; set; }
    public double Y { get; set; }

    public CustomPath? Parent { get; set; }

    public Point() { }
    private Point(XElement e)
    {
        X = e.GetDoubleAttribute("X");
        Y = e.GetDoubleAttribute("Y");
    }
    public static Point Deserialize(XElement e) => new(e);

    public void Serialize(XElement e)
    {
        e.SetAttributeValue("X", X);
        e.SetAttributeValue("Y", Y);
    }

    public void DrawOn(ICanvas canvas, Transform trans, RenderConfig config, RenderContext context, RenderState state)
    {
        canvas.DrawCircle(X, Y, config.RadiusHordePathPoint, config.ColorHordePath, trans, DrawPriorityEnum.DATA, this);
    }
}