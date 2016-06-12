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
using GymLog.ExtendedControls;
using System.Collections.Generic;

namespace GymLog.Activities
{
    [Activity( MainLauncher = false,  
        Theme = "@style/MyTheme",
        ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize
      ,LaunchMode = Android.Content.PM.LaunchMode.SingleTop
        )]
    public class MainActivity : AppCompatActivity
    {

        Android.Support.V7.Widget.Toolbar _toolbar;
        SlidingTabScrollView _slidingTabScrollView;
        ViewPager _viewPager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //set tool bar
            _toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(_toolbar);
            this.SupportActionBar.Title = "Gym Log Home";

            //setup sliding tabs
            _slidingTabScrollView = FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs);
            _viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            _viewPager.Adapter = new HomePagerAdapter(base.SupportFragmentManager);
           // _viewPager.Adapter = new SlidingTabsAdapter(new List<string>() { "Today's Exercises", "History" });
            _slidingTabScrollView.ViewPage = _viewPager;

           
           
           

        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }



    }
}

