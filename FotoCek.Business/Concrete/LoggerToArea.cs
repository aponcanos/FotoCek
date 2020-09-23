using FotoCek.DAL;
using FotoCek.Entities.DbClasses;
using System;
using System.IO;
using FotoCek.DAL.Concrete.EntityFramework;

namespace FotoCek.Business.Classes.Logging
{
    public class LoggerToArea : Logger
    {
        private DatabaseContext _context;
        public LoggerToArea()
        {
            _context = new DatabaseContext();
        }

        public void LogToNotepad(string LogDetails)
        {
            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\" + "log.txt", new[] { LogDetails + "---" + DateTime.Now });
        }

        public void LogToDB(string LogDetails)
        {
            _context.Logs.Add(new Log
            {
                Details = LogDetails,
                LogDateTime = DateTime.Now
            });

            _context.SaveChanges();
        }
    }
}