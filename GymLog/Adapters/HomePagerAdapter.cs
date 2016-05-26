using Android.Support.V4.App;
using GymLog.Fragments;

namespace GymLog.Adapters
{
    /// <summary>
    ///  Nest Adapter
    /// </summary>
    public class HomePagerAdapter : Android.Support.V4.App.FragmentPagerAdapter
    {

        public HomePagerAdapter(FragmentManager fm) : base(fm) { }

        public override int Count
        {
            get
            {
                return 2;
            }
        }

        public override Fragment GetItem(int position)
        {
            if(position == 0)
            {
                return new TodayFragment();
            }else
            {
                return new HistoryFragment();
            }
           
        }
    }
   
}