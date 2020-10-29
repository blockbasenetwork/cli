using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace BlockBase.Services
{
    public interface IBlockBaseNetworkService
    {
        Task<string> GetSidechainConfiguration(string endpoint, string sidechainName);
    }
}