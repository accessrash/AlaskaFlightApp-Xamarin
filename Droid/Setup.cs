using System;
using AlaskaFlightApp.Core;
using AlaskaFlightApp.Core.Contracts.Service;
using AlaskaFlightApp.Droid.Services;
using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.ViewModels;

namespace AlaskaFlightApp.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {

        public Setup() : base()
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<IDialogService>(() => new DialogService());
        }
    }
}
