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
                ExerciseId = value.Id;
                _Exercise = value;
            }
        }
        public DateTime DateCreated { get; set; }
        public int SetCount { get; set; }

        private Exercise _Exercise;
        
        public void Save()
        {
            var db = DataManager.DB;
            db.InsertOrReplace(this);
            db.Commit();
        }

    }
}
