using BusinessEntities.Appointment;
using BusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLogicLayer.Common
{
    #region eSignature
    public class eSignature
    {
        //upload eSignature
        public static bool UploadSignature(BusinessEntities.Common.eSignature sign, int empId)
        {
            return DataAccessLayer.Common.eSignature.UploadSignature(sign, empId);
        }

        //GET eSignature
        public static List<BusinessEntities.Common.eSignature> GetSignature(int? appId, string person, string form)
        {           
            try
            {
                DataTable dt = DataAccessLayer.Common.eSignature.GetSignature(appId, person, form);

                List<BusinessEntities.Common.eSignature> list = new List<BusinessEntities.Common.eSignature>();
                
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Common.eSignature a = new BusinessEntities.Common.eSignature();
                        a.appId = Convert.ToInt32(dr["psb_appId"]);
                        a.patId = Convert.ToInt32(dr["psb_patId"]);
                        a.form = dr["psb_form"].ToString();
                        a.person = dr["psb_person"].ToString();
                        a.eSign = dr["psb_sign"].ToString();
                        a.eSign = dr["psb_sign"].ToString();
                        a.psb_date_Created = Convert.ToDateTime(dr["psb_date_created"]);
                        a.psb_date_modified = Convert.ToDateTime(dr["psb_date_modified"]);
                        
                        if (!string.IsNullOrEmpty(dr["psb_sign"].ToString()))
                        {
                            a.psb_sign = (ConfigurationManager.AppSettings["ClinicSoftEndPoint"] + dr["psb_sign"].ToString()).Replace("\\", "/"); ;
                        }
                        else
                        {

                            a.psb_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"] + "images/signature_bg.jpg";

                        }

                        list.Add(a);
                    }
                }
                else
                {
                    BusinessEntities.Common.eSignature a = new BusinessEntities.Common.eSignature();
                    a.psb_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"] + "images/signature_bg.jpg";

                    list.Add(a);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
    #endregion eSignature
}
