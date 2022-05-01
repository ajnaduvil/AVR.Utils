using Unity.Plastic.Newtonsoft.Json;

public static partial class ObjectExtensions
{
    public static T DeepClone<T>(this T obj)
    {
        var str = JsonConvert.SerializeObject(obj);
        var deObj = JsonConvert.DeserializeObject<T>(str);
        return deObj;
    }
}
