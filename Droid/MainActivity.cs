using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using MvvmCross.Platforms.Android.Views;
using AlaskaFlightApp.Core.ViewModels;
using MvvmCross.ViewModels;
using MvvmCross.Base;
using Android.Views.InputMethods;
using Android.Content;
using AlaskaFlightApp.Core.Contracts.Interactions;

namespace AlaskaFlightApp.Droid
{
    [Activity(Label = "AlaskaFlightApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : MvxActivity, IKeyboard
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            (this.ViewModel as MainViewModel).keyboard = this;


        }

        public void dismissKeyboard()
        {
            InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(FindViewById(Resource.Id.searchText).WindowToken, 0);
        }
    }
}

