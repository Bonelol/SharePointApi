namespace SharePointApi
{
    public class SharePointApi
    {
        public SharePointApiClient Client { get; }
        public string BaseUrl { get; }

        public SharePointApi(string baseUrl)
        {
            BaseUrl = baseUrl;
            Client = new SharePointApiClient(baseUrl);
        }

        public SharePointApi(SharePointApiClient client)
        {
            BaseUrl = client.SiteUrl;
            Client = client;
        }

        public SpFolderRequestBuilder Folder => new SpFolderRequestBuilder(this.BaseUrl, "", Client);
        public SpListCollectionRequestBuilder Lists => new SpListCollectionRequestBuilder(this.BaseUrl, "", Client);
    }
}
