using System;
using System.Threading.Tasks;

namespace AlaskaFlightApp.Core.Contracts.Service
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title, string buttonText);
    }
}
