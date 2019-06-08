using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AlaskaFlightApp.Core.Contracts.Service;
using AlaskaFlightApp.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace AlaskaFlightApp.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IFlightDataService _flightDataService;
        private readonly IConnectionService _connectionService;
        private readonly IDialogService _dialogService;
        private readonly IMvxNavigationService _mvxNavigationService;

        private ObservableCollection<FlightModel> _flightsCollection;
        public ObservableCollection<FlightModel> FlightsCollection
        {
            get { return _flightsCollection; }
            set { _flightsCollection = value; RaisePropertyChanged(() => FlightsCollection); }
        }

        private String _airportCode;
        public String AirportCode
        {
            get { return _airportCode; }
            set { _airportCode = value; RaisePropertyChanged(() => AirportCode); }
        }

        private bool _layoutVisibility = true;
        public bool LayoutVisibility
        {
            get { return _layoutVisibility; }
            set { _layoutVisibility = value; RaisePropertyChanged(() => LayoutVisibility); }
        }

        public MainViewModel(IFlightDataService flightDataService, IConnectionService connectionService, IDialogService dialogService, IMvxNavigationService mvxNavigationService)
        {
            _flightDataService = flightDataService;
            _connectionService = connectionService;
            _dialogService = dialogService;
            _mvxNavigationService = mvxNavigationService;
        }

        public IMvxCommand SearchCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    if (_connectionService.CheckOnline())
                    {
                        LayoutVisibility = false;
                        FlightsCollection = new ObservableCollection<FlightModel>(await _flightDataService.GetFlightDetails(AirportCode));
                        LayoutVisibility = true;

                        if (FlightsCollection.Count == 0)
                        {
                            await _dialogService.ShowAlertAsync("No flights for your search", "Try later", "OK");
                        }
                    }
                    else
                    {
                        await _dialogService.ShowAlertAsync("No internet available", "Connect to internet and try again", "OK");
                        //maybe we can navigate to a start page here, for you to add to this code base!
                    }

                });
            }
        }

        public IMvxCommand<FlightModel> ItemClickCommand
        {
            get
            {
                return new MvxCommand<FlightModel>( async(flight) =>
                {
                    await _mvxNavigationService.Navigate<DetailsViewModel, FlightModel>(flight);

                });
            }
        }
    }
}

