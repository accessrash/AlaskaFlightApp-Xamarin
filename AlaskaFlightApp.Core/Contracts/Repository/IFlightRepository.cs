using System.Collections.Generic;
using System.Threading.Tasks;
using AlaskaFlightApp.Core.Models;

namespace AlaskaFlightApp.Core.Contracts.Repository
{
    public interface IFlightRepository
    {
        Task<List<FlightModel>> GetFlightDetails(string airportCode);
    }
}
