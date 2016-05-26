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

namespace GymLog.Adapters
{
    public class ExerciseListViewAdapter : BaseAdapter<ExerciseLog>
    {
        private List<ExerciseLog> _logs;
        private Context _context;

        public ExerciseListViewAdapter(Context context, List<ExerciseLog> logs)
        {
            _context = context;
            _logs = logs;

        }

        public override ExerciseLog this[int position]
        {
            get
            {
                return _logs[position];
            }
        }

        public override int Count
        {
            get
            {
                return _logs.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(_context).Inflate(Resource.Layout.listview_exercise_row, null, false);
            }

            var tvName = convertView.FindViewById<TextView>(Resource.Id.tvName);
            var tvSets = convertView.FindViewById<TextView>(Resource.Id.tvSets);

            tvName.Text = _logs[position].Exercise.Name;
            tvSets.Text = _logs[position].SetCount.ToString();

            return convertView;
        }
    }
}