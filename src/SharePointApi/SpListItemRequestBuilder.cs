using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharePointApi
{
    public class SpListItemRequestBuilder : BaseRequestBuilder
    {
        public string Title { get; }
        public int Id { get; }

        public SpListItemRequestBuilder(string siteUrl, string relativeUrl, string title, int id, SharePointApiClient client) : base(siteUrl, relativeUrl, client)
        {
            Title = title;
            Id = id;
            RequestUrl = $"{this.SiteUrl}/{this.RelativeUrl}/_api/web/Lists/Getbytitle('{this.Title}')/Items({this.Id})";
        }

        public SpListItemRequestBuilder(string requestUrl, SharePointApiClient client) : base(requestUrl, client)
        {
        }

        public SpListItemRequest Request()
        {
            return new SpListItemRequest(this.RequestUrl, Client);
        }
    }
}
