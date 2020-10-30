using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace BlockBase.Cli.Services
{
    public interface IBlockBaseNetworkService
    {
        Task<string> GetSidechainConfiguration(string endpoint, string sidechainName);
        Task<string> GetAccountStakeRecords(string endpoint, string accountName);
        Task<string> GetProducerCandidatureState(string endpoint, string accountName, string sidechainName);
        Task<string> GetSidechainState(string endpoint, string sidechainName);
        Task<string> GetCurrentUnclaimedRewards(string endpoint, string accountName);
        Task<string> GetPeerConnectionsState(string endpoint);
    }
}