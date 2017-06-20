using System.Threading;
using System.Threading.Tasks;

namespace SharePointApi
{
    public class SpListItemRequest : BaseRequest
    {
        public SpListItemRequest(string requestUrl, SharePointApiClient client) : base(requestUrl, client)
        {
        }

        public Task<SpListItem> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        public Task<SpListItem> GetAsync(CancellationToken cancellationToken)
        {
            return this.GetObjectAsync<SpListItem>(cancellationToken);
        }
    }
}
