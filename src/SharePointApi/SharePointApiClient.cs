using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SharePointApi
{
    public class SharePointApiClient
    {
        private readonly HttpClient _client;

        public string SiteUrl { get; }

        public SharePointApiClient(string siteUrl)
        {
            SiteUrl = siteUrl;
            _client = new HttpClient(new HttpClientHandler() {UseDefaultCredentials = true, Credentials = CredentialCache.DefaultNetworkCredentials});
            _client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");;
        }

        //0x51EF88752773A42D692BFD064C61B7E21A8E0769F906B0D24ECD11BED7A8C17B9B32809F28EBE0EA3D6CB711292E2E31E876CD43160EFE3A63E23D345155EE6E,18 Jun 2017 22:21:55 -0000
        public string XRequestDigest { get; private set; }

        public int FormDigestTimeoutSeconds { get; private set; }

        public DateTime ExpiredOn { get; private set; }

        public bool IsExpired => DateTime.Now > this.ExpiredOn;

        public async Task<string> GetXRequestDigest()
        {
            var response = await _client.PostAsync($"{this.SiteUrl}/_api/contextinfo", null).ConfigureAwait(false);
            var bodyStr = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException(bodyStr);
            }

            var jsonToken = JObject.Parse(bodyStr).SelectToken("d.GetContextWebInformation");
            var xRequestDigest = jsonToken.Value<string>("FormDigestValue");
            var timeout = jsonToken.Value<int>("FormDigestTimeoutSeconds");
            var issuedDate = ToDateTime(xRequestDigest.Split(',')[1]);
            this.FormDigestTimeoutSeconds = timeout;
            this.ExpiredOn = issuedDate.AddSeconds(timeout - 300);
            this.XRequestDigest = xRequestDigest;

            return xRequestDigest;
        }

        public async Task<HttpResponseMessage> GetAsync(Uri uri, CancellationToken cancellationToken)
        {
            if (this.IsExpired)
            {
               await GetXRequestDigest();
            }

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            requestMessage.Headers.Add("X-RequestDigest", this.XRequestDigest);

            return await _client.SendAsync(requestMessage, cancellationToken);
        }

        private DateTime ToDateTime(string text)
        {
            DateTime dateTime;
            DateTime.TryParse(text, out dateTime);

            return dateTime;
        }
    }
}
