using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConcentForms
{
    public class DentalSurgery
    {
        public static List<BusinessEntities.ConcentForms.DentalSurgery> GetDentalSurgeryData(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.DentalSurgery.GetDentalSurgeryData(appId);
            List<BusinessEntities.ConcentForms.DentalSurgery> list = new List<BusinessEntities.ConcentForms.DentalSurgery>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.DentalSurgery
                {
                    pdsId = Convert.ToInt32(dr["pdsId"]),
                    pds_appId = Convert.ToInt32(dr["pds_appId"]),
                    pds_1 = dr["pds_1"].ToString(),
                    pds_2 = dr["pds_2"].ToString(),
                    pds_3 = dr["pds_3"].ToString(),
                    pds_4 = dr["pds_4"].ToString(),
                    pds_5 = dr["pds_5"].ToString(),
                    pds_status = dr["pds_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveDentalSurgery(BusinessEntities.ConcentForms.DentalSurgery dental, int madeby)
        {
            return DataAccessLayer.ConcentForms.DentalSurgery.SaveDentalSurgery(dental, madeby);
        }

        public static int DeleteDentalSurgery(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.DentalSurgery.DeleteDentalSurgery(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDentalSurgeryPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.DentalSurgery.GetDentalSurgeryPreviousHistory(appId);
            List<BusinessEntities.ConcentForms.ConcentPreviousHistory> list = new List<BusinessEntities.ConcentForms.ConcentPreviousHistory>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ConcentPreviousHistory
                {
                    formId = Convert.ToInt32(dr["formId"]),
                    appId = Convert.ToInt32(dr["appId"]),
                    emp_license = dr["emp_license"].ToString(),
                    emp_name = dr["emp_name"].ToString() + " " + dr["emp_lname"].ToString(),
                    emp_dept_name = dr["emp_dept_name"].ToString(),
                    app_fdate = DateTime.Parse(dr["app_fdate"].ToString()).ToString("dd-MMM-yyyy") + " " + dr["app_doc_ftime"].ToString() + " - " + dr["app_doc_ttime"].ToString()
                });
            }
            return list;
        }
    }
}
