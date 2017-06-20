using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SharePointApi
{
    public class SpFileCollectionRequest : BaseRequest
    {
        public SpFileCollectionRequest(string requestUrl, SharePointApiClient client) : base(requestUrl, client)
        {
        }

        public Task<IEnumerable<SpFile>> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        public Task<IEnumerable<SpFile>> GetAsync(CancellationToken cancellationToken)
        {
            return this.GetIEnumerableAsync<SpFile>(cancellationToken);
        }
    }
}
