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
    public class AddSetAdapter : BaseAdapter<ExerciseSet>
    {

        Activity _context = null;
        List<ExerciseSet> _sets = new List<ExerciseSet>();

        public event EventHandler<int> RemoveSetClick;

        public AddSetAdapter(Activity context, List<ExerciseSet> sets) : base()
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
            if (convertView != null && convertView is View) return convertView;

            var set = _sets[position];

            var row = (convertView ?? LayoutInflater.FromContext(_context).Inflate(Resource.Layout.row_add_log, parent, false));

            var lblSetNbr = row.FindViewById<TextView>(Resource.Id.lblSetNbr);
            var txtStatOne = row.FindViewById<EditText>(Resource.Id.txtStatOne);
            var lblStatOne = row.FindViewById<TextView>(Resource.Id.lblStatOne);
            var txtStatTwo = row.FindViewById<EditText>(Resource.Id.txtStatTwo);
            var lblStatTwo = row.FindViewById<TextView>(Resource.Id.lblStatTwo);
            var btnMenu = row.FindViewById<ImageButton>(Resource.Id.btnMenu);


            /* add delet button on sub menu */
            btnMenu.Click += (s, e) =>
            {
                var menu = new Android.Widget.PopupMenu(this._context, btnMenu);
                menu.Inflate(Resource.Menu.menu_add_set);
                menu.MenuItemClick += (s1, arg1) => {
                    if (RemoveSetClick != null)
                    {
                        RemoveSetClick(this, position);
                    }
                };

                menu.Show();

            };

            /* set number */
            lblSetNbr.Text = (position + 1).ToString();


            //set metric labels
            var statCount = 0;
            foreach (var input in set.Inputs)
            {
                if (statCount == 0)
                {
                    lblStatOne.Text = input.Label;
                    txtStatOne.Text = input.ValueAsString;
                    // txtStatOne.InputType = Android.Text.InputTypes.DatetimeVariationTime;
                }
                else
                {
                    lblStatTwo.Text = input.Label;
                    txtStatTwo.Text = input.ValueAsString;
                }
                statCount++;
            }


            if (position == _sets.Count - 1)
            {
                txtStatOne.RequestFocus();
            }


            //set event handlers
            txtStatOne.TextChanged += (s, e) =>
            {
                if (!String.IsNullOrWhiteSpace(txtStatOne.Text))
                {
                    set.StatOne = Convert.ToDouble(txtStatOne.Text);
                    set.Save();
                }

            };

            if (statCount > 1)
            {
                txtStatTwo.TextChanged += (s, e) =>
                {
                    if (!String.IsNullOrWhiteSpace(txtStatTwo.Text))
                    {
                        set.StatTwo = Convert.ToDouble(txtStatTwo.Text);
                        set.Save();
                    }
                };
            }
            else
            {
                txtStatTwo.Visibility = ViewStates.Gone;
                lblStatTwo.Visibility = ViewStates.Gone;
            }


            //Finally return the view
            return row;
        }

         


       
    }
}