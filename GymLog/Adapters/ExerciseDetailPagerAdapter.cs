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

        int _ExerciseId;
        List<Android.Support.V4.App.Fragment> _fragments;


        public ExerciseDetailPagerAdapter(FragmentManager fm, int exerciseId) : base(fm)
        {
            _ExerciseId = exerciseId;

            _fragments = new List<Fragment>();
            _fragments.Add(ExerciseDetailAddLogFragment.Instance(_ExerciseId));
            _fragments.Add(ExerciseDetailPBFragment.Instance(_ExerciseId));
            _fragments.Add(ExerciseDetailHistoryFragment.Instance(_ExerciseId));
            _fragments.Add(ExerciseDetailReportsFragment.Instance(_ExerciseId));
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