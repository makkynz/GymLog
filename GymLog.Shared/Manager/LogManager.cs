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
                var logs = DataManager.DB.Query<ExerciseLog>("SELECT * FROM ExerciseLog WHERE DateCreated BETWEEN '2016-05-30 00:00:00' AND '2016-05-31 00:00:00'");

                //var logs = (from l in DataManager.DB.Table<ExerciseLog>()
                //        where l.DateCreated.Date == DateTime.Today
                //            select l).ToList();
               

                return logs;
            }
        }

        
    }
}
