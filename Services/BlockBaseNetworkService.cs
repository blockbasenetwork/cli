using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using BlockBase.Cli.Helpers;

namespace BlockBase.Cli.Services
{
    public class BlockBaseNetworkService : IBlockBaseNetworkService
    {
        private const string NetworkEndpoint = "/api/Network";

        public async Task<string> GetSidechainConfiguration(string endpoint, string sidechainName)
        {
            var requestEndpoint = "/GetSidechainConfiguration";

            var query = new Dictionary<string, string>();
            query.Add("sidechainName", sidechainName);

            var request = HttpHelper.ComposeWebRequestGet(endpoint + NetworkEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> GetAccountStakeRecords(string endpoint, string accountName)
        {
            var requestEndpoint = "/GetAccountStakeRecords";

            var query = new Dictionary<string, string>();
            query.Add("accountName", accountName);
            
            var request = HttpHelper.ComposeWebRequestGet(endpoint + NetworkEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> GetProducerCandidatureState(string endpoint, string accountName, string sidechainName)
        {
            var requestEndpoint = "/GetProducerCandidatureState";

            var query = new Dictionary<string, string>();
            query.Add("accountName", accountName);
            query.Add("sidechainName", sidechainName);
            
            var request = HttpHelper.ComposeWebRequestGet(endpoint + NetworkEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> GetSidechainState(string endpoint, string sidechainName)
        {
            var requestEndpoint = "/GetSidechainState";

            var query = new Dictionary<string, string>();
            query.Add("sidechainName", sidechainName);
            
            var request = HttpHelper.ComposeWebRequestGet(endpoint + NetworkEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> GetCurrentUnclaimedRewards(string endpoint, string accountName)
        {
            var requestEndpoint = "/GetCurrentUnclaimedRewards";

            var query = new Dictionary<string, string>();
            query.Add("accountName", accountName);
            
            var request = HttpHelper.ComposeWebRequestGet(endpoint + NetworkEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> GetPeerConnectionsState(string endpoint)
        {
            var requestEndpoint = "/GetPeerConnectionsState";
            
            var request = HttpHelper.ComposeWebRequestGet(endpoint + NetworkEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }
    }
}