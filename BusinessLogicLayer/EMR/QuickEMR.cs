using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class QuickEMR
    {

        public static List<BusinessEntities.EMR.SignedDocuments> GetAllSignedDocuments(int appId)
        {
            List<BusinessEntities.EMR.SignedDocuments> sclist = new List<BusinessEntities.EMR.SignedDocuments>();
            DataTable dt = DataAccessLayer.EMR.QuickEMR.GetAllSignedDocuments(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.SignedDocuments
                {
                    psbId = Convert.ToInt32(dr["psbId"]),
                    psb_appId = Convert.ToInt32(dr["psb_appId"]),
                    psb_file = dr["psb_file"].ToString(),
                    psb_formlink = dr["psb_formlink"].ToString(),
                    psb_date_created = Convert.ToDateTime(dr["psb_date_created"].ToString()),
                    psb_status = dr["psb_status"].ToString(),
                    FileN = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + dr["FileN"].ToString(),

                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.SignedDocuments> GetAllPreSignedDocuments(int appId, int patId)
        {
            List<BusinessEntities.EMR.SignedDocuments> sclist = new List<BusinessEntities.EMR.SignedDocuments>();
            DataTable dt = DataAccessLayer.EMR.QuickEMR.GetAllPreSignedDocuments(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.SignedDocuments
                {
                    psbId = Convert.ToInt32(dr["psbId"]),
                    psb_appId = Convert.ToInt32(dr["psb_appId"]),
                    psb_file = dr["psb_file"].ToString(),
                    psb_formlink = dr["psb_formlink"].ToString(),
                    psb_date_created = Convert.ToDateTime(dr["psb_date_created"].ToString()),
                    psb_status = dr["psb_status"].ToString(),
                    FileN = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + dr["FileN"].ToString(),

                });
            }
            return sclist;
        }

        #region Start End Time (Page Load)

        public static List<BusinessEntities.EMR.StartEndTime> GetStartEndTime(int appId)
        {
            List<BusinessEntities.EMR.StartEndTime> sclist = new List<BusinessEntities.EMR.StartEndTime>();
            DataTable dt = DataAccessLayer.EMR.QuickEMR.GetStartEndTime(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.StartEndTime
                {
                    tId = Convert.ToInt32(dr["tId"]),
                    t_appId = Convert.ToInt32(dr["t_appId"]),
                    t_start1 = dr["t_start"].ToString(),
                    t_end1 = dr["t_end"].ToString(),
                    t_status = dr["t_status"].ToString(),
                    t_duration = dr["t_duration"].ToString(),

                });
            }
            return sclist;
        }
        public static bool InsertUpdateStartEndTime(BusinessEntities.EMR.StartEndTime data)
        {
             DateTime? tstart = data.t_start;
             DateTime? tend = data.t_end;
            if (data.t_start != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.t_start = tstart.HasValue ? tstart.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.t_start = DateTime.Parse("01/01/1950");
            }
            if (data.t_end != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.t_end = tend.HasValue ? tend.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.t_end = DateTime.Parse("01/01/1950");
            }

            return DataAccessLayer.EMR.QuickEMR.InsertUpdateStartEndTime(data);
        }
        #endregion Start End Time (Page Load)
    }
}
