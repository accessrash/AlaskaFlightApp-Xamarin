using System;
using AlaskaFlightApp.Core.Models;
using MvvmCross.ViewModels;

namespace AlaskaFlightApp.Core.ViewModels
{
    public class DetailsViewModel : MvxViewModel<FlightModel>
    {

        private String _flightNumber;
        public String FlightNumber
        {
            get { return _flightNumber; }
            set { _flightNumber = value; RaisePropertyChanged(() => FlightNumber); }
        }

        private String _originAirport;
        public String OriginAirport
        {
            get { return _originAirport; }
            set { _originAirport = value; RaisePropertyChanged(() => OriginAirport); }
        }

        private String _destinationAirport;
        public String DestinationAirport
        {
            get { return _destinationAirport; }
            set { _destinationAirport = value; RaisePropertyChanged(() => DestinationAirport); }
        }

        private String _estimatedArrival;
        public String EstimatedArrival
        {
            get { return _estimatedArrival; }
            set { _estimatedArrival = value; RaisePropertyChanged(() => EstimatedArrival); }
        }

        private String _status;
        public String Status
        {
            get { return _status; }
            set { _status = value; RaisePropertyChanged(() => Status); }
        }

        private String _fleetType;
        public String FleetType
        {
            get { return _fleetType; }
            set { _fleetType = value; RaisePropertyChanged(() => FleetType); }
        }

        public override void Prepare(FlightModel parameter)
        {
            FlightNumber = parameter.FltId;
            OriginAirport = parameter.Orig;
            DestinationAirport = parameter.Dest;
            EstimatedArrival = parameter.EstArrTime.ToString();
            Status = parameter.Status;
            FleetType = parameter.FleetType;
        }

    }
}
