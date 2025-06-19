using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class Dermatology
    {
        #region  Dermatology Notes (Page Load)
        public static List<BusinessEntities.EMR.DermatologyNotes> GetAllDermaNotes(int? appId, int? dnId)
        {
            List<BusinessEntities.EMR.DermatologyNotes> sclist = new List<BusinessEntities.EMR.DermatologyNotes>();
            DataTable dt = DataAccessLayer.EMR.Dermatology.GetAllDermaNotes(appId, dnId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.DermatologyNotes
                {
                    dnId = Convert.ToInt32(dr["dnId"]),
                    dn_appId = Convert.ToInt32(dr["dn_appId"]),
                    dn_notes = dr["dn_notes"].ToString(),
                    dn_status = dr["dn_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.DermatologyNotes> GetAllPreDermaNotes(int appId, int patId)
        {
            List<BusinessEntities.EMR.DermatologyNotes> sclist = new List<BusinessEntities.EMR.DermatologyNotes>();
            DataTable dt = DataAccessLayer.EMR.Dermatology.GetAllPreDermaNotes(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.DermatologyNotes
                {
                    dnId = Convert.ToInt32(dr["dnId"]),
                    dn_appId = Convert.ToInt32(dr["dn_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Dermatology Notes (Page Load)
        #region  Dermatology Notes CRUD Operations
        public static bool InsertUpdateDermaNotes(BusinessEntities.EMR.DermatologyNotes data)
        {
            data.dn_notes = string.IsNullOrEmpty(data.dn_notes) ? string.Empty : data.dn_notes;

            return DataAccessLayer.EMR.Dermatology.InsertUpdateDermaNotes(data);
        }

        public static int DeleteDermaNotes(int dnId, int dn_madeby)
        {
            return DataAccessLayer.EMR.Dermatology.DeleteDermaNotes(dnId, dn_madeby);
        }
        #endregion  Dermatology Notes CRUD Operations

    }
}
