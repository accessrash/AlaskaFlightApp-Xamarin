using System.Collections.Generic;
using System.Threading.Tasks;
using AlaskaFlightApp.Core.Contracts.Repository;
using AlaskaFlightApp.Core.Contracts.Service;
using AlaskaFlightApp.Core.Models;
using System.Linq;
using System;

namespace AlaskaFlightApp.Core.Services.Data
{
    public class FlightDataService : IFlightDataService
    {
        private readonly IFlightRepository _flightRepository;
        public FlightDataService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<List<FlightModel>> GetFlightDetails(string airportCode)
        {
            
            var result =  await _flightRepository.GetFlightDetails(airportCode);
            var filteredList = result.Where(x => x.Dest.ToLower() == airportCode.ToLower()).Where(y => y.EstArrTime.ToUniversalTime() >= DateTime.UtcNow).OrderBy(z => z.EstArrTime);
            return filteredList.ToList();
            
        }
    }
}
