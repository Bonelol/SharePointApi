using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SharePointApi
{
    public class SpListCollectionRequest : BaseRequest
    {
        public SpListCollectionRequest(string requestUrl, SharePointApiClient client) : base(requestUrl, client)
        {
        }

        public Task<IEnumerable<SpList>> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        public Task<IEnumerable<SpList>> GetAsync(CancellationToken cancellationToken)
        {
            return this.GetIEnumerableAsync<SpList>(cancellationToken);
        }
    }
}
