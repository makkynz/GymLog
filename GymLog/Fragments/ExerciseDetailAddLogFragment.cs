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
using Android.Support.Design.Widget;
using GymLog.Interfaces;
using GymLog.Shared.Constants;

namespace GymLog.Fragments
{
    public class ExerciseDetailAddLogFragment : Fragment, IViewPagerFragment
    {

        Exercise _exercise;
        AddSetAdapter _addLogListAdapter;

        public string Title
        {
            get
            {
                return "Today's Log";
            }
        }

        public static ExerciseDetailAddLogFragment Instance(int ExerciseId)
        {
            var frag = new ExerciseDetailAddLogFragment();

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
            var view = inflater.Inflate(Resource.Layout.fragment_add_log, container, false);
            _exercise = ExerciseManager.GetExerciseById(Arguments.GetInt(ParamKeys.EXERCISE_ID));
            var log = _exercise.TodaysLog;

            if (log != null)
            {

                /*bind log list*/
                var listViewLogs = view.FindViewById<ListView>(Resource.Id.listViewLogs);
                log.AddNewSetIfEmpty();
                _addLogListAdapter = new AddSetAdapter(base.Activity, log.Sets);
                listViewLogs.Adapter = _addLogListAdapter;

                /*remove set button click */
                _addLogListAdapter.RemoveSetClick += (s, position) =>
                {
                    if (log.Sets.Count > position)
                    {
                        log.DeleteSet(position);
                        _addLogListAdapter.NotifyDataSetChanged();
                    }

                };
            }

            /*bind Plus button*/
            var fab = view.FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += (sender, args) =>
            {
                if(log == null)
                {
                    LogManager.AddExerciseForToday(_exercise);
                    log = _exercise.TodaysLog;
                }
                log.AddNewSet();
                _addLogListAdapter.NotifyDataSetChanged();
            };

            return view;


        }        
    }
}