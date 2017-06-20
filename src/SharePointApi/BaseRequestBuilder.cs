namespace SharePointApi
{
    public class BaseRequestBuilder

    {
        public BaseRequestBuilder(string siteUrl, string relativeUrl, SharePointApiClient client)
        {
            this.Client = client;
            this.SiteUrl = siteUrl;
            this.RelativeUrl = relativeUrl;
        }

        public BaseRequestBuilder(string requestUrl, SharePointApiClient client)
        {
            this.Client = client;
            this.RequestUrl = requestUrl;
        }

        public SharePointApiClient Client { get; private set; }

        public string RequestUrl { get; internal set; }

        public string SiteUrl { get; private set; }

        public string RelativeUrl { get; private set; }

        public string AppendSegmentToRequestUrl(string urlSegment)
        {
            return string.IsNullOrEmpty(this.RelativeUrl) ? urlSegment : string.Format("{0}/{1}", this.RequestUrl, urlSegment);
        }

        public string AppendSegmentToRelativeUrl(string urlSegment)
        {
            return string.IsNullOrEmpty(this.RelativeUrl) ? urlSegment : string.Format("{0}/{1}", this.RelativeUrl, urlSegment);
        }
    }
}
