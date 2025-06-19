using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class CheifComplaints
    {

        #region CheifComplaints
        public static List<BusinessEntities.EMR.CheifComplaints> GetAllCheifComplaints(int ? appId, int? compId)
        {
            List<BusinessEntities.EMR.CheifComplaints> sclist = new List<BusinessEntities.EMR.CheifComplaints>();
            DataTable dt = DataAccessLayer.EMR.CheifComplaints.GetAllCheifComplaints(appId, compId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.CheifComplaints
                {
                    compId = Convert.ToInt32(dr["compId"]),
                    comp_appId = Convert.ToInt32(dr["comp_appId"]),
                    complaint = dr["complaint"].ToString(),
                    comp_status = dr["comp_status"].ToString(),
                    cm_title = dr["comp_location"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.CheifComplaints> GetAllPreCheifComplaints(int appId, int patId)
        {
            List<BusinessEntities.EMR.CheifComplaints> sclist = new List<BusinessEntities.EMR.CheifComplaints>();
            DataTable dt = DataAccessLayer.EMR.CheifComplaints.GetAllPreCheifComplaints(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.CheifComplaints
                {
                    compId = Convert.ToInt32(dr["compId"]),
                    comp_appId = Convert.ToInt32(dr["comp_appId"]),
                    complaint = dr["complaint"].ToString(),
                    emp_license = dr["emp_license"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        public static List<GetByName> GetComplaints(string query)
        {
            DataTable dt=DataAccessLayer.EMR.CheifComplaints.GetComplaints(query);
            List<GetByName> data = new List<GetByName>();
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    GetByName _data = new GetByName();
                    _data.id = dr["id"].ToString();
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }
            return data;

        }

        public static int InsertUpdateCheifComplaints(BusinessEntities.EMR.CheifComplaints data)
        {
            return DataAccessLayer.EMR.CheifComplaints.InsertUpdateCheifComplaints(data);
        }

        public static int DeleteCheifComplaints(int compId, int comp_madeby)
        {
            return DataAccessLayer.EMR.CheifComplaints.DeleteCheifComplaints(compId, comp_madeby);
        }

        #endregion CheifComplaints

    }
}
