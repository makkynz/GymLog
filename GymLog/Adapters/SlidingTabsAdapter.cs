using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;

namespace GymLog.Adapters
{
    public class SlidingTabsAdapter : PagerAdapter
    {
        List<string> items = new List<string>() { "Today", "History" };

        
        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object obj)
        {
            return view == obj;
        }        

        public string GetHeaderTitle(int position)
        {
            return items[position];
        }
        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object obj)
        {
            container.RemoveView((View)obj);
        }
    }
}