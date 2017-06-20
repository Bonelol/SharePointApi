namespace SharePointApi
{
    public class SpFileCollectionRequestBuilder : BaseRequestBuilder
    {
        public SpFileCollectionRequestBuilder(string siteUrl, string relativeUrl, SharePointApiClient client) : base(siteUrl, relativeUrl, client)
        {
            this.RequestUrl = $"{this.SiteUrl}/_api/web/GetFolderByServerRelativeUrl('{this.RelativeUrl}')/Files";
        }

        public SpFileCollectionRequestBuilder(string requestUrl, SharePointApiClient client) : base(requestUrl, client)
        {
        }

        public SpFileRequestBuilder this[string index] => new SpFileRequestBuilder(this.SiteUrl, this.RelativeUrl, index, this.Client);

        public SpFileCollectionRequest Request()
        {
            return new SpFileCollectionRequest(this.RequestUrl, Client);
        }
    }
}
