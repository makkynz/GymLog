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
    public class ExerciseSet
    {
        #region Constructors

        /// <summary>
        /// should only be called with getting data from db
        /// </summary>
        public ExerciseSet() { }

        public ExerciseSet(int ExerciseLogId)
        {
            this.ExerciseLogId = ExerciseLogId;
        }

        #endregion

        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        public int ExerciseLogId { get; set; }
        public double? StatOne { get; set; }
        public double? StatTwo { get; set; }

        [Ignore]
        [JsonIgnore]
        public ExerciseLog ExerciseLog {
            get
            {
                if(_ExerciseLog == null && ExerciseLogId > 0)
                {
                    _ExerciseLog = LogManager.GetLogById(ExerciseLogId);
                }
                return _ExerciseLog;
            }
            set {
                ExerciseLogId = value.Id.Value;
                _ExerciseLog = value;
            }
        }       
        

        private ExerciseLog _ExerciseLog;
        
        public void Save()
        {
            if (this.StatOne.HasValue || this.StatTwo.HasValue)
            {
                var db = DataManager.DB;
                db.InsertOrReplace(this);
                db.Commit();
            }
        }

    }
}
