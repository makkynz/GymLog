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
using GymLog.Shared.Models;
using Android.Support.V7.Widget;
using GymLog.Shared.Helpers;
using Android.Support.Design.Widget;
using date = GymLog.Shared.Helpers.DateHelper;

namespace GymLog.Adapters
{
    public class ExerciseHistoryListAdapter : BaseAdapter<ExerciseLog>
    {

        Activity _context = null;
        List<ExerciseLog> _exerciseLogs;

        public event EventHandler<int> RemoveSetClick;

        public ExerciseHistoryListAdapter(Activity context, List<ExerciseLog> exerciseLogs) : base()
        {
            _context = context;
            _exerciseLogs = exerciseLogs;
        }

        public override ExerciseLog this[int position]
        {
            get
            {
                return _exerciseLogs[position];
            }
        }

        public override int Count
        {
            get
            {
                return _exerciseLogs.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return _exerciseLogs[position].Id.HasValue ? _exerciseLogs[position].Id.Value : 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView != null && convertView is View) return convertView;

            var log = _exerciseLogs[position];
            var row = (convertView ?? LayoutInflater.FromContext(_context).Inflate(Resource.Layout.row_set_history, parent, false));

            var lblDate = row.FindViewById<TextView>(Resource.Id.lblDate);
            var lblDayOfWeek = row.FindViewById<TextView>(Resource.Id.lblDayOfWeek);
            var lblSets = row.FindViewById<TextView>(Resource.Id.lblSets);

            lblDayOfWeek.Text = log.DateCreated.DayofWeek2();
            lblDate.Text = log.DateCreated.GymLogFormattedDate();
            lblSets.Text = log.FormatSetsForDisplay;


            //Finally return the view
            return row;
        }





    }
}