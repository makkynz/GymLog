using Android.Support.V4.App;
using GymLog.Fragments;
using System.Collections.Generic;

namespace GymLog.Adapters
{
    /// <summary>
    ///  Nest Adapter
    /// </summary>
    public class ExerciseDetailPagerAdapter : Android.Support.V4.App.FragmentPagerAdapter
    {

        private int _LogId;
        public ExerciseDetailPagerAdapter(FragmentManager fm, int logId) : base(fm)
        {
            _LogId = logId;


        }

        public override int Count
        {
            get
            {
                return 4;
            }
        }

        public override Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0: return AddLogFragment.Instance(_LogId);
                case 1: return ExerciseDetailPBFragment.Instance(_LogId);
                case 2: return ExerciseDetailHistoryFragment.Instance(_LogId);
                case 3: return ExerciseDetailReportsFragment.Instance(_LogId);
            }

            return null;
        }
    }
   
}