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
using GymLog.Shared.Constants;

namespace GymLog.Activities
{
    [Activity( MainLauncher = false,  Theme = "@style/MyTheme", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class ExerciseDetailActivity : AppCompatActivity
    {

        Android.Support.V7.Widget.Toolbar _toolbar;
        SlidingTabScrollView _slidingTabScrollView;
        ViewPager _viewPager;       
        Exercise _exercise;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //get args
            _exercise = ExerciseManager.GetExerciseById(Intent.GetIntExtra(ParamKeys.EXERCISE_ID, 0));

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_exercise_detail_activity);

            _toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(_toolbar);
            this.SupportActionBar.Title = _exercise.Name; //get name of exercise

            //setup sliding tabs
            _slidingTabScrollView = FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs);
            _viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            //_viewPager.Adapter = new SlidingTabsAdapter(new List<string>() { "Log", "PB", "History", "Reports" });
            _viewPager.Adapter = new ExerciseDetailPagerAdapter(base.SupportFragmentManager, _exercise.Id.Value);
            _slidingTabScrollView.ViewPage = _viewPager;

           

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
                    StartActivity(new Intent(this, typeof(Activities.HomeActivity)));
                    Finish(); break;
            }
            return true;
        }


    }
}

