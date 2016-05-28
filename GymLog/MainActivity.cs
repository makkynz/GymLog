using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using GymLog.Adapters;
using Android.Support.V7.App;

namespace GymLog
{
    [Activity(Label = "GymLog", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {

        private Android.Support.V7.Widget.Toolbar _toolbar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(_toolbar);
            this.SupportActionBar.Title = "Yay for the Toolbar!";

            //add page viewer
            var viewPage = FindViewById<ViewPager>(Resource.Id.viewPager);
            viewPage.Adapter = new HomePagerAdapter(base.SupportFragmentManager);
           

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }



    }
}

