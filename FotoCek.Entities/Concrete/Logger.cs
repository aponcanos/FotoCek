using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoCek.Entities.DbClasses
{
    public interface Logger
    {
        void LogToNotepad(string LogDetails);
        void LogToDB(string LogDetails);
    }
}
