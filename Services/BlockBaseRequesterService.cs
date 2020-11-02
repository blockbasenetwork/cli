using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using BlockBase.Cli.Helpers;

namespace BlockBase.Cli.Services
{
    public class BlockBaseRequesterService : IBlockBaseRequesterService
    {
        private const string RequesterEndpoint = "/api/Requester";

        public async Task<string> CheckRequesterConfig(string endpoint)
        {
            var requestEndpoint = "/CheckRequesterConfig";

            var request = HttpHelper.ComposeWebRequestGet(endpoint + RequesterEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> CheckCurrentStakeInSidechain(string endpoint)
        {
            var requestEndpoint = "/CheckCurrentStakeInSidechain";

            var request = HttpHelper.ComposeWebRequestGet(endpoint + RequesterEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> RequestNewSidechain(string endpoint, decimal stake = 0)
        {
            var requestEndpoint = "/RequestNewSidechain";

            var query = new Dictionary<string, string>();
            query.Add("stake", stake.ToString());
            
            var request = HttpHelper.ComposeWebRequestPost(endpoint + RequesterEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> SetSecret(string endpoint)
        {
            var requestEndpoint = "/SetSecret";

            var request = HttpHelper.ComposeWebRequestGet(endpoint + RequesterEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> RunSidechainMaintenance(string endpoint)
        {
            var requestEndpoint = "/RunSidechainMaintenance";

            var request = HttpHelper.ComposeWebRequestGet(endpoint + RequesterEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> PauseSidechain(string endpoint)
        {
            var requestEndpoint = "/PauseSidechain";

            var request = HttpHelper.ComposeWebRequestGet(endpoint + RequesterEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> EndSidechain(string endpoint)
        {
            var requestEndpoint = "/EndSidechain";

            var request = HttpHelper.ComposeWebRequestGet(endpoint + RequesterEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> AddStake(string endpoint, double stake)
        {
            var requestEndpoint = "/AddStake";

            var query = new Dictionary<string, string>();
            query.Add("stake", stake.ToString());

            var request = HttpHelper.ComposeWebRequestGet(endpoint + RequesterEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> ClaimStake(string endpoint)
        {
            var requestEndpoint = "/ClaimStake";

            var request = HttpHelper.ComposeWebRequestGet(endpoint + RequesterEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> GenerateMasterKey(string endpoint)
        {
            var requestEndpoint = "/GenerateMasterKey";

            var request = HttpHelper.ComposeWebRequestGet(endpoint + RequesterEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> ExecuteQuery(string endpoint, string queryScript)
        {
            var requestEndpoint = "/ExecuteQuery";

            var query = new Dictionary<string, string>();
            query.Add("queryScript", queryScript);
            
            var request = HttpHelper.ComposeWebRequestPost(endpoint + RequesterEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> GetStructure(string endpoint)
        {
            var requestEndpoint = "/GetStructure";

            var request = HttpHelper.ComposeWebRequestGet(endpoint + RequesterEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> RemoveSidechainDatabasesAndKeys(string endpoint)
        {
            var requestEndpoint = "/RemoveSidechainDatabasesAndKeys";

            var request = HttpHelper.ComposeWebRequestGet(endpoint + RequesterEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> GetDecryptedNodeIps(string endpoint)
        {
            var requestEndpoint = "/GetDecryptedNodeIps";

            var request = HttpHelper.ComposeWebRequestGet(endpoint + RequesterEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> RemoveAccountFromBlacklist(string endpoint, string account)
        {
            var requestEndpoint = "/RemoveAccountFromBlacklist";

            var query = new Dictionary<string, string>();
            query.Add("account", account);

            var request = HttpHelper.ComposeWebRequestGet(endpoint + RequesterEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> CheckSidechainReservedSeats(string endpoint)
        {
            var requestEndpoint = "/CheckSidechainReservedSeats";

            var request = HttpHelper.ComposeWebRequestGet(endpoint + RequesterEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> RemoveReservedSeats(string endpoint, List<string> reservedSeatsToRemove)
        {
            var requestEndpoint = "/RemoveReservedSeats";

            var query = new Dictionary<string, string>();
            query.Add("reservedSeatsToRemove", "{" + String.Join(",", reservedSeatsToRemove) + "}");

            var request = HttpHelper.ComposeWebRequestGet(endpoint + RequesterEndpoint + requestEndpoint, query);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }

        public async Task<string> ChangeSidechainConfigurations(string endpoint, decimal? maxPaymentPerBlockFullProducer, decimal? minPaymentPerBlockFullProducer,
                                                                      decimal? maxPaymentPerBlockHistoryProducer, decimal? minPaymentPerBlockHistoryProducer,
                                                                      decimal? maxPaymentPerBlockValidatorProducer, decimal? minPaymentPerBlockValidatorProducer,
                                                                      decimal? minCandidatureStake, int? numberOfFullProducersRequired,
                                                                      int? numberOfHistoryProducersRequired, int? numberOfValidatorProducersRequired,
                                                                      int? blockTimeInSeconds, long? blockSizeInBytes)
        {
            var requestEndpoint = "/ChangeSidechainConfigurations";

            var query = new Dictionary<string, string>();
            if (maxPaymentPerBlockFullProducer != null)
                query.Add("maxPaymentPerBlockFullProducer", maxPaymentPerBlockFullProducer.ToString());
            if (minPaymentPerBlockFullProducer != null)
                query.Add("minPaymentPerBlockFullProducer", minPaymentPerBlockFullProducer.ToString());
            if (maxPaymentPerBlockHistoryProducer != null)
                query.Add("maxPaymentPerBlockHistoryProducer", maxPaymentPerBlockHistoryProducer.ToString());
            if (minPaymentPerBlockHistoryProducer != null)
                query.Add("minPaymentPerBlockHistoryProducer", minPaymentPerBlockHistoryProducer.ToString());
            if (maxPaymentPerBlockValidatorProducer != null)
                query.Add("maxPaymentPerBlockValidatorProducer", maxPaymentPerBlockValidatorProducer.ToString());
            if (minPaymentPerBlockValidatorProducer != null)
                query.Add("minPaymentPerBlockValidatorProducer", minPaymentPerBlockValidatorProducer.ToString());
            if (minCandidatureStake != null)
                query.Add("minCandidatureStake", minCandidatureStake.ToString());
            if (numberOfFullProducersRequired != null)
                query.Add("numberOfFullProducersRequired", numberOfFullProducersRequired.ToString());
            if (numberOfHistoryProducersRequired != null)
                query.Add("numberOfHistoryProducersRequired", numberOfHistoryProducersRequired.ToString());
            if (numberOfValidatorProducersRequired != null)
                query.Add("numberOfValidatorProducersRequired", numberOfValidatorProducersRequired.ToString());
            if (blockTimeInSeconds != null)
                query.Add("blockTimeInSeconds", blockTimeInSeconds.ToString());
            if (blockSizeInBytes != null)
                query.Add("blockSizeInBytes", blockSizeInBytes.ToString());
            

            var request = HttpHelper.ComposeWebRequestGet(endpoint + RequesterEndpoint + requestEndpoint);
            var result = await HttpHelper.CallWebRequest(request);
            return result;
        }
    }
}