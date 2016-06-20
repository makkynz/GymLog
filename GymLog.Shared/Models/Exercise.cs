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
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Metric { get; set; }
        public string Description { get; set; }
        public string KeyStat { get { return "1 Rep Max: 70Kg"; } }

             
      

        

        public ExerciseLog TodaysLog
        {
            get
            {
                return LogManager.LogsToday.Where(l => l.ExerciseId == this.Id).SingleOrDefault();
            }
        }


        public List<ExerciseLog> Logs
        {
            get
            {
                var logs = DataManager.DB.Query<ExerciseLog>("SELECT * FROM ExerciseLog WHERE ExerciseId = ? ORDER BY DateCreated DESC", this.Id.Value);
                return logs;
            }
        }
        
    }
}
