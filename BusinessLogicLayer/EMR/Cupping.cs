using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class Cupping
    {
        #region Cupping Therapy (Page Load)


        //GET Cupping
        public static List<BusinessEntities.EMR.LaserMarking> GetCupping(int? appId, int? lfmId, string lfm_form)
        {
            try
            {
                DataTable dt = DataAccessLayer.EMR.Cupping.GetCupping(appId, lfmId, lfm_form);

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

        public static List<BusinessEntities.EMR.LaserMarking> GetAllPreCupping(int appId, int patId, string lfm_form)
        {
            List<BusinessEntities.EMR.LaserMarking> sclist = new List<BusinessEntities.EMR.LaserMarking>();
            DataTable dt = DataAccessLayer.EMR.Cupping.GetAllPreCupping(appId, patId, lfm_form);

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
        #endregion Cupping Therapy (Page Load)
        #region Cupping Therapy  CRUD Operations
        //upload Cupping
        public static bool UploadCupping(BusinessEntities.EMR.LaserMarking data, int empId)
        {
            return DataAccessLayer.EMR.Cupping.UploadCupping(data, empId);
        }
        public static int DeleteCupping(int lfmId, int lfm_madeby)
        {
            return DataAccessLayer.EMR.Cupping.DeleteCupping(lfmId, lfm_madeby);
        }
        #endregion Cupping Therapy  CRUD Operations
    }
}
