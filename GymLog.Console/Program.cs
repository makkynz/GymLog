using GymLog.Shared.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c = System.Console;
namespace GymLog.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            c.WriteLine("Creating DB");

            DataManager.CreateDatabase();

            c.WriteLine("Success");
            c.ReadLine();
        }
    }
}
