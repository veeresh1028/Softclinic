using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class LaserMarking
    {

        #region Botex Picture Men (Page Load)


        //GET LaserMarking
        public static List<BusinessEntities.EMR.LaserMarking> GetLaserMarking(int? appId, int? lfmId, string lfm_form)
        {
            try
            {
                DataTable dt = DataAccessLayer.EMR.LaserMarking.GetLaserMarking(appId, lfmId, lfm_form);

                List<BusinessEntities.EMR.LaserMarking> list = new List<BusinessEntities.EMR.LaserMarking>();


                foreach (DataRow dr in dt.Rows)
                {
                    BusinessEntities.EMR.LaserMarking a = new BusinessEntities.EMR.LaserMarking();
                    a.lfm_appId = Convert.ToInt32(dr["lfm_appId"]);
                    a.lfmId = Convert.ToInt32(dr["lfmId"]);
                    a.lfm_patId = Convert.ToInt32(dr["lfm_patId"]);
                    a.lfm_doc2 = dr["lfm_doc2"].ToString();
                    a.lfm_form = dr["lfm_form"].ToString();
                    a.lfm_date_created = Convert.ToDateTime(dr["lfm_date_created"]);
                    if (!string.IsNullOrEmpty(dr["lfm_doc"].ToString()))
                    {
                        a.lfm_doc = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + dr["lfm_doc"].ToString();
                    }
                    else
                    {

                        a.lfm_doc = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/tooth_chart/CHART.PNG";

                    }


                    list.Add(a);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BusinessEntities.EMR.LaserMarking> GetAllPreLaserMarking(int appId, int patId, string lfm_form)
        {
            List<BusinessEntities.EMR.LaserMarking> sclist = new List<BusinessEntities.EMR.LaserMarking>();
            DataTable dt = DataAccessLayer.EMR.LaserMarking.GetAllPreLaserMarking(appId, patId, lfm_form);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.LaserMarking
                {
                    lfmId = Convert.ToInt32(dr["lfmId"]),
                    lfm_appId = Convert.ToInt32(dr["lfm_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion Botex Picture Men (Page Load)
        #region Botex Picture Men  CRUD Operations
        //upload LaserMarking
        public static bool UploadLaserMarking(BusinessEntities.EMR.LaserMarking data, int empId)
        {
            return DataAccessLayer.EMR.LaserMarking.UploadLaserMarking(data, empId);
        }
        public static int DeleteLaserMarking(int lfmId, int lfm_madeby)
        {
            return DataAccessLayer.EMR.LaserMarking.DeleteLaserMarking(lfmId, lfm_madeby);
        }
        #endregion Botex Picture Men  CRUD Operations
    }
}
