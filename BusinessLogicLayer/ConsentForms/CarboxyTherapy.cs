using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class CarboxyTherapy
    {
        public static List<BusinessEntities.ConsentForms.CarboxyTherapy> GetCarboxyTherapyData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.CarboxyTherapy.GetCarboxyTherapyData(appId);
            List<BusinessEntities.ConsentForms.CarboxyTherapy> list = new List<BusinessEntities.ConsentForms.CarboxyTherapy>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.CarboxyTherapy
                {
                    ctcId = Convert.ToInt32(dr["ctcId"]),
                    ctc_appId = Convert.ToInt32(dr["ctc_appId"]),
                    ctc_1 = dr["ctc_1"].ToString(),
                    ctc_status = dr["ctc_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveCarboxyTherapy(BusinessEntities.ConsentForms.CarboxyTherapy carboxy, int madeby)
        {
            return DataAccessLayer.ConsentForms.CarboxyTherapy.SaveCarboxyTherapy(carboxy, madeby);
        }

        public static int DeleteCarboxyTherapy(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.CarboxyTherapy.DeleteCarboxyTherapy(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetCarboxyTherapyPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.CarboxyTherapy.GetCarboxyTherapyPreviousHistory(appId);
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
