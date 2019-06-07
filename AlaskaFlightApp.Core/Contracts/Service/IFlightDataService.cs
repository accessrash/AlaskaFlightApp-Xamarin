using System.Collections.Generic;
using System.Threading.Tasks;
using AlaskaFlightApp.Core.Models;

namespace AlaskaFlightApp.Core.Contracts.Service
{
    public interface IFlightDataService
    {
        Task<List<FlightModel>> GetFlightDetails(string airportCode);
    }
}
