using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class ComplaintsMaster
    {
        #region Complaints Master (Page Load)
        public static List<BusinessEntities.Masters.ComplaintsMaster> GetComplaintsMaster(int? cmId)
        {
            List<BusinessEntities.Masters.ComplaintsMaster> complaints = new List<BusinessEntities.Masters.ComplaintsMaster>();

            DataTable dt = DataAccessLayer.Masters.ComplaintsMaster.GetComplaintsMaster(cmId);

            foreach (DataRow dr in dt.Rows)
            {
                complaints.Add(new BusinessEntities.Masters.ComplaintsMaster
                {
                    cmId = Convert.ToInt32(dr["cmId"]),
                    cm_title = dr["cm_title"].ToString(),
                    cm_desc = dr["cm_desc"].ToString(),
                    cm_status = dr["cm_status"].ToString(),
                    actionvisible = dr["actionvisible"].ToString(),
                    cm_date_created = Convert.ToDateTime(dr["cm_date_created"]),
                    cm_madeby_name = dr["cm_madeby_name"].ToString(),
                });
            }
            return complaints;
        }
        #endregion

        #region Complaints CRUD Operations
        public static bool InsertUpdateComplaint(BusinessEntities.Masters.ComplaintsMaster complaints)
        {
            return DataAccessLayer.Masters.ComplaintsMaster.InsertUpdateComplaintsMaster(complaints);
        }

        public static int UpdateComplaintStatus(int tgId, string tg_status)
        {
            return DataAccessLayer.Masters.ComplaintsMaster.UpdateComplaintsMasterStatus(tgId, tg_status);
        }
        #endregion
    }
}