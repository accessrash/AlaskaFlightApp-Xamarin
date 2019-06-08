
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlaskaFlightApp.Core.ViewModels;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;

namespace AlaskaFlightApp.Droid
{
    [Activity(Label = "DetailsActivity")]
    public class DetailsActivity : MvxActivity<DetailsViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DetailsView);

            // Create your application here
        }
    }
}
