using System;
using Android.Support.V4.App;
using GymLog.Fragments;
using GymLog.Interfaces;
using System.Collections.Generic;

namespace GymLog.Adapters
{
    /// <summary>
    ///  Nest Adapter
    /// </summary>
    public class HomePagerAdapter : FragmentPagerAdapter, IViewPagerAdapter
    {
        private List<Android.Support.V4.App.Fragment> _fragments;

        public HomePagerAdapter(FragmentManager fm) : base(fm)
        {
            _fragments = new List<Fragment>() ;
            _fragments.Add(new TodayFragment());
            _fragments.Add(new HistoryFragment());
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