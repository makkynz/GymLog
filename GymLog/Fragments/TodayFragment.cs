using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Android.Support.V4.App;
using lm = GymLog.Shared.Manager.LogManager;
using GymLog.Adapters;
using Android.Support.Design.Widget;
using Newtonsoft.Json;
using GymLog.Interfaces;

namespace GymLog.Fragments
{
    public class TodayFragment : Fragment, IViewPagerFragment
    {
        public string Title
        {
            get
            {
                return "Today";
            }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.fragment_home_today, container, false);
            
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {

            //bind Exercies list
            var exerciseList = LogListFragment.Instance(lm.LogsToday);


            var trans = ChildFragmentManager.BeginTransaction();
            trans.Add(Resource.Id.frameLayoutExercises, exerciseList).Commit();           


            /*bind Plus button*/
            var fab = view.FindViewById<FloatingActionButton>(Resource.Id.fab);            
            fab.Click += (sender, args) =>
            {
                var intent = new Intent(base.Activity, typeof(Activities.AddExerciseActivity));
                StartActivity(intent);
                base.Activity.Finish();
            };

        }



  
        
    }
}