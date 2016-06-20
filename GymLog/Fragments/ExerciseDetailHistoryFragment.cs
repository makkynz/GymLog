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
using GymLog.Shared.Models;
using Android.Support.V7.Widget;
using Newtonsoft.Json;
using GymLog.Shared.Manager;
using GymLog.Interfaces;
using GymLog.Shared.Constants;

namespace GymLog.Fragments
{
    public class ExerciseDetailHistoryFragment : Fragment, IViewPagerFragment
    {

        Exercise _exercise;
        ExerciseHistoryListAdapter _addLogListAdapter;

        public string Title
        {
            get
            {
                return "Exercise History";
            }
        }

        public static ExerciseDetailHistoryFragment Instance(int ExerciseId)
        {
            var frag = new ExerciseDetailHistoryFragment();

            frag.Arguments = new Bundle();
            frag.Arguments.PutInt("ExerciseId", ExerciseId);

            return frag;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_set_history, container, false);
            _exercise = ExerciseManager.GetExerciseById(Arguments.GetInt(ParamKeys.EXERCISE_ID));


            var log = _exercise.Logs;

            if (log != null)
            {

                /*bind log list*/
                var listViewLogs = view.FindViewById<ListView>(Resource.Id.listViewLogs);
               
                _addLogListAdapter = new ExerciseHistoryListAdapter(base.Activity, log);
                listViewLogs.Adapter = _addLogListAdapter;
              
            }

            // Use this to return your custom view for this Fragment
            return view;


        }        
    }
}