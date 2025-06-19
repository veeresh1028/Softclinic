using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class PhotoConsentDerma
    {
        public static List<BusinessEntities.ConsentForms.PhotoConsentDerma> GetPhotoConsentDermaData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PhotoConsentDerma.GetPhotoConsentDermaData(appId);
            List<BusinessEntities.ConsentForms.PhotoConsentDerma> list = new List<BusinessEntities.ConsentForms.PhotoConsentDerma>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.PhotoConsentDerma
                {
                    cpcId = Convert.ToInt32(dr["cpcId"]),
                    cpc_appId = Convert.ToInt32(dr["cpc_appId"]),
                    cpc_1 = dr["cpc_1"].ToString(),
                    cpc_status = dr["cpc_status"].ToString(),
                    cpc_date_modified = Convert.ToDateTime(dr["cpc_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SavePhotoConsentDerma(BusinessEntities.ConsentForms.PhotoConsentDerma photo, int madeby)
        {
            return DataAccessLayer.ConsentForms.PhotoConsentDerma.SavePhotoConsentDerma(photo, madeby);
        }



        public static int DeletePhotoConsentDerma(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.PhotoConsentDerma.DeletePhotoConsentDerma(appId, madeby);
        }



        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetPhotoConsentDermaPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PhotoConsentDerma.GetPhotoConsentDermaPreviousHistory(appId);
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
