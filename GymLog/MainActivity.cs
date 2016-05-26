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

namespace GymLog
{
    [Activity(Label = "GymLog", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity
    {
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            //add page viewer
            var viewPage = FindViewById<ViewPager>(Resource.Id.viewPager);
            viewPage.Adapter = new HomePagerAdapter(base.SupportFragmentManager);
           

        }


        
    }
}

