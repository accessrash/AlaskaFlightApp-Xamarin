using System;
using AlaskaFlightApp.Core.Contracts.Service;
using Plugin.Connectivity;

namespace AlaskaFlightApp.Core.Services.General
{
    public class ConnectionService : IConnectionService
    {
        public bool CheckOnline()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}
