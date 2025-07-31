using System.Xml.Linq;

namespace WallyMapSpinzor2;

public interface IDeserializable<T> where T : IDeserializable<T>
{
    static abstract T Deserialize(XElement e);
}