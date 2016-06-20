using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymLog.Shared.Models;
using em = GymLog.Shared.Manager.ExerciseManager;
using date = GymLog.Shared.Helpers.DateHelper;

namespace GymLog.Shared.Manager
{
    public class LogManager
    {
        public static List<ExerciseLog> LogsToday
        {
            get
            {
                        
                var logs = DataManager.DB.Query<ExerciseLog>("SELECT * FROM ExerciseLog WHERE DateCreated BETWEEN ? AND ?", date.StartOfDayTicks, date.EndOfDayTicks);
                return logs;
            }
        }

        public static List<ExerciseLog> LogsHistory
        {
            get
            {
                var logs = DataManager.DB.Query<ExerciseLog>("SELECT * FROM ExerciseLog WHERE DateCreated < ? ", date.StartOfDayTicks);               
                return logs;
            }
        }

        


        public static ExerciseLog GetLogById(int id)
        {
            var result = (from e in DataManager.DB.Table<ExerciseLog>()
                          where e.Id == id
                          select e).SingleOrDefault();

            return result;
        }

        public static bool AddExerciseForToday(Exercise exercise)
        {
            if(!LogsToday.Any(l=>l.ExerciseId == exercise.Id))
            {
                var newLog = new ExerciseLog
                {
                    DateCreated = DateTime.Now,
                    Exercise = exercise
                };
                newLog.Save();
                return true;
            }else
            {
                return false;
            }
        }

       

    }
}
