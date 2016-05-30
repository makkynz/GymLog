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
namespace GymLog.Adapters
{
    public class LogAdapter : RecyclerView.Adapter
    {
        private List<ExerciseLog> _logs;
        private Context _context;
        public event EventHandler<int> ItemClick;

        public LogAdapter(Context context, List<ExerciseLog> logs)
        {
            _context = context;
            _logs = logs;

        }

       
        public override int ItemCount
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

      

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var lh = holder as LogViewHolder;
            

            lh.TextViewName.Text = _logs[position].Exercise.Name;
            lh.TextViewSets.Text = $"{_logs[position].SetCount.ToString()} {StringHelper.Pluralise("set","sets", _logs[position].SetCount)}";
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
           
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.LogRow, parent, false);
            var vh = new LogViewHolder(itemView, OnClick);

            return vh;
        }

        // Raise an event when the item-click takes place:
        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }

        public class LogViewHolder : RecyclerView.ViewHolder
        {
           // public ImageView Image { get; private set; }
            public TextView TextViewName { get; private set; }
            public TextView TextViewSets { get; private set; }

            // Get references to the views defined in the CardView layout.
            public LogViewHolder(View itemView, Action<int> listener)
                : base(itemView)
            {
                TextViewName = itemView.FindViewById<TextView>(Resource.Id.LogRowName);
                TextViewSets = itemView.FindViewById<TextView>(Resource.Id.LogRowSets);
            }
        }
    }
}