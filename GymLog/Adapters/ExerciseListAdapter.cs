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
using Android.Support.Design.Widget;

namespace GymLog.Adapters
{
    public class ExerciseListAdapter : RecyclerView.Adapter
    {
        private List<Exercise> _exercises;
        private Context _context;
        public event EventHandler<int> ItemAddClick;

        public ExerciseListAdapter(Context context, List<Exercise> exercises)
        {
            _context = context;
            _exercises = exercises;

        }

       
        public override int ItemCount
        {
            get
            {
                return _exercises.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

      

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var lh = holder as LogViewHolder;
            

            lh.TextViewName.Text = _exercises[position].Name;
            lh.TextViewKeyStat.Text = _exercises[position].KeyStat;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
           
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ExerciseRow, parent, false);
            var vh = new LogViewHolder(itemView, OnAddClick);

            return vh;
        }

        // Raise an event when the item-click takes place:
        void OnAddClick(int position)
        {
            if (ItemAddClick != null)
                ItemAddClick(this, position);
        }

        public class LogViewHolder : RecyclerView.ViewHolder
        {
           
            public TextView TextViewName { get; private set; }
            public TextView TextViewKeyStat { get; private set; }
            public ImageButton btnAdd { get; private set; }

            // Get references to the views defined in the CardView layout.
            public LogViewHolder(View itemView, Action<int> addClickListener)
                : base(itemView)
            {
                TextViewName = itemView.FindViewById<TextView>(Resource.Id.exerciseName);
                TextViewKeyStat = itemView.FindViewById<TextView>(Resource.Id.keyStat);
                btnAdd = ItemView.FindViewById<FloatingActionButton>(Resource.Id.btnAdd);

                btnAdd.Click += (s, e) => addClickListener(base.Position);
            }
        }
    }
}