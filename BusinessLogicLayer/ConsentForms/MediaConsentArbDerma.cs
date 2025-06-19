using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class MediaConsentArbDerma
    {
        public static List<BusinessEntities.ConsentForms.MediaConsentArbDerma> GetMediaConsentArbDermaData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MediaConsentArbDerma.GetMediaConsentArbDermaData(appId);
            List<BusinessEntities.ConsentForms.MediaConsentArbDerma> list = new List<BusinessEntities.ConsentForms.MediaConsentArbDerma>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.MediaConsentArbDerma
                {
                    mcaId = Convert.ToInt32(dr["mcaId"]),
                    mca_appId = Convert.ToInt32(dr["mca_appId"]),
                    mca_1 = dr["mca_1"].ToString(),
                    mca_status = dr["mca_status"].ToString(),
                    mca_date_modified = Convert.ToDateTime(dr["mca_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveMediaConsentArbDerma(BusinessEntities.ConsentForms.MediaConsentArbDerma derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.MediaConsentArbDerma.SaveMediaConsentArbDerma(derma, madeby);
        }
        public static int DeleteMediaConsentArbDerma(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.MediaConsentArbDerma.DeleteMediaConsentArbDerma(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetMediaConsentArbDermaPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MediaConsentArbDerma.GetMediaConsentArbDermaPreviousHistory(appId);
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
