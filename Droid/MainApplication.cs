
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlaskaFlightApp.Core;
using AlaskaFlightApp.Core.Contracts.Service;
using AlaskaFlightApp.Droid.Services;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace AlaskaFlightApp.Droid
{
    [Application]
    public class MainApplication : MvxAndroidApplication<Setup, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
           
        }
        
    }
}
