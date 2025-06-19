using BusinessEntities.Patient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.FrontDesk
{
    public class RegistrationForm
    {
        public static List<BusinessEntities.FrontDesk.RegistrationForm> GetRegistrationForm(int? appId)
        {
            List<BusinessEntities.FrontDesk.RegistrationForm> regiformlist = new List<BusinessEntities.FrontDesk.RegistrationForm>();
            DataTable dt = DataAccessLayer.FrontDesk.RegistrationForm.GetRegistrationForm(appId);

            foreach (DataRow dr in dt.Rows)
            {
                regiformlist.Add(new BusinessEntities.FrontDesk.RegistrationForm
                {
                    appId = Convert.ToInt32(dr["appId"]),
                    patId = Convert.ToInt32(dr["patId"]),
                    app_branch = Convert.ToInt32(dr["app_branch"]),
                    pat_dob = Convert.ToDateTime(dr["pat_dob"].ToString()),
                    pat_nat = Convert.ToInt32(dr["pat_nat"].ToString()),
                    pat_address = dr["pat_address"].ToString(),
                    pat_email = dr["pat_email"].ToString(),
                    pat_mob = dr["pat_mob"].ToString(),
                    pat_tel = dr["pat_tel"].ToString(),
                    pat_hear = dr["pat_hear"].ToString(),
                    pat_name = dr["pat_name"].ToString(),
                    pat_code = dr["pat_code"].ToString(),
                    pat_gender = dr["pat_gender"].ToString(),
                    ic_name = dr["ic_name"].ToString(),
                    ref_name = dr["ref_name"].ToString(),
                    nationality = dr["nationality"].ToString(),
                    set_company = dr["set_company"].ToString(),
                    pat_referal = Convert.ToInt32(dr["pat_referal"].ToString()),
                    

                });
            }
            return regiformlist;
        }
        public static bool UpdateRegistrationForm(BusinessEntities.FrontDesk.RegistrationForm data)
        {
            return DataAccessLayer.FrontDesk.RegistrationForm.UpdateRegistrationForm(data);
        }

    }
}
