using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SharePointApi
{
    public class SpListItemCollectionRequest : BaseRequest
    {
        public SpListItemCollectionRequest(string requestUrl, SharePointApiClient client) : base(requestUrl, client)
        {
        }

        public Task<IEnumerable<SpListItem>> GetAsync()
        {
            return GetAsync<SpListItem>(CancellationToken.None);
        }

        public Task<IEnumerable<SpListItem>> GetAsync(CancellationToken cancellationToken)
        {
            return this.GetIEnumerableAsync<SpListItem>(cancellationToken);
        }

        public Task<IEnumerable<T>> GetAsync<T>() where T : SpListItem
        {
            return this.GetIEnumerableAsync<T>(CancellationToken.None);
        }

        public Task<IEnumerable<T>> GetAsync<T>(CancellationToken cancellationToken) where T: SpListItem
        {
            return this.GetIEnumerableAsync<T>(cancellationToken);
        }
    }
}
