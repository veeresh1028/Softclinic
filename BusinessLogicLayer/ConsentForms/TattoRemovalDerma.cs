using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class TattoRemovalDerma
    {
        public static List<BusinessEntities.ConsentForms.TattoRemovalDerma> GetTattoRemovalDermaData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.TattoRemovalDerma.GetTattoRemovalDermaData(appId);
            List<BusinessEntities.ConsentForms.TattoRemovalDerma> list = new List<BusinessEntities.ConsentForms.TattoRemovalDerma>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.TattoRemovalDerma
                {
                    trcId = Convert.ToInt32(dr["trcId"]),
                    trc_appId = Convert.ToInt32(dr["trc_appId"]),
                    trc_1 = dr["trc_1"].ToString(),
                    trc_status = dr["trc_status"].ToString(),
                    trc_date_modified = Convert.ToDateTime(dr["trc_date_modified"].ToString()),

                });
            }
            return list;
        }


        public static int SaveTattoRemovalDerma(BusinessEntities.ConsentForms.TattoRemovalDerma tatto, int madeby)
        {
            return DataAccessLayer.ConsentForms.TattoRemovalDerma.SaveTattoRemovalDerma(tatto, madeby);
        }


        public static int DeleteTattoRemovalDerma(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.TattoRemovalDerma.DeleteTattoRemovalDerma(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetTattoRemovalDermaPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.TattoRemovalDerma.GetTattoRemovalDermaPreviousHistory(appId);
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
