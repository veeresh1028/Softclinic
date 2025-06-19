using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class NotesMaster
    {
       
        public static int CreateNotesMasters(BusinessEntities.EMR.NotesMaster item, int madeby)
        {
            return DataAccessLayer.EMR.NotesMaster.CreateNotesMaster(item, madeby);
        }

        public static List<BusinessEntities.EMR.NotesMaster> GetNotesMasters(int ? nsmId, string nsm_flag)
        {
            DataTable dt = DataAccessLayer.EMR.NotesMaster.GetNotesMaster(nsmId, nsm_flag);

            List<BusinessEntities.EMR.NotesMaster> data = new List<BusinessEntities.EMR.NotesMaster>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    BusinessEntities.EMR.NotesMaster _data = new BusinessEntities.EMR.NotesMaster();
                    _data.nsmId = int.Parse(row["nsmId"].ToString());
                    _data.nsm_title = row["nsm_title"].ToString();
                    _data.nsm_desc = row["nsm_desc"].ToString();
                    _data.nsm_flag = row["nsm_flag"].ToString();
                    _data.nsm_status = row["nsm_status"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }

        public static int UpdateNotesMasterStatus(int nsmId, string status)
        {
            return DataAccessLayer.EMR.NotesMaster.UpdateNotesMastertatus(nsmId, status);
        }
    }
}
