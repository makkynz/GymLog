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

namespace GymLog.Fragments
{
    public class TodayFragment : Fragment
    {
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.TodayFragement, container, false);
            
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            var lv = view.FindViewById<ListView>(Resource.Id.listViewExercises);
            lv.Adapter = new ExerciseListViewAdapter(base.Activity, lm.LogsToday);

            var fab = view.FindViewById<FloatingActionButton>(Resource.Id.fab);

            //Floating action button
            fab.Click += (sender, args) =>
            {
                var intent = new Intent(base.Activity, typeof(AddExercise));
                StartActivity(intent);
            };

        }

  
        
    }
}