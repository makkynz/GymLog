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

namespace GymLog.Adapters
{
    public class AddLogListAdapter : BaseAdapter<ExerciseSet>
    {

        Activity _context = null;
        List<ExerciseSet> _sets = new List<ExerciseSet>();

        public event EventHandler<int> RemoveSetClick;

        public AddLogListAdapter(Activity context, List<ExerciseSet> sets) : base()
        {
            _context = context;
            _sets = sets;
        }

        public override ExerciseSet this[int position]
        {
            get
            {
                return _sets[position];
            }
        }

        public override int Count
        {
            get
            {
                return _sets.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return _sets[position].Id.HasValue ? _sets[position].Id.Value : 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var set = _sets[position];

            var row = (convertView ?? LayoutInflater.FromContext(_context).Inflate( Resource.Layout.row_add_log, parent,  false));

            var lblSetNbr = row.FindViewById<TextView>(Resource.Id.lblSetNbr);
            var txtStatOne = row.FindViewById<EditText>(Resource.Id.txtStatOne);
            var lblStatOne = row.FindViewById<TextView>(Resource.Id.lblStatOne);
            var txtStatTwo = row.FindViewById<EditText>(Resource.Id.txtStatTwo);
            var lblStatTwo = row.FindViewById<TextView>(Resource.Id.lblStatTwo);
            var btnRemove = row.FindViewById<FloatingActionButton>(Resource.Id.btnRemove);


            btnRemove.Click += (s, e) =>
            {
                if (RemoveSetClick != null){
                    RemoveSetClick(this, position);
                }
            };

            lblSetNbr.Text = (position + 1).ToString();


            /*build input controls */
                

            //set metric hints
            var statCount = 0;
            foreach(var metric in set.ExerciseLog.Exercise.MetricDisplayNames)
            {
                if(statCount == 0)
                {
                    lblStatOne.Text = metric;
                }
                else
                {
                    lblStatTwo.Text = metric;
                }
                statCount++;
            }

           
            if(position == _sets.Count - 1)
            {
                txtStatOne.RequestFocus();
            }
           
            //set text boc value
            txtStatOne.Text = set.StatOne.HasValue ? set.StatOne.Value.ToString() : "";
            txtStatTwo.Text = set.StatTwo.HasValue?  set.StatTwo.Value.ToString() : "";

            //set event handlers
            txtStatOne.TextChanged += (s, e) =>
            {
                if (!String.IsNullOrWhiteSpace(txtStatOne.Text))
                {
                    set.StatOne = Convert.ToDouble(txtStatOne.Text);
                    set.Save();
                }
               
            };        
            
            txtStatTwo.TextChanged += (s, e) =>
            {
                if (!String.IsNullOrWhiteSpace(txtStatTwo.Text))
                {
                    set.StatTwo = Convert.ToDouble(txtStatTwo.Text);
                    set.Save();
                }
            };


            //Finally return the view
            return row;
        }

         


       
    }
}