using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class JustificationLetter
    {
        #region  Justification Letter (Page Load)
        public static List<BusinessEntities.EMR.JustificationLetter> GetAllJustificationLetter(int? appId, int? jlId)
        {
            List<BusinessEntities.EMR.JustificationLetter> sclist = new List<BusinessEntities.EMR.JustificationLetter>();
            DataTable dt = DataAccessLayer.EMR.JustificationLetter.GetAllJustificationLetter(appId, jlId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.JustificationLetter
                {
                    jlId = Convert.ToInt32(dr["jlId"]),
                    jl_appId = Convert.ToInt32(dr["jl_appId"]),
                    jl_note = dr["jl_note"].ToString(),
                    jl_date = Convert.ToDateTime(dr["jl_date"].ToString()),
                    jl_status = dr["jl_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.JustificationLetter> GetAllPreJustificationLetter(int appId, int patId)
        {
            List<BusinessEntities.EMR.JustificationLetter> sclist = new List<BusinessEntities.EMR.JustificationLetter>();
            DataTable dt = DataAccessLayer.EMR.JustificationLetter.GetAllPreJustificationLetter(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.JustificationLetter
                {
                    jlId = Convert.ToInt32(dr["jlId"]),
                    jl_appId = Convert.ToInt32(dr["jl_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Justification Letter (Page Load)
        #region  Justification Letter CRUD Operations
        public static bool InsertUpdateJustificationLetter(BusinessEntities.EMR.JustificationLetter data)
        {
            data.jl_note = string.IsNullOrEmpty(data.jl_note) ? string.Empty : data.jl_note;

            return DataAccessLayer.EMR.JustificationLetter.InsertUpdateJustificationLetter(data);
        }

        public static int DeleteJustificationLetter(int jlId, int jl_madeby)
        {
            return DataAccessLayer.EMR.JustificationLetter.DeleteJustificationLetter(jlId, jl_madeby);
        }
        #endregion  Justification Letter CRUD Operations
        #region  Health Declaration (Page Load)
        public static List<BusinessEntities.EMR.HealthDeclaration> GetAllHealthDeclaration(int? appId, int? chd_Id)
        {
            List<BusinessEntities.EMR.HealthDeclaration> sclist = new List<BusinessEntities.EMR.HealthDeclaration>();
            DataTable dt = DataAccessLayer.EMR.JustificationLetter.GetAllHealthDeclaration(appId, chd_Id);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.HealthDeclaration
                {
                    chd_Id = Convert.ToInt32(dr["chd_Id"]),
                    chd_appId = Convert.ToInt32(dr["chd_appId"]),
                    chd_checkbox = dr["chd_checkbox"].ToString(),
                    chd_Prob1 = dr["chd_Prob1"].ToString(),
                    chd_Prob2 = dr["chd_Prob2"].ToString(),
                    chd_Prob3 = dr["chd_Prob3"].ToString(),
                    chd_Prob4 = dr["chd_Prob4"].ToString(),
                    chd_Prob5 = dr["chd_Prob5"].ToString(),                    
                    chd_status = dr["chd_status"].ToString(),
                    pa_pain = Convert.ToInt32(dr["pa_pain"]),
                    paId = Convert.ToInt32(dr["paId"]),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.HealthDeclaration> GetAllPreHealthDeclaration(int appId, int patId)
        {
            List<BusinessEntities.EMR.HealthDeclaration> sclist = new List<BusinessEntities.EMR.HealthDeclaration>();
            DataTable dt = DataAccessLayer.EMR.JustificationLetter.GetAllPreHealthDeclaration(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.HealthDeclaration
                {
                    chd_Id = Convert.ToInt32(dr["chd_Id"]),
                    chd_appId = Convert.ToInt32(dr["chd_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Health Declaration (Page Load)
        #region  Health Declaration CRUD Operations
        public static bool InsertUpdateHealthDeclaration(BusinessEntities.EMR.HealthDeclaration data)
        {
            bool isDone = false;

            data.chd_Prob1 = string.IsNullOrEmpty(data.chd_Prob1) ? string.Empty : data.chd_Prob1;
            data.chd_Prob2 = string.IsNullOrEmpty(data.chd_Prob2) ? string.Empty : data.chd_Prob2;
            data.chd_Prob3 = string.IsNullOrEmpty(data.chd_Prob3) ? string.Empty : data.chd_Prob3;
            data.chd_Prob4 = string.IsNullOrEmpty(data.chd_Prob4) ? string.Empty : data.chd_Prob4;
            data.chd_Prob5 = string.IsNullOrEmpty(data.chd_Prob5) ? string.Empty : data.chd_Prob5;
            data.chd_checkbox = string.IsNullOrEmpty(data.chd_checkbox) ? string.Empty : data.chd_checkbox;
            
            BusinessEntities.EMR.PainScale pain = new BusinessEntities.EMR.PainScale();
            pain.paId = data.chd_Id;
            pain.pa_appId = data.chd_appId;
            pain.pa_pain = data.pa_pain;
            pain.pa_madeby = data.chd_madeby;
            isDone =  DataAccessLayer.EMR.PainScale.InsertUpdatePainScale(pain);

           
            if (isDone)
            {
                return DataAccessLayer.EMR.JustificationLetter.InsertUpdateHealthDeclaration(data);
            }
            else
            {
                return false;
            }
            

        }

        public static int DeleteHealthDeclaration(int chd_Id, int chd_madeby)
        {
            return DataAccessLayer.EMR.JustificationLetter.DeleteHealthDeclaration(chd_Id, chd_madeby);
        }
        #endregion  Health Declaration CRUD Operations

    }
}
