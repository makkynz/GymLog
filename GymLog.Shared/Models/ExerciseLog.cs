using GymLog.Shared.Manager;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog.Shared.Models
{
    public class ExerciseLog
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        public int ExerciseId { get; set; }

        [Ignore]
        [JsonIgnore]
        public Exercise Exercise {
            get
            {
                if(_Exercise == null && ExerciseId > 0)
                {
                    _Exercise = ExerciseManager.GetExerciseById(ExerciseId);
                }
                return _Exercise;
            }
            set {
                ExerciseId = value.Id.Value;
                _Exercise = value;
            }
        }
        public DateTime DateCreated { get; set; }


        [Ignore]
        [JsonIgnore]
        public List<ExerciseSet> Sets
        {
            get
            {
                if(_Sets == null)
                {
                    _Sets = (from e in DataManager.DB.Table<ExerciseSet>()
                                  where e.ExerciseLogId == this.Id
                                  select e).ToList();

                   
                }

                return _Sets;
            }
        }

        /// <summary>
        /// I format the set for display in a list in the UI
        /// </summary>
        public string FormatSetsForDisplay
        {
            get
            {
                var str = new StringBuilder();

                foreach (var set in Sets)
                {
                    if (str.Length != 0) str.Append("\n");

                    var setStat = new StringBuilder();
                    foreach (var input in set.Inputs)
                    {
                        if (setStat.Length != 0) setStat.Append(" | ");
                        setStat.Append(input.DisplayString);
                    }

                    str.Append(setStat.ToString());


                }

                return str.ToString();
            }
        }

        [Ignore]
        [JsonIgnore]
        public int SetCount
        {
            get
            { 
                return this.Sets.Count;
            }
        }

        List<ExerciseSet> _Sets;      
        Exercise _Exercise;
        
        public void Save()
        {
            var db = DataManager.DB;
            db.InsertOrReplace(this);
            db.Commit();
            
        }

        public void DeleteSet(int index)
        {
            if(this.Sets.Count > index)
            {
                this.Sets[index].Delete();
                this.Sets.RemoveAt(index);
            }
        }

        public void AddNewSetIfEmpty()
        {
            if (this.Sets.Count == 0) AddNewSet();
        }

        public void AddNewSet()
        {
            var newSet = new ExerciseSet(this.Id.Value);

            if (LastSet!=null)
            {
                newSet.StatOne = LastSet.StatOne;
                newSet.StatTwo = LastSet.StatTwo;
                newSet.Save();
            }
            
            this.Sets.Add(newSet);
        }

        public ExerciseSet LastSet
        {
            get
            {
                return Sets.Count > 0 ? Sets[Sets.Count - 1] : null;
            }
        }

    }
}
