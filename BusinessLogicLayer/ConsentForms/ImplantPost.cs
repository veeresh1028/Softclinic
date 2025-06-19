using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConcentForms
{
    public class ImplantPost
    {
        public static List<BusinessEntities.ConcentForms.ImplantPost> GetImplantPostData(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.ImplantPost.GetImplantPostData(appId);
            List<BusinessEntities.ConcentForms.ImplantPost> list = new List<BusinessEntities.ConcentForms.ImplantPost>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ImplantPost
                {
                    ippId = Convert.ToInt32(dr["ippId"]),
                    ipp_appId = Convert.ToInt32(dr["ipp_appId"]),
                    ipp_status = dr["ipp_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveImplantPost(BusinessEntities.ConcentForms.ImplantPost tooth, int madeby)
        {
            return DataAccessLayer.ConcentForms.ImplantPost.SaveImplantPost(tooth, madeby);
        }
        public static int DeleteImplantPost(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.ImplantPost.DeleteImplantPost(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetImplantPostPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.ImplantPost.GetImplantPostPreviousHistory(appId);
            List<BusinessEntities.ConcentForms.ConcentPreviousHistory> list = new List<BusinessEntities.ConcentForms.ConcentPreviousHistory>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ConcentPreviousHistory
                {
                    formId = Convert.ToInt32(dr["formId"]),
                    appId = Convert.ToInt32(dr["appId"]),
                    emp_license = dr["emp_license"].ToString(),
                    emp_name = dr["emp_name"].ToString() + " " + dr["emp_lname"].ToString(),
                    emp_dept_name = dr["emp_dept_name"].ToString(),
                    app_fdate = DateTime.Parse(dr["app_fdate"].ToString()).ToString("dd-MMM-yyyy") + " " + dr["app_doc_ftime"].ToString() + " - " + dr["app_doc_ttime"].ToString()
                });
            }
            return list;
        }

    }
}
