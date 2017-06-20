using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SharePointApi
{
    public class SpFolderRequestBuilder : BaseRequestBuilder
    {
        public SpFolderRequestBuilder(string siteUrl, string relativeUrl, SharePointApiClient client) : base(siteUrl, relativeUrl, client)
        {
            RequestUrl = $"{this.SiteUrl}/_api/web/GetFolderByServerRelativeUrl('{this.RelativeUrl}')";
        }

        public SpFolderRequestBuilder(string requestUrl, SharePointApiClient client) : base(requestUrl, client)
        {
            
        }


        public SpFolderRequestBuilder this[string index] => new SpFolderRequestBuilder(this.SiteUrl, this.AppendSegmentToRelativeUrl(index), this.Client);

        public SpFileCollectionRequestBuilder Files => new SpFileCollectionRequestBuilder(this.SiteUrl, this.RelativeUrl, this.Client);

        public SpFolderRequest Request()
        {
            return new SpFolderRequest(this.RequestUrl, Client);
        }
    }
}
