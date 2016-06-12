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

        public void AddNewSet()
        {
            this.Sets.Add(new ExerciseSet(this.Id.Value));
        }

    }
}
