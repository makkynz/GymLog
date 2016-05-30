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

namespace GymLog.Activities
{
    [Activity( MainLauncher = false,  Theme = "@style/MyTheme", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
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

            _toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(_toolbar);
            this.SupportActionBar.Title = "Gym Log Home";

            //setup sliding tabs
            _slidingTabScrollView = FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs);
            _viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            _viewPager.Adapter = new SlidingTabsAdapter();
            _slidingTabScrollView.ViewPage = _viewPager;

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

