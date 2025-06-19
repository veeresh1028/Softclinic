using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Lists
{
    public class DownloadFile
    {
        public static DataTable GetFilePathDownload(int id, string type)
        {
            return DataAccessLayer.Lists.DownloadFile.GetFilePathDownload(id, type);
        }

        public static DataTable GetEMIDPathDownload(int id)
        {
            return DataAccessLayer.Lists.DownloadFile.GetEMIDPathDownload(id);
        }
    }
}