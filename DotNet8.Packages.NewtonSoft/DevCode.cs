namespace DotNet8.Packages.NewtonSoft;

public static class DevCode
{
    public static string ToJson(this object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    public static T ToObject<T>(this string jsonStr)
    {
        return JsonConvert.DeserializeObject<T>(jsonStr)!;
    }
}
