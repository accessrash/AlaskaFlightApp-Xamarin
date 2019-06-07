using System;
using AlaskaFlightApp.Core.Contracts.Repository;
using AlaskaFlightApp.Core.Contracts.Service;
using AlaskaFlightApp.Core.Repositories;
using AlaskaFlightApp.Core.Services.Data;
using AlaskaFlightApp.Core.ViewModels;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace AlaskaFlightApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
            .EndingWith("Service")
            .AsInterfaces()
            .RegisterAsLazySingleton();

            CreatableTypes()
            .EndingWith("Repository")
            .AsInterfaces()
            .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}
