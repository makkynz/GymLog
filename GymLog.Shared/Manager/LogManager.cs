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
                var logs = new List<ExerciseLog>();
                var rand = new Random();
                for (var i =0; i< 10;i++)
                {
                    logs.Add(new ExerciseLog { DateCreated = DateTime.Now, Exercise = em.GetRandomExercise(), SetCount = rand.Next(10) });
                }

                return logs;
            }
        }
    }
}
