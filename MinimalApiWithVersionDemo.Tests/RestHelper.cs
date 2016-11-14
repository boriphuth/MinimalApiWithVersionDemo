using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Authenticators;

namespace MinimalApiWithVersionDemo.Tests
{
    public static class RestHelper
    {
        public static IRestResponse PostBasicAuthenication(string baseUrl, string resourceUrl, string userName
            , string password, string json)
        {
            var client = new RestClient(baseUrl) {Authenticator = new HttpBasicAuthenticator(userName, password)};
            var request = new RestRequest(resourceUrl, Method.POST);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            return client.Execute(request);
        }
        public static IRestResponse Post(string baseUrl, string resourceUrl, string json)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resourceUrl, Method.POST);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            return client.Execute(request);
        }

        public static IRestResponse Get(string baseUrl, string resourceUrl)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resourceUrl, Method.GET);
            request.AddParameter("application/json; charset=utf-8", ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            return client.Execute(request);
        }

        public static string ConvertObjectToJason<T>(T arg)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
            };
            // Create Json.Net formatter serializing DateTime using the ISO 8601 format
            settings.Converters.Add(new IsoDateTimeConverter());
            var result = JsonConvert.SerializeObject(arg, settings);
            return result;
        }


        public static T GetResponseObjectResult<T>(IRestResponse response)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };
            // Create Json.Net formatter serializing DateTime using the ISO 8601 format
            settings.Converters.Add(new IsoDateTimeConverter());
            var result = JsonConvert.DeserializeObject<T>(response.Content, settings);
            //var result = JSON.Deserialize<T>(response.Content);
            return result;
        }

        public static T GetJasonObjectResult<T>(string json)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            // Create Json.Net formatter serializing DateTime using the ISO 8601 format
            settings.Converters.Add(new IsoDateTimeConverter());
            var result = JsonConvert.DeserializeObject<T>(json, settings);
            //var result = JSON.Deserialize<T>(json);
            return result;
        }

        public static byte[] ConvertJSonStringToByteArray(string jsonByteString)
        {
            jsonByteString = jsonByteString.Substring(1, jsonByteString.Length - 2);
            string[] arr = jsonByteString.Split(',');
            byte[] bResult = new byte[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                bResult[i] = byte.Parse(arr[i]);
            }
            return bResult;
        }

    }
}
