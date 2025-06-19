using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Tab
{
    public class PatientConsents
    {
        #region Dropdown Filters
        public static List<CommonDDL> SearchPatients(int type, string query)
        {
            DataTable dt = DataAccessLayer.Tab.PatientConsents.SearchPatients(type, query);

            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new CommonDDL
                    {
                        id = Convert.ToInt32(dr["patId"]),
                        text = "<span class=\"text-primary\"> " + dr["pat_code"].ToString() + " - " + dr["pat_name"].ToString() + " - " +
                        dr["pat_mob"].ToString() + " - " + dr["pat_emirateid"].ToString() +
                        " [<span class=\"badge fs-12 bg-info-transparent text-info\">" + dr["app_count"].ToString() + " Appointment(s)</span>]"
                    });
                }
            }

            return data;
        }

        public static List<CommonDDLFORMS> GetClaimForms()
        {
            List<CommonDDLFORMS> branchlist = new List<CommonDDLFORMS>();

            DataTable dt = DataAccessLayer.Tab.PatientConsents.GetClaimForms();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    branchlist.Add(new CommonDDLFORMS
                    {
                        id = dr["id"].ToString(),
                        text = dr["text"].ToString()
                    });
                }
            }

            return branchlist;
        }
        #endregion
    }
}