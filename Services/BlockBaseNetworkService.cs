using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using BlockBase.Cli.Helpers;

namespace BlockBase.Services
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
            var result = await HttpHelper.CallWebRequestNoSSLVerification(request);
            return result;
        }
    }
}