using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowBddFramework.Core
{
    public class ContentHelpers
    {
        public static T? GetContent<T>(RestResponse restResponse)
        {
            var content = restResponse.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }

        public static object? GetResponse(RestResponse restResponse)
        {
            var content = restResponse.Content;
            return JsonConvert.DeserializeObject(content);
        }

        public static string? SerialiJsonString(dynamic content)
        {
            return JsonConvert.SerializeObject(content, Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
        }

        public static T? ParseJson<T>(string file)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
        }
    }
}
