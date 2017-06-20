using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SharePointApi
{
    public class SpListRequestBuilder : BaseRequestBuilder
    {
        public string Title { get; }

        public SpListRequestBuilder(string siteUrl, string relativeUrl, string title, SharePointApiClient client) : base(siteUrl, relativeUrl, client)
        {
            this.Title = title;
            this.RequestUrl = $"{this.SiteUrl}/{this.RelativeUrl}/_api/web/Lists/Getbytitle('{this.Title}')";
        }

        public SpListRequestBuilder(string requestUrl, SharePointApiClient client) : base(requestUrl, client)
        {
        }
        
        public SpListItemCollectionRequestBuilder Items => new SpListItemCollectionRequestBuilder(this.SiteUrl, this.RelativeUrl, this.Title, this.Client);

        public SpListRequest Request()
        {
            return new SpListRequest(this.RequestUrl, Client);
        }
    }
}
