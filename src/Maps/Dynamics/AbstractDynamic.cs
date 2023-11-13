using System.Xml.Linq;

namespace WallyMapSpinzor2;

public abstract class AbstractDynamic<T> : ISerializable, IDeserializable, IDrawable
    where T : ISerializable, IDeserializable, IDrawable
{
    public string PlatID{get; set;} = null!;
    public double X{get; set;}
    public double Y{get; set;}
    public List<T> Children{get; set;} = null!;

    public abstract void DeserializeChildren(XElement element);

    public void Deserialize(XElement element)
    {
        PlatID = element.GetAttribute("PlatID");
        X = element.GetFloatAttribute("X");
        Y = element.GetFloatAttribute("Y");
        DeserializeChildren(element);
    }

    public XElement Serialize()
    {
        XElement e = new(GetType().Name);

        e.SetAttributeValue("PlatID", PlatID);
        e.SetAttributeValue("X", X.ToString());
        e.SetAttributeValue("Y", Y.ToString());
        
        foreach(T c in Children)
            e.Add(c.Serialize());

        return e;
    }

    public void DrawOn<TTexture>
    (ICanvas<TTexture> canvas, GlobalRenderData rd, RenderSettings rs, Transform t, double time) 
        where TTexture : ITexture
    {
        if(rd.PlatIDDict is null)
            throw new InvalidOperationException($"Plat ID dictionary was null when attempting to draw {GetType().Name}");
        if(!rd.PlatIDDict.ContainsKey(PlatID))
            throw new InvalidOperationException($"Plat ID dictionary did not contain plat id {PlatID} when attempting to draw {GetType().Name}. Make sure to call StoreOffset on all MovingPlatforms.");
        (double _X, double _Y) = rd.PlatIDDict[PlatID];
        Transform tt = t * Transform.CreateTranslate(X + _X, Y + _Y);
        foreach(T c in Children)
            c.DrawOn(canvas, rd, rs, tt, time);
    }
}