using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using BlockBase.Cli.Helpers;

namespace BlockBase.Cli.Services
{
    public class BlockBaseProviderService : IBlockBaseProviderService
    {
        private const string ProviderEndpoint = "/api/Provider";

        public async Task<string> CheckProducerConfig(string endpoint)
        {
            var requestEndpoint = "/CheckProducerConfig";

            var request = HttpHelper.ComposeWebRequestGet(endpoint + ProviderEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> RequestToProduceSidechain(string endpoint, string sidechainName, int providerType, decimal stake = 0)
        {
            var requestEndpoint = "/RequestToProduceSidechain";

            var query = new Dictionary<string, string>();
            query.Add("chainName", sidechainName);
            query.Add("providerType", providerType.ToString());
            query.Add("stake", stake.ToString());
            
            var request = HttpHelper.ComposeWebRequestPost(endpoint + ProviderEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> RemoveCandidature(string endpoint, string sidechainName)
        {
            var requestEndpoint = "/RemoveCandidature";

            var query = new Dictionary<string, string>();
            query.Add("sidechainName", sidechainName);
            
            var request = HttpHelper.ComposeWebRequestPost(endpoint + ProviderEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> RequestToLeaveSidechainProduction(string endpoint, string sidechainName, bool cleanLocalSidechainData = false)
        {
            var requestEndpoint = "/RequestToLeaveSidechainProduction";

            var query = new Dictionary<string, string>();
            query.Add("sidechainName", sidechainName);
            query.Add("cleanLocalSidechainData", cleanLocalSidechainData.ToString());
            
            var request = HttpHelper.ComposeWebRequestPost(endpoint + ProviderEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> AddStake(string endpoint, string sidechainName, double stake)
        {
            var requestEndpoint = "/AddStake";

            var query = new Dictionary<string, string>();
            query.Add("sidechainName", sidechainName);
            query.Add("stake", stake.ToString());
            
            var request = HttpHelper.ComposeWebRequestPost(endpoint + ProviderEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> ClaimStake(string endpoint, string sidechainName)
        {
            var requestEndpoint = "/ClaimStake";

            var query = new Dictionary<string, string>();
            query.Add("sidechainName", sidechainName);
            
            var request = HttpHelper.ComposeWebRequestPost(endpoint + ProviderEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> ClaimAllRewards(string endpoint)
        {
            var requestEndpoint = "/ClaimAllRewards";
            
            var request = HttpHelper.ComposeWebRequestPost(endpoint + ProviderEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> GetProducingSidechains(string endpoint)
        {
            var requestEndpoint = "/GetProducingSidechains";
            
            var request = HttpHelper.ComposeWebRequestGet(endpoint + ProviderEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> GetPastSidechains(string endpoint)
        {
            var requestEndpoint = "/GetPastSidechains";
            
            var request = HttpHelper.ComposeWebRequestGet(endpoint + ProviderEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> DeleteSidechainFromDatabase(string endpoint, string sidechainName, bool force = false)
        {
            var requestEndpoint = "/DeleteSidechainFromDatabase";

            var query = new Dictionary<string, string>();
            query.Add("sidechainName", sidechainName);
            query.Add("force", force.ToString());
            
            var request = HttpHelper.ComposeWebRequestPost(endpoint + ProviderEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> GetBlock(string endpoint, string sidechainName, int blockNumber)
        {
            var requestEndpoint = "/GetBlock";

            var query = new Dictionary<string, string>();
            query.Add("chainName", sidechainName);
            query.Add("blockNumber", blockNumber.ToString());
            
            var request = HttpHelper.ComposeWebRequestGet(endpoint + ProviderEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> GetTransaction(string endpoint, string sidechainName, int transactionNumber)
        {
            var requestEndpoint = "/GetTransaction";

            var query = new Dictionary<string, string>();
            query.Add("chainName", sidechainName);
            query.Add("transactionNumber", transactionNumber.ToString());
            
            var request = HttpHelper.ComposeWebRequestGet(endpoint + ProviderEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> GetTransactionsInMempool(string endpoint, string sidechainName)
        {
            var requestEndpoint = "/GetTransactionsInMempool";

            var query = new Dictionary<string, string>();
            query.Add("sidechainName", sidechainName);
            
            var request = HttpHelper.ComposeWebRequestGet(endpoint + ProviderEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> GetSidechainNodeSoftwareVersion(string endpoint, string sidechainName)
        {
            var requestEndpoint = "/GetSidechainNodeSoftwareVersion";

            var query = new Dictionary<string, string>();
            query.Add("sidechainName", sidechainName);
            
            var request = HttpHelper.ComposeWebRequestGet(endpoint + ProviderEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> GetDecryptedNodeIps(string endpoint, string sidechainName)
        {
            var requestEndpoint = "/GetDecryptedNodeIps";

            var query = new Dictionary<string, string>();
            query.Add("sidechainName", sidechainName);
            
            var request = HttpHelper.ComposeWebRequestGet(endpoint + ProviderEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }
    }
}