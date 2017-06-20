using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SharePointApi
{
    public class SpListRequest : BaseRequest
    {
        public SpListRequest(string requestUrl, SharePointApiClient client) : base(requestUrl, client)
        {
        }

        public Task<SpList> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        public Task<SpList> GetAsync(CancellationToken cancellationToken)
        {
            return this.GetObjectAsync<SpList>(cancellationToken);
        }
    }
}
