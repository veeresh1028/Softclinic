using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class MedicalDecision
    {
        #region GastoIntestial (Page Load)

        public static List<BusinessEntities.EMR.MedicalDecision> GetAllMedicalDecision(int? appId, int? mdId)
        {
            List<BusinessEntities.EMR.MedicalDecision> sclist = new List<BusinessEntities.EMR.MedicalDecision>();
            DataTable dt = DataAccessLayer.EMR.MedicalDecision.GetAllMedicalDecision(appId, mdId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.MedicalDecision
                {
                    mdId = Convert.ToInt32(dr["mdId"]),
                    md_appId = Convert.ToInt32(dr["md_appId"]),
                    md_txt1 = dr["md_txt1"].ToString(),
                    md_txt2 = dr["md_txt2"].ToString(),
                    md_txt3 = dr["md_txt3"].ToString(),
                    md_txt4 = dr["md_txt4"].ToString(),
                    md_txt5 = dr["md_txt5"].ToString(),
                    md_txt6 = dr["md_txt6"].ToString(),
                    md_txt7 = dr["md_txt7"].ToString(),
                    md_chk = dr["md_chk"].ToString(),

                    md_status = dr["md_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.MedicalDecision> GetAllPreMedicalDecision(int appId, int patId)
        {
            List<BusinessEntities.EMR.MedicalDecision> sclist = new List<BusinessEntities.EMR.MedicalDecision>();
            DataTable dt = DataAccessLayer.EMR.MedicalDecision.GetAllPreMedicalDecision(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.MedicalDecision
                {
                    mdId = Convert.ToInt32(dr["mdId"]),
                    md_appId = Convert.ToInt32(dr["md_appId"]),
                    md_txt1 = dr["md_txt1"].ToString(),
                    md_txt2 = dr["md_txt2"].ToString(),
                    md_txt3 = dr["md_txt3"].ToString(),
                    md_txt4 = dr["md_txt4"].ToString(),
                    md_txt5 = dr["md_txt5"].ToString(),
                    md_txt6 = dr["md_txt6"].ToString(),
                    md_txt7 = dr["md_txt7"].ToString(),
                    md_chk = dr["md_chk"].ToString(),
                    
                    doctor_name = dr["doctor_name"].ToString(),

                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion GastoIntestial (Page Load)
        #region GastoIntestial CRUD Operations
        public static bool InsertUpdateMedicalDecision(BusinessEntities.EMR.MedicalDecision data)
        {
            data.md_txt1 = string.IsNullOrEmpty(data.md_txt1) ? string.Empty : data.md_txt1;
            data.md_txt2 = string.IsNullOrEmpty(data.md_txt2) ? string.Empty : data.md_txt2;
            data.md_txt3 = string.IsNullOrEmpty(data.md_txt3) ? string.Empty : data.md_txt3;
            data.md_txt4 = string.IsNullOrEmpty(data.md_txt4) ? string.Empty : data.md_txt4;
            data.md_txt5 = string.IsNullOrEmpty(data.md_txt5) ? string.Empty : data.md_txt5;
            data.md_txt6 = string.IsNullOrEmpty(data.md_txt6) ? string.Empty : data.md_txt6;
            data.md_txt7 = string.IsNullOrEmpty(data.md_txt7) ? string.Empty : data.md_txt7;
            data.md_chk = string.IsNullOrEmpty(data.md_chk) ? string.Empty : data.md_chk;
            
            return DataAccessLayer.EMR.MedicalDecision.InsertUpdateMedicalDecision(data);
        }

        public static int DeleteMedicalDecision(int mdId, int md_madeby)
        {
            return DataAccessLayer.EMR.MedicalDecision.DeleteMedicalDecision(mdId, md_madeby);
        }

        #endregion GastoIntestial CRUD Operations
    }
}
