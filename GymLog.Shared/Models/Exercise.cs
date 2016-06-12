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


      
        public List<string> MetricDisplayNames
        {
            get
            {
                var result = new List<string>();
               
                switch (ExerciseManager.GetMetricByName(Metric))
                {
                    case Enums.ExerciseMetricsEnum.Distance:
                        result.Add("mtr"); break;
                    case Enums.ExerciseMetricsEnum.Time:
                        result.Add("time"); break;
                    case Enums.ExerciseMetricsEnum.Weight:
                        result.Add("kg"); break;
                    case Enums.ExerciseMetricsEnum.Reps:
                        result.Add("reps" ); break;
                    case Enums.ExerciseMetricsEnum.WeightAndReps:
                        result.Add("kg"); result.Add("reps"); break;
                    case Enums.ExerciseMetricsEnum.WeightAndTime:
                        result.Add("kg"); result.Add("time"); break;
                    case Enums.ExerciseMetricsEnum.TimeAndDistance:
                        result.Add("mtrs"); result.Add("time"); break;
                }                    
                

                return result;
            }
        }
    }
}
