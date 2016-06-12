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

namespace GymLog.Fragments
{
    public class ExerciseDetailAddLogFragment : Fragment, IViewPagerFragment
    {

        ExerciseLog _log;
        AddLogListAdapter _addLogListAdapter;

        public string Title
        {
            get
            {
                return "Today's Log";
            }
        }

        public static ExerciseDetailAddLogFragment Instance(int LogId)
        {
            var frag = new ExerciseDetailAddLogFragment();

            frag.Arguments = new Bundle();
            frag.Arguments.PutInt("LogId", LogId);           

            return frag;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_add_log, container, false);
            _log = LogManager.GetLogById(Arguments.GetInt("LogId"));


            /*bind log list*/
            var listViewLogs = view.FindViewById<ListView>(Resource.Id.listViewLogs);
            if (_log.Sets.Count == 0) _log.AddNewSet();
           _addLogListAdapter = new AddLogListAdapter(base.Activity, _log.Sets);          
            listViewLogs.Adapter = _addLogListAdapter;

            
            /*bind Plus button*/
            var fab = view.FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += (sender, args) =>
            {
                _log.AddNewSet();
                _addLogListAdapter.NotifyDataSetChanged();
            };

            return view;


        }        
    }
}