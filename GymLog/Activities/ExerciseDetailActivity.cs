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
using GymLog.Shared.Manager;
using GymLog.Shared.Models;

namespace GymLog.Activities
{
    [Activity( MainLauncher = false,  Theme = "@style/MyTheme", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class ExerciseDetailActivity : AppCompatActivity
    {

        Android.Support.V7.Widget.Toolbar _toolbar;
        SlidingTabScrollView _slidingTabScrollView;
        ViewPager _viewPager;       
        ExerciseLog _Log;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //get args
            _Log = LogManager.GetLogById(Intent.GetIntExtra("LogId", 0));

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ExerciseDetailActivity);

            _toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(_toolbar);
            this.SupportActionBar.Title = _Log.Exercise.Name; //get name of exercise

            //setup sliding tabs
            _slidingTabScrollView = FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs);
            _viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            _viewPager.Adapter = new SlidingTabsAdapter(new List<string>() { "Log", "PB", "History", "Reports" });
            _slidingTabScrollView.ViewPage = _viewPager;

            //add page viewer
            var viewPage = FindViewById<ViewPager>(Resource.Id.viewPager);
            viewPage.Adapter = new ExerciseDetailPagerAdapter(base.SupportFragmentManager, _Log.Id.Value);
           

        }

        


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_back:
                    Toast.MakeText(this, "Going back", ToastLength.Short).Show();
                    StartActivity(new Intent(this, typeof(Activities.MainActivity)));
                    Finish(); break;
            }
            return true;
        }


    }
}

