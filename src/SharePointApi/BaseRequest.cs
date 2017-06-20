using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SharePointApi
{
    public class BaseRequest
    {
        public string RequestUrl { get; }
        private readonly SharePointApiClient _client;

        public BaseRequest(string requestUrl, SharePointApiClient client)
        {
            RequestUrl = requestUrl;
            _client = client;
        }

        public async Task<HttpResponseMessage> GetResponseAsync(CancellationToken cancellationToken)
        {
            if (_client.IsExpired)
            {
                await _client.GetXRequestDigest();
            }

            return await _client.GetAsync(new Uri(RequestUrl), cancellationToken);
        }

        public async Task<T> GetObjectAsync<T>(CancellationToken cancellationToken)
        {
            var response = await this.GetResponseAsync(cancellationToken).ConfigureAwait(false);
            var bodyStr = await response.Content.ReadAsStringAsync();

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    var obj = JObject.Parse(bodyStr)["d"].ToObject<T>();
                    return obj;
                case HttpStatusCode.NotFound:
                default:
                    throw new HttpRequestException(bodyStr);
            }
        }

        public async Task<IEnumerable<T>> GetIEnumerableAsync<T>(CancellationToken cancellationToken)
        {
            var response = await this.GetResponseAsync(cancellationToken).ConfigureAwait(false);
            var bodyStr = await response.Content.ReadAsStringAsync();

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    var enumerable = JObject.Parse(bodyStr)["d"]["results"].ToObject<IEnumerable<T>>();
                    return enumerable;
                case HttpStatusCode.NotFound:
                default:
                    throw new HttpRequestException(bodyStr);
            }
        }
    }
}
