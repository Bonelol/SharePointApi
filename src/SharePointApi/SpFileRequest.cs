using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SharePointApi
{
    public class SpFileRequest : BaseRequest
    {
        public SpFileRequest(string requestUrl, SharePointApiClient client) : base(requestUrl, client)
        {
        }

        public Task<SpFile> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        public Task<SpFile> GetAsync(CancellationToken cancellationToken)
        {
            return this.GetObjectAsync<SpFile>(cancellationToken);
        }
    }
}
