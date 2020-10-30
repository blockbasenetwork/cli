using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace BlockBase.Cli.Services
{
    public interface IBlockBaseProviderService
    {
        Task<string> CheckProducerConfig(string endpoint);
        Task<string> RequestToProduceSidechain(string endpoint, string sidechainName, int providerType, decimal stake = 0);
        Task<string> RemoveCandidature(string endpoint, string sidechainName);
        Task<string> RequestToLeaveSidechainProduction(string endpoint, string sidechainName, bool cleanLocalSidechainData = false);
        Task<string> AddStake(string endpoint, string sidechainName, double stake);
        Task<string> ClaimStake(string endpoint, string sidechainName);
        Task<string> ClaimAllRewards(string endpoint);
        Task<string> GetProducingSidechains(string endpoint);
        Task<string> GetPastSidechains(string endpoint);
        Task<string> DeleteSidechainFromDatabase(string endpoint, string sidechainName, bool force = false);
        Task<string> GetBlock(string endpoint, string sidechainName, int blockNumber);
        Task<string> GetTransaction(string endpoint, string sidechainName, int transactionNumber);
        Task<string> GetTransactionsInMempool(string endpoint, string sidechainName);
        Task<string> GetSidechainNodeSoftwareVersion(string endpoint, string sidechainName);
        Task<string> GetDecryptedNodeIps(string endpoint, string sidechainName);
    }
}