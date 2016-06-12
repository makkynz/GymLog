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

namespace GymLog.Fragments
{
    public class LogListFragment : Fragment
    {

        List<ExerciseLog> _logs;
        RecyclerView.LayoutManager _layoutManager;
        LogListAdapter _adapter;
        RecyclerView _recyclerView;
        

        public static LogListFragment  Instance(List<ExerciseLog> logs)
        {
            var loglist = new LogListFragment();

            loglist.Arguments = new Bundle();
            loglist.Arguments.PutString("logs", JsonConvert.SerializeObject(logs));           

            return loglist;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_exercise_detail_log, container, false);
            _logs = JsonConvert.DeserializeObject<List<ExerciseLog>>(Arguments.GetString("logs"));
            _recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerLogs);
           

            _layoutManager = new LinearLayoutManager(this.Context);
            _recyclerView.SetLayoutManager(_layoutManager);

            _adapter = new LogListAdapter(base.Activity, _logs);
            _recyclerView.SetAdapter(_adapter);

            _adapter.RowClick += _adapter_RowClick;

            // Use this to return your custom view for this Fragment
            return view;


        }

        private void _adapter_RowClick(object sender, int position)
        {
            var intent = new Intent(base.Activity, typeof(Activities.ExerciseDetailActivity));
            intent.PutExtra("LogId", _logs[position].Id.Value);
            StartActivity(intent);

        }
    }
}