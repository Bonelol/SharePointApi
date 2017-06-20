using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SharePointApi
{
    public class SpFileRequestBuilder : BaseRequestBuilder
    {
        public string FileName { get; }

        public SpFileRequestBuilder(string siteUrl, string relativeUrl, string fileName, SharePointApiClient client) : base(siteUrl, relativeUrl, client)
        {
            this.FileName = fileName;
            this.RequestUrl = $"{this.SiteUrl}/_api/web/GetFolderByServerRelativeUrl('{this.RelativeUrl}')/Files('{this.FileName}')";
        }

        public SpFileRequestBuilder(string requestUrl, SharePointApiClient client) : base(requestUrl, client)
        {
            
        }

        public SpFileRequest Request()
        {
            return new SpFileRequest(this.RequestUrl, Client);
        }
    }
}
