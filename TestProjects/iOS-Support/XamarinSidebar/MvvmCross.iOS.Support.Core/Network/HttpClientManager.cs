using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform.Platform;
using Newtonsoft.Json;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.Core.Network
{
    public class HttpClientManager
    {
        public static async Task<Response<TOutput>> ExecuteGetAsync<TOutput>(string relativeUrl, Dictionary<string, string> parameters)
          where TOutput : class, new()
        {
            var url = relativeUrl;
            if (string.IsNullOrWhiteSpace(url))
            {
                return ResponseFactory.CreateResponse<TOutput>(false, 27);
            }

            using (var client = new HttpClient())
            {
                SetupHttpClient(client);

                try
                {
                    if (parameters != null && parameters.Count > 0)
                    {
                        var queryString = GenerateQueryString(parameters);
                        if (!string.IsNullOrWhiteSpace(queryString))
                        {
                            url = $"{url}{queryString}";
                        }
                    }

                    url = $"{Constants.WEB_API_BASE_ROOT_URL}/api/{url}";

                    Debug.WriteLine("____________________________________________________");
                    Debug.WriteLine("Calling endpoint: {0}", url);
                    Debug.WriteLine("____________________________________________________");

                    var response = await client.GetAsync(url).ConfigureAwait(false);
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        var stringfiedContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        Debug.WriteLine("____________________________________________________");
                        Debug.WriteLine("Got answer from endpoint {0}: {1}", url, stringfiedContent);
                        Debug.WriteLine("____________________________________________________");

                        var deserializedData = string.IsNullOrWhiteSpace(stringfiedContent)
                            ? ResponseFactory.CreateResponse<TOutput>(false, 19)
                            : DeserializeResponse<TOutput>(stringfiedContent);

                        return deserializedData;
                    }
                }
                catch (Exception ex)
                {
                    MvxTrace.Warning(ex.ToString());
                }
            }

            return ResponseFactory.CreateResponse<TOutput>(false, 19);
        }

        public static Response<T> DeserializeResponse<T>(string stringfiedContent) where T : class, new()
        {
            try
            {
                return string.IsNullOrWhiteSpace(stringfiedContent)
                     ? null
                     : JsonConvert.DeserializeObject<Response<T>>(stringfiedContent);
            }
            catch (Exception ex)
            {
                MvxTrace.Error(ex.ToString());
                return null;
            }
        }

        public static string GenerateQueryString(Dictionary<string, string> parameters)
        {
            if (parameters == null)
            {
                return null;
            }

            var count = 0;
            var sb = new StringBuilder();
            foreach (var entry in parameters)
            {
                if (count == 0)
                {
                    sb.Append("?");
                }
                else
                {
                    if (count != parameters.Count)
                    {
                        sb.Append("&");
                    }
                }
                sb.Append($"{entry.Key}={entry.Value}");
                count++;
            }

            return sb.ToString();
        }

        public static void SetupHttpClient(HttpClient client)
        {
            client.Timeout = TimeSpan.FromSeconds(60);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(Constants.WEB_API_BASE_ROOT_URL);
        }
    }
}
