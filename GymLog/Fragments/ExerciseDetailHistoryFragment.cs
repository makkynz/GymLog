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

namespace GymLog.Fragments
{
    public class ExerciseDetailHistoryFragment : Fragment, IViewPagerFragment
    {

        ExerciseLog _log;

        public string Title
        {
            get
            {
                return "Exercise History";
            }
        }

        public static ExerciseDetailHistoryFragment Instance(int LogId)
        {
            var frag = new ExerciseDetailHistoryFragment();

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
            var view = inflater.Inflate(Resource.Layout.fragment_exercise_detail_history, container, false);
            _log = LogManager.GetLogById(Arguments.GetInt("LogId"));
           
            // Use this to return your custom view for this Fragment
            return view;


        }        
    }
}