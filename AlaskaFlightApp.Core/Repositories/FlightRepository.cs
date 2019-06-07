using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AlaskaFlightApp.Core.Contracts.Repository;
using AlaskaFlightApp.Core.Models;

namespace AlaskaFlightApp.Core.Repositories
{
    public class FlightRepository : BaseRepository, IFlightRepository
    {
        public FlightRepository()
        {
        }

        protected override HttpMethod HttpVerb => HttpMethod.Get;

        public async Task<List<FlightModel>> GetFlightDetails(string airportCode)
        {
            return await this.GetAsync<List<FlightModel>>(this.getBaseURL() + String.Format(GetRequestPath(), airportCode));
        }

        protected override string GetRequestPath()
        {
            return "1/dayoftravel/airports/{0}/flights/flightInfo?minutesBefore=0&minutesAfter=60";
        }
    }
}
