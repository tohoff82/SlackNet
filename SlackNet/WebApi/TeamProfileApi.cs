using System.Threading;
using System.Threading.Tasks;
using Args = System.Collections.Generic.Dictionary<string, object>;

namespace SlackNet.WebApi
{
    public class TeamProfileApi
    {
        private readonly SlackApiClient _client;
        public TeamProfileApi(SlackApiClient client) => _client = client;

        /// <summary>
        /// Used to get the profile field definitions for this team.
        /// </summary>
        /// <param name="visibility">Filter by visibility.</param>
        /// <param name="cancellationToken"></param>
        public async Task<TeamProfile> Get(ProfileFieldVisibility visibility = ProfileFieldVisibility.All, CancellationToken? cancellationToken = null) =>
            (await _client.Get<TeamProfileResponse>("team.profile.get", new Args { { "visibility", visibility } }, cancellationToken).ConfigureAwait(false)).Profile;
    }
}