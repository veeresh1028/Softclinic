using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConcentForms
{
    public class DentalImplants
    {
        public static List<BusinessEntities.ConcentForms.DentalImplants> GetDentalImplantsData(int appId)
        {
            DataTable dt =  DataAccessLayer.ConcentForms.DentalImplants.GetDentalImplantsData(appId);
            List<BusinessEntities.ConcentForms.DentalImplants> list = new List<BusinessEntities.ConcentForms.DentalImplants>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.DentalImplants
                {
                    pcdId = Convert.ToInt32(dr["pcdId"]),
                    pcd_appId = Convert.ToInt32(dr["pcd_appId"]),
                    pcd_1 = dr["pcd_1"].ToString(),
                    pcd_2 = dr["pcd_2"].ToString(),
                    pcd_3 = dr["pcd_3"].ToString(),
                    pcd_4 = dr["pcd_4"].ToString(),
                    pcd_5 = dr["pcd_5"].ToString(),
                    pcd_status = dr["pcd_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveDentalImplants(BusinessEntities.ConcentForms.DentalImplants dental, int madeby)
        {
            return DataAccessLayer.ConcentForms.DentalImplants.SaveDentalImplants(dental, madeby);
        }

        public static int DeleteDentalImplants(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.DentalImplants.DeleteDentalImplants(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetDentalImplantsPreviousHistroy(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.DentalImplants.GetDentalImplantsPreviousHistroy(appId);
            List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> list = new List<BusinessEntities.ConcentForms.ConcentPreviousHistroy>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ConcentPreviousHistroy
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
