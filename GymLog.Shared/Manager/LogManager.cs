using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymLog.Shared.Models;
using em = GymLog.Shared.Manager.ExerciseManager;

namespace GymLog.Shared.Manager
{
    public class LogManager
    {
        public static List<ExerciseLog> LogsToday
        {
            get
            {
                var startOfDayTicks = DateTime.Now.Date.Ticks;
                var endOfDayTicks = DateTime.Now.Date.AddDays(1).AddTicks(-1).Ticks;

                var logs = DataManager.DB.Query<ExerciseLog>("SELECT * FROM ExerciseLog WHERE DateCreated BETWEEN ? AND ?", startOfDayTicks, endOfDayTicks);

             
                return logs;
            }
        }

        public static List<ExerciseLog> LogsHistory
        {
            get
            {
                var startOfDayTicks = DateTime.Now.Date.Ticks;                

                var logs = DataManager.DB.Query<ExerciseLog>("SELECT * FROM ExerciseLog WHERE DateCreated < ? ", startOfDayTicks);

               
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


    }
}
