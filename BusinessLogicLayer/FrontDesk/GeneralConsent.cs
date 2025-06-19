using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.FrontDesk
{
    public class GeneralConsent
    {
        public static List<BusinessEntities.FrontDesk.GeneralConsent> GetAppointmentPatient(int? appId)
        {
            List<BusinessEntities.FrontDesk.GeneralConsent> regiformlist = new List<BusinessEntities.FrontDesk.GeneralConsent>();
            DataTable dt = DataAccessLayer.FrontDesk.GeneralConsent.GetAppointmentPatient(appId);

            foreach (DataRow dr in dt.Rows)
            {
                regiformlist.Add(new BusinessEntities.FrontDesk.GeneralConsent
                {
                    appId = Convert.ToInt32(dr["appId"]),
                    patId = Convert.ToInt32(dr["patId"]),
                    app_branch = Convert.ToInt32(dr["app_branch"]),
                    pat_dob = dr["pat_dob"].ToString(),
                    app_fdate = dr["app_fdate"].ToString(),
                    nationality = dr["nationality"].ToString(),
                    pat_emirateid = dr["pat_emirateid"].ToString(),
                    pat_mob = dr["pat_mob"].ToString(),
                    doc_name = dr["doc_name"].ToString(),
                    pat_name = dr["pat_name"].ToString(),
                    pat_code = dr["pat_code"].ToString(),
                    pat_gender = dr["pat_gender"].ToString(),
                    ic_name = dr["ic_name"].ToString(),


                });
            }
            return regiformlist;
        }

        public static List<BusinessEntities.FrontDesk.GeneralConsent> GetGeneralConsentAll(int appId)
        {
            List<BusinessEntities.FrontDesk.GeneralConsent> ic = new List<BusinessEntities.FrontDesk.GeneralConsent>();
            DataTable dt = DataAccessLayer.FrontDesk.GeneralConsent.GetGeneralConsentAll(appId);

            foreach (DataRow dr in dt.Rows)
            {
                ic.Add(new BusinessEntities.FrontDesk.GeneralConsent
                {
                    appId = Convert.ToInt32(dr["gcf_appId"]),
                    gcfId = Convert.ToInt32(dr["gcfId"]),
                    gcf_witness = dr["gcf_witness"].ToString(),



                });
            }
            return ic;
        }
        public static int DeleteGeneralConsent(int gcfId, string gcf_status, int gcf_madeby)
        {
            return DataAccessLayer.FrontDesk.GeneralConsent.DeleteGeneralConsent(gcfId, gcf_status,gcf_madeby);
        }
        public static bool InsertUpdateGeneralConsent(BusinessEntities.FrontDesk.GeneralConsent data)
        {
            return DataAccessLayer.FrontDesk.GeneralConsent.InsertUpdateGeneralConsent(data);
        }
    }
}
