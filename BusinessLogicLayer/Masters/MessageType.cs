using BusinessEntities.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class MessageType
    {
        #region Message Type (Page Load)
        public static List<BusinessEntities.Masters.MessageType> GetMessageType(int? mtId)
        {
            List<BusinessEntities.Masters.MessageType> messagetypelist = new List<BusinessEntities.Masters.MessageType>();
            
            DataTable dt = DataAccessLayer.Masters.MessageType.GetMessageType(mtId);

            foreach (DataRow dr in dt.Rows)
            {
                messagetypelist.Add(new BusinessEntities.Masters.MessageType
                {
                    mtId = Convert.ToInt32(dr["mtId"]),
                    mt_type = dr["mt_type"].ToString(),
                    mt_branch = Convert.ToInt32(dr["mt_branch"]),
                    mt_desig = Convert.ToInt32(dr["mt_desig"]),
                    mt_emp = Convert.ToInt32(dr["mt_emp"]),
                    mt_status = dr["mt_status"].ToString(),
                    actionvisible = dr["actionvisible"].ToString(),
                    mt_date_created = Convert.ToDateTime(dr["mt_date_created"]),
                    mt_emp_name = dr["mt_emp_name"].ToString(),
                    mt_branch_name = dr["mt_branch_name"].ToString(),
                    mt_desig_name = dr["mt_desig_name"].ToString(),
                    mt_tat = dr["mt_tat"].ToString(),
                });
            }

            return messagetypelist;
        }
        #endregion

        #region Message Types CRUD Operations
        public static bool InsertUpdateMessageType(BusinessEntities.Masters.MessageType messagetype)
        {
            messagetype.mt_emp = (messagetype.mt_emp == 0) ? 0 : messagetype.mt_emp;
            messagetype.mt_tat = (messagetype.mt_tat == "") ? string.Empty : messagetype.mt_tat;

            return DataAccessLayer.Masters.MessageType.InsertUpdateMessagetype(messagetype);
        }

        public static int UpdateMessageTypeStatus(int tgId, string tg_status)
        {
            return DataAccessLayer.Masters.MessageType.UpdateMessageTypeStatus(tgId, tg_status);
        }

        public static DataTable GetAllEmployees(int? empId, int? emp_desig)
        {
            return DataAccessLayer.Masters.MessageType.GetAllEmployees(empId, emp_desig);
        }
        #endregion
    }
}
