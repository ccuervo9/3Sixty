using System.Linq;

namespace  Infrastructure.Helper
{
    public static class JsonOperations
    {
        public static string ToJson(params object[] objects)
        {
            string json = string.Join(",", objects.Select(o => Newtonsoft.Json.JsonConvert.SerializeObject(o)));
            return json;

        }

    }
}
