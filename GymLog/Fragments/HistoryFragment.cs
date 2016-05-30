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

namespace GymLog.Fragments
{
    public class HistoryFragment : Fragment
    {
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.HistoryFragement, container, false);
            
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            //bind Exercies list (nested fragment)
            var exerciseList = LogListFragment.Instance(lm.LogsHistory);             
            var trans = ChildFragmentManager.BeginTransaction();
            trans.Add(Resource.Id.linearLayoutExercises, exerciseList).Commit();           


        }    
       
    }
}