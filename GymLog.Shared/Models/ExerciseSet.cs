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

        public List<ExerciseSetInput> Inputs
        {
            get
            {
                var result = new List<ExerciseSetInput>();

                switch (ExerciseManager.GetMetricByName(this.ExerciseLog.Exercise.Metric))
                {
                    case Enums.ExerciseMetricsEnum.Distance:
                        result.Add( new ExerciseSetInput { InputType = Enums.SetInputTypes.Decimal, Label = "mtr", Value = StatOne } ); break;
                    case Enums.ExerciseMetricsEnum.Time:
                        result.Add(new ExerciseSetInput { InputType = Enums.SetInputTypes.Time, Label = "mins", Value = StatOne }); break;
                       
                    case Enums.ExerciseMetricsEnum.Weight:
                        result.Add(new ExerciseSetInput { InputType = Enums.SetInputTypes.Decimal, Label = "kg", Value = StatOne }); break;
                        
                    case Enums.ExerciseMetricsEnum.Reps:
                        result.Add(new ExerciseSetInput { InputType = Enums.SetInputTypes.Number, Label = "reps", Value = StatOne }); break;
                       
                    case Enums.ExerciseMetricsEnum.WeightAndReps:
                        result.Add(new ExerciseSetInput { InputType = Enums.SetInputTypes.Decimal, Label = "kg", Value = StatOne });
                        result.Add(new ExerciseSetInput { InputType = Enums.SetInputTypes.Number, Label = "reps", Value = StatTwo });
                        break;
                       
                    case Enums.ExerciseMetricsEnum.WeightAndTime:
                        result.Add(new ExerciseSetInput { InputType = Enums.SetInputTypes.Decimal, Label = "kg", Value = StatOne });
                        result.Add(new ExerciseSetInput { InputType = Enums.SetInputTypes.Time, Label = "mins", Value = StatTwo });
                        break;
                    case Enums.ExerciseMetricsEnum.TimeAndDistance:
                        result.Add(new ExerciseSetInput { InputType = Enums.SetInputTypes.Decimal, Label = "mtr", Value = StatOne });
                        result.Add(new ExerciseSetInput { InputType = Enums.SetInputTypes.Time, Label = "mins", Value = StatTwo });
                        break;
                }

                return result;
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

        public void Delete()
        {
            if (this.Id.HasValue)
            {
                var db = DataManager.DB;
                db.Delete(this);
                db.Commit();
            }
        }

    }
}
