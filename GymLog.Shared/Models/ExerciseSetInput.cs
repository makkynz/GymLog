using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog.Shared.Models
{
    public class ExerciseSetInput
    {

        public Enums.SetInputTypes InputType { get; set; }
        public string Label { get; set; }
        public double? Value { get; set; }

        public string ValueAsString
        {
            get
            {
                return Value.HasValue ? Value.Value.ToString() : "";
               
            }
        }

        public string DisplayString
        {
            get
            {
                return $"{ValueAsString} {Label}";
            }
        }
    }
}
