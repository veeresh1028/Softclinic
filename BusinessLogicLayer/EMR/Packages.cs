using BusinessEntities.EMR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace BusinessLogicLayer.EMR
{
    public class Packages
    {
        

        public static List<BusinessEntities.EMR.TodaySession> GetAllTodaySession(int appId)
        {
            List<BusinessEntities.EMR.TodaySession> sclist = new List<BusinessEntities.EMR.TodaySession>();
            DataTable dt = DataAccessLayer.EMR.Packages.GetAllTodaySession(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.TodaySession
                {
                    rpsId = Convert.ToInt32(dr["rpsId"]),
                    inv_no = dr["inv_no"].ToString(),
                    pt_tr_code = dr["pt_tr_code"].ToString(),
                    pt_tr_name = dr["pt_tr_name"].ToString(),
                    rps_noses = dr["rps_noses"].ToString(),
                    ccdt_status = dr["ccdt_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.TodaySession> GetAllPreTodaySession(int appId,int patId)
        {
            List<BusinessEntities.EMR.TodaySession> sclist = new List<BusinessEntities.EMR.TodaySession>();
            DataTable dt = DataAccessLayer.EMR.Packages.GetAllPreTodaySession(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.TodaySession
                {
                    rpsId = Convert.ToInt32(dr["rpsId"]),
                    inv_no = dr["inv_no"].ToString(),
                    pt_tr_code = dr["pt_tr_code"].ToString(),
                    pt_tr_name = dr["pt_tr_name"].ToString(),
                    rps_noses = dr["rps_noses"].ToString(),
                    ccdt_status = dr["ccdt_status"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),


                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMR.OnFlyPackages> GetAllOnFlyPackages(int appId)
        {
            List<BusinessEntities.EMR.OnFlyPackages> sclist = new List<BusinessEntities.EMR.OnFlyPackages>();
            DataTable dt = DataAccessLayer.EMR.Packages.GetAllOnFlyPackages(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.OnFlyPackages
                {
                    ccdtId = Convert.ToInt32(dr["ccdtId"]),
                    inv_no = dr["inv_no"].ToString(),
                    pt_tr_code = dr["pt_tr_code"].ToString(),
                    pt_tr_name = dr["pt_tr_name"].ToString(),
                    rps_noses = dr["rps_noses"].ToString(),
                    ccdt_status = dr["ccdt_status"].ToString(),
                    used_ses = Convert.ToInt32(dr["used_ses"]),
                    bal_ses = Convert.ToInt32(dr["bal_ses"]),
                    ccdt_noSes = Convert.ToInt32(dr["ccdt_noSes"]),


                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMR.OnFlyPackages> GetPreOnFlyPackages(int appId,int patId)
        {
            List<BusinessEntities.EMR.OnFlyPackages> sclist = new List<BusinessEntities.EMR.OnFlyPackages>();
            DataTable dt = DataAccessLayer.EMR.Packages.GetPreOnFlyPackages(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.OnFlyPackages
                {
                    ccdtId = Convert.ToInt32(dr["ccdtId"]),
                    inv_no = dr["inv_no"].ToString(),
                    pt_tr_code = dr["pt_tr_code"].ToString(),
                    pt_tr_name = dr["pt_tr_name"].ToString(),
                    rps_noses = dr["rps_noses"].ToString(),
                    ccdt_status = dr["ccdt_status"].ToString(),
                    used_ses = Convert.ToInt32(dr["used_ses"]),
                    bal_ses = Convert.ToInt32(dr["bal_ses"]),
                    ccdt_noSes = Convert.ToInt32(dr["ccdt_noSes"]),


                });
            }
            return sclist;
        }
        #region OnFly Packages CRUD Operations
        public static bool AddSession(int rpsId, int appId, int madeby)
        {
            return DataAccessLayer.EMR.Packages.AddSession(rpsId, appId, madeby);
        }

        public static int UpdateStatusRunningPackage(int Id, string status)
        {
            return DataAccessLayer.EMR.Packages.UpdateStatusRunningPackage(Id, status);
        }
        public static int RevertRunningPackage(int Id, string status)
        {
            return DataAccessLayer.EMR.Packages.RevertRunningPackage(Id, status);
        }
        #endregion OnFly Packages CRUD Operations


        #region Patient packages  CRUD Operations

        public static int UpdateStatusPackageOrder(int Id, string status)
        {
            return DataAccessLayer.EMR.Packages.UpdateStatusPackageOrder(Id, status);
        }
        public static bool InsertUpdatePatientPackageOrder(BusinessEntities.EMR.PatientPackage data)
        {
            data.po_package = (data.po_package == 0) ? 0 : data.po_package;
            data.po_services = (data.po_services == "") ? string.Empty : data.po_services;
            data.po_notes = (data.po_notes == "") ? string.Empty : data.po_notes;
            data.po_refno = (data.po_refno == "") ? string.Empty : data.po_refno;
            data.po_date = (string.IsNullOrEmpty(data.po_date.ToString())) ? DateTime.Parse("1900-01-01") : data.po_date;
            data.po_exp_date = (string.IsNullOrEmpty(data.po_exp_date.ToString())) ? DateTime.Parse("2100-01-01") : data.po_exp_date;

            DataTable dt = new DataTable();
            dt.Columns.Add("pps_services", typeof(string));
            dt.Columns.Add("pps_package", typeof(string));
            dt.Columns.Add("pps_qty", typeof(int));

            string[] serviceIds = data.po_services.Split(',');
            if (!string.IsNullOrEmpty(data.po_services))
            {

                foreach (string po_service in serviceIds)
                {
                    int pps_qty = 0;
                    DataRow dr = dt.NewRow();
                    dr["pps_services"] = po_service.Trim();
                    dr["pps_package"] = data.po_package;
                    dr["pps_qty"] = pps_qty;
                    dt.Rows.Add(dr);
                }
            }
            return DataAccessLayer.EMR.Packages.InsertUpdatePatientPackageOrder(data, dt);
        }
        public static bool UpdatePatientPackageOrder(BusinessEntities.EMR.PatientPackage data)
        {
            data.po_package = (data.po_package == 0) ? 0 : data.po_package;
            data.po_services = (data.po_services == "") ? string.Empty : data.po_services;
            data.po_notes = (data.po_notes == "") ? string.Empty : data.po_notes;
            data.po_date = (string.IsNullOrEmpty(data.po_date.ToString())) ? DateTime.Parse("1900-01-01") : data.po_date;
            data.po_exp_date = (string.IsNullOrEmpty(data.po_exp_date.ToString())) ? DateTime.Parse("2100-01-01") : data.po_exp_date;

            DataTable dt = new DataTable();
            dt.Columns.Add("po_services", typeof(string));
            dt.Columns.Add("po_package", typeof(string));

            string[] serviceIds = data.po_services.Split(',');
            if (!string.IsNullOrEmpty(data.po_services))
            {

                foreach (string po_service in serviceIds)
                {
                    DataRow dr = dt.NewRow();
                    dr["po_services"] = po_service.Trim();
                    dr["po_package"] = data.po_package;
                    dt.Rows.Add(dr);
                }
            }
            return DataAccessLayer.EMR.Packages.UpdatePatientPackageOrder(data, dt);
        }
        #endregion
    }


}
