﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class IntraocularLens
    {
        public static List<BusinessEntities.ConsentForms.IntraocularLens> GetIntraocularLensData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.IntraocularLens.GetIntraocularLensData(appId);
            List<BusinessEntities.ConsentForms.IntraocularLens> list = new List<BusinessEntities.ConsentForms.IntraocularLens>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.IntraocularLens
                {
                    ilpId = Convert.ToInt32(dr["ilpId"]),
                    ilp_appId = Convert.ToInt32(dr["ilp_appId"]),
                    ilp_1 = dr["ilp_1"].ToString(),
                    ilp_2 = dr["ilp_2"].ToString(),
                    ilp_status = dr["ilp_status"].ToString(),
                    ilp_date_modified = Convert.ToDateTime(dr["ilp_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveIntraocularLens(BusinessEntities.ConsentForms.IntraocularLens ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.IntraocularLens.SaveIntraocularLens(ophtha, madeby);
        }
        public static int DeleteIntraocularLens(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.IntraocularLens.DeleteIntraocularLens(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetIntraocularLensPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.IntraocularLens.GetIntraocularLensPreviousHistory(appId);
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
