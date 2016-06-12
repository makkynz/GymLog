using Android.Support.V4.App;
using GymLog.Fragments;
using GymLog.Interfaces;
using System.Collections.Generic;
using System;

namespace GymLog.Adapters
{
    /// <summary>
    ///  Nest Adapter
    /// </summary>
    public class ExerciseDetailPagerAdapter : FragmentPagerAdapter, IViewPagerAdapter
    {

        int _LogId;
        List<Android.Support.V4.App.Fragment> _fragments;


        public ExerciseDetailPagerAdapter(FragmentManager fm, int logId) : base(fm)
        {
            _LogId = logId;

            _fragments = new List<Fragment>();
            _fragments.Add(AddLogFragment.Instance(_LogId));
            _fragments.Add(ExerciseDetailPBFragment.Instance(_LogId));
            _fragments.Add(ExerciseDetailHistoryFragment.Instance(_LogId));
            _fragments.Add(ExerciseDetailReportsFragment.Instance(_LogId));
        }

        public override int Count
        {
            get
            {
                return _fragments.Count;
            }
        }
        

        public override Fragment GetItem(int position)
        {
            return _fragments[position];

        }

        public string GetTitle(int position)
        {
            return ((IViewPagerFragment)_fragments[position]).Title;
        }
    }
   
}