using System.Threading;
using System.Threading.Tasks;

namespace SharePointApi
{
    public class SpFolderRequest : BaseRequest
    {
        public SpFolderRequest(string requestUrl, SharePointApiClient client) : base(requestUrl, client)
        {
        }

        public Task<SpFolder> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        public Task<SpFolder> GetAsync(CancellationToken cancellationToken)
        {
            return this.GetObjectAsync<SpFolder>(cancellationToken);
        }
    }
}
