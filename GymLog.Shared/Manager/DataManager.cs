using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymLog.Shared.Models;
using SQLite;
using System.IO;

namespace GymLog.Shared.Manager
{
    public class DataManager
    {
        public const string DB_FILE = "gymlog.db";
        static SQLiteConnection _dbConn;

       

        public static SQLiteConnection DB
        {
            get
            {
                if(_dbConn == null)
                {                   
                    var dbPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), DataManager.DB_FILE);
                    _dbConn = new SQLiteConnection(dbPath);
                }
                return _dbConn;
            }
        }
    }
}
