using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using GymLog.Shared.Manager;

namespace GymLog
{
    [Application]
    public class GymLoggApp: Application
    {
        public GymLoggApp(IntPtr handle, JniHandleOwnership ownerShip) : base(handle, ownerShip)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            var docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);            
            var dbFile = Path.Combine(docFolder, DataManager.DB_FILE); // FILE NAME TO USE WHEN COPIED
            System.IO.File.Delete(dbFile);
            if (!System.IO.File.Exists(dbFile))
            {
                
                var s = Application.Context.Assets.Open(DataManager.DB_FILE); // DATA FILE RESOURCE ID
                FileStream writeStream = new FileStream(dbFile, FileMode.OpenOrCreate, FileAccess.Write);
                ReadWriteStream(s, writeStream);
            }
        }
        // readStream is the stream you need to read
        // writeStream is the stream you want to write to
        private void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}