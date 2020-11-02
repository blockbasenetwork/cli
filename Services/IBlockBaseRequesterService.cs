using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace BlockBase.Cli.Services
{
    public interface IBlockBaseRequesterService
    {
        Task<string> CheckRequesterConfig(string endpoint);
        Task<string> CheckCurrentStakeInSidechain(string endpoint);
        Task<string> RequestNewSidechain(string endpoint, decimal stake = 0);
        //Task<string> RequestNewSidechainWithBackup(string endpoint);
        Task<string> SetSecret(string endpoint);
        Task<string> RunSidechainMaintenance(string endpoint);
        Task<string> PauseSidechain(string endpoint);
        Task<string> EndSidechain(string endpoint);
        Task<string> AddStake(string endpoint, double stake);
        Task<string> ClaimStake(string endpoint);
        Task<string> GenerateMasterKey(string endpoint);
        Task<string> ExecuteQuery(string endpoint, string queryScript);
        //Task<string> GetAllTableValues(string endpoint);
        Task<string> GetStructure(string endpoint);
        Task<string> RemoveSidechainDatabasesAndKeys(string endpoint);
        Task<string> GetDecryptedNodeIps(string endpoint);
        Task<string> RemoveAccountFromBlacklist(string endpoint, string account);
        Task<string> CheckSidechainReservedSeats(string endpoint);
        //Task<string> AddReservedSeat(string endpoint);
        Task<string> RemoveReservedSeats(string endpoint, List<string> reservedSeatsToRemove);
        Task<string> ChangeSidechainConfigurations(string endpoint, decimal? maxPaymentPerBlockFullProducer, decimal? minPaymentPerBlockFullProducer,
                                                                      decimal? maxPaymentPerBlockHistoryProducer, decimal? minPaymentPerBlockHistoryProducer,
                                                                      decimal? maxPaymentPerBlockValidatorProducer, decimal? minPaymentPerBlockValidatorProducer,
                                                                      decimal? minCandidatureStake, int? numberOfFullProducersRequired,
                                                                      int? numberOfHistoryProducersRequired, int? numberOfValidatorProducersRequired,
                                                                      int? blockTimeInSeconds, long? blockSizeInBytes);
    }
}