using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SharePointApi
{
    public class SpListItemCollectionRequestBuilder : BaseRequestBuilder
    {
        public string Title { get; }

        public SpListItemCollectionRequestBuilder(string siteUrl, string relativeUrl, string title, SharePointApiClient client) : base(siteUrl, relativeUrl, client)
        {
            Title = title;
            RequestUrl = $"{this.SiteUrl}/{this.RelativeUrl}/_api/web/Lists/Getbytitle('{this.Title}')/Items";
        }

        public SpListItemCollectionRequestBuilder(string requestUrl, SharePointApiClient client) : base(requestUrl, client)
        {
        }

        public SpListItemRequestBuilder this[int index] => new SpListItemRequestBuilder(this.SiteUrl, this.RelativeUrl, this.Title, index, this.Client);

        public SpListItemCollectionRequest Request()
        {
            return new SpListItemCollectionRequest(this.RequestUrl, Client);
        }

        public SpListItemCollectionRequestBuilder Where<T>(Expression<Func<T, bool>> predict)
        {
            return new SpListItemCollectionRequestBuilder(this.SiteUrl, this.RelativeUrl, this.Title, this.Client);
        }

        public SpListItemCollectionRequestBuilder Where(string filter)
        {
            this.RequestUrl = $"{this.SiteUrl}/{this.RelativeUrl}/_api/web/Lists/Getbytitle('{this.Title}')/Items?$filter={filter}";
            return this;
        }
    }
}
