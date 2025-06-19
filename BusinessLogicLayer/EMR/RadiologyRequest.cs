using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class RadiologyRequest
    {
        #region GastoIntestial (Page Load)

        public static List<BusinessEntities.EMR.RadiologyRequest> GetAllRadiologyRequest(int? appId, int? rdrf_Id)
        {
            List<BusinessEntities.EMR.RadiologyRequest> sclist = new List<BusinessEntities.EMR.RadiologyRequest>();
            DataTable dt = DataAccessLayer.EMR.RadiologyRequest.GetAllRadiologyRequest(appId, rdrf_Id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMR.RadiologyRequest
                    {
                        rdrf_Id = Convert.ToInt32(dr["rdrf_Id"]),
                        rdrf_appId = Convert.ToInt32(dr["rdrf_appId"]),
                        rdrf_finding = dr["rdrf_finding"].ToString(),
                        rdrf_radio = dr["rdrf_radio"].ToString(),
                        rdrf_status = dr["rdrf_status"].ToString(),
                        doctor_name = dr["doctor_name"].ToString(),
                        rdrf_date_created = Convert.ToDateTime(dr["rdrf_date_created"].ToString()),
                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMR.RadiologyRequest a = new BusinessEntities.EMR.RadiologyRequest();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        public static List<BusinessEntities.EMR.RadiologyRequest> GetPrintRadiologyRequest( int? rdrf_Id)
        {
            List<BusinessEntities.EMR.RadiologyRequest> sclist = new List<BusinessEntities.EMR.RadiologyRequest>();
            DataTable dt = DataAccessLayer.EMR.RadiologyRequest.GetPrintRadiologyRequest(rdrf_Id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMR.RadiologyRequest
                    {
                        rdrf_Id = Convert.ToInt32(dr["rdrf_Id"]),
                        rdrf_appId = Convert.ToInt32(dr["rdrf_appId"]),
                        rdrf_finding = dr["rdrf_finding"].ToString(),
                        rdrf_radio = dr["rdrf_radio"].ToString(),
                        rdrf_status = dr["rdrf_status"].ToString(),
                        doctor_name = dr["doctor_name"].ToString(),
                        rdrf_date_created = Convert.ToDateTime(dr["rdrf_date_created"].ToString()),
                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMR.RadiologyRequest a = new BusinessEntities.EMR.RadiologyRequest();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        public static List<BusinessEntities.EMR.RadiologyRequest> GetAllPreRadiologyRequest(int appId, int patId)
        {
            List<BusinessEntities.EMR.RadiologyRequest> sclist = new List<BusinessEntities.EMR.RadiologyRequest>();
            DataTable dt = DataAccessLayer.EMR.RadiologyRequest.GetAllPreRadiologyRequest(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.RadiologyRequest
                {
                    rdrf_Id = Convert.ToInt32(dr["rdrf_Id"]),
                    rdrf_appId = Convert.ToInt32(dr["rdrf_appId"]),
                    rdrf_finding = dr["rdrf_finding"].ToString(),
                    rdrf_radio = dr["rdrf_radio"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion GastoIntestial (Page Load)


        #region GastoIntestial CRUD Operations
        public static bool InsertUpdateRadiologyRequest(BusinessEntities.EMR.RadiologyRequest data)
        {
            data.rdrf_radio = string.IsNullOrEmpty(data.rdrf_radio) ? string.Empty : data.rdrf_radio;
            data.rdrf_finding = string.IsNullOrEmpty(data.rdrf_finding) ? string.Empty : data.rdrf_finding;
            data.rdrf_witness = string.IsNullOrEmpty(data.rdrf_witness) ? string.Empty : data.rdrf_witness;
            
            return DataAccessLayer.EMR.RadiologyRequest.InsertUpdateRadiologyRequest(data);
        }

        public static int DeleteRadiologyRequest(int rdrf_Id, int rdrf_madeby)
        {
            return DataAccessLayer.EMR.RadiologyRequest.DeleteRadiologyRequest(rdrf_Id, rdrf_madeby);
        }

        #endregion GastoIntestial CRUD Operations

    }
}
