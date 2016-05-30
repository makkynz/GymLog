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
using GymLog.Adapters;
using Newtonsoft.Json;
using GymLog.Shared.Manager;
using Android.Support.V7.App;

namespace GymLog.Activities
{
    [Activity(Label = "AddExercise", Theme = "@style/MyTheme" , ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class AddExerciseActivity : AppCompatActivity
    {
        Android.Support.V7.Widget.Toolbar _toolbar;
        List<Exercise> _exercises;
        RecyclerView.LayoutManager _layoutManager;
        ExerciseListAdapter _adapter;
        RecyclerView _recyclerView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here            
            SetContentView(Resource.Layout.ExerciseList);

            //set toolbar
            _toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);           
            SetSupportActionBar(_toolbar);
            this.SupportActionBar.Title = "Add Exercise";


            //bind list of exercises
            _exercises = ExerciseManager.Exercises;
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerExercises);
            _layoutManager = new LinearLayoutManager(this);
            _recyclerView.SetLayoutManager(_layoutManager);
            _adapter = new ExerciseListAdapter(this, _exercises);
            _adapter.ItemAddClick += exercise_AddClick;
            _recyclerView.SetAdapter(_adapter);

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_back:
                    Toast.MakeText(this, "Going back", ToastLength.Short).Show();
                    StartActivity(new Intent(this, typeof(Activities.MainActivity)));
                    Finish(); break;
            }
            return true;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }


        private void exercise_AddClick(object sender, int position)
        {
            //save new log
            var newLog = new ExerciseLog
            {
                DateCreated = DateTime.Now,
                Exercise = _exercises[position],
                SetCount = 0

            };
            newLog.Save();
            Toast.MakeText(this, _exercises[position].Name + " has been added", ToastLength.Short).Show();            
            StartActivity(new Intent(this, typeof(Activities.MainActivity)));
            Finish(); 
        }
    }
}