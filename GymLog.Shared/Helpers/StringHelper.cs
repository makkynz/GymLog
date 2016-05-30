using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog.Shared.Helpers
{
    public class StringHelper
    {

        public static string Pluralise(string wordSingular, string wordPlural, int count)
        {
            return count == 1 || count == -1 ? wordSingular : wordPlural; 
        }
    }
}
