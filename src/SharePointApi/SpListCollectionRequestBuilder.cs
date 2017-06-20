using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharePointApi
{
    public class SpListCollectionRequestBuilder : BaseRequestBuilder
    {
        public SpListCollectionRequestBuilder(string siteUrl, string relativeUrl, SharePointApiClient client) : base(siteUrl, relativeUrl, client)
        {
            this.RequestUrl = $"{this.SiteUrl}/{this.RelativeUrl}/_api/web/Lists";
        }

        public SpListCollectionRequestBuilder(string requestUrl, SharePointApiClient client) : base(requestUrl, client)
        {
        }

        public SpListRequestBuilder this[string index] => new SpListRequestBuilder(this.SiteUrl, this.RelativeUrl, index, this.Client);

        public SpFileCollectionRequest Request()
        {
            return new SpFileCollectionRequest(this.RequestUrl, Client);
        }
    }
}
