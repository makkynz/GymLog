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
        public List<Enums.ExerciseMetricsEnum> Metrics
        {
            get
            {
                //TODO:  finish this
                return new List<Enums.ExerciseMetricsEnum>() { Enums.ExerciseMetricsEnum.Weight, Enums.ExerciseMetricsEnum.Reps };
            }
        }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string KeyStat { get { return "1 Rep Max: 70Kg"; } }

          
        public List<string> MetricDisplayNames
        {
            get
            {
                var result = new List<string>();
                foreach(Enums.ExerciseMetricsEnum metric in Metrics)
                {
                    switch (metric)
                    {
                        case Enums.ExerciseMetricsEnum.Weight:
                            result.Add("kg"); break;

                        case Enums.ExerciseMetricsEnum.Reps:
                            result.Add("reps" ); break;

                        case Enums.ExerciseMetricsEnum.Time:
                            result.Add("time"); break;
                         

                    }                    
                }

                return result;
            }
        }
    }
}
