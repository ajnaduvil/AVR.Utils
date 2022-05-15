using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static partial class ObjectExtensions
{
    /// <summary>
     /// A faster implementation of deepclone using binary formatter
     /// </summary>
     /// <param name="obj">Object to be cloned</param>
     /// <returns></returns>
    public static T DeepClone<T>(this T obj)
    {
        using (var ms = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Position = 0;
            return (T)formatter.Deserialize(ms);
        }
    }
}
