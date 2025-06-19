using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class ToothTreatmentsCategory
    {
        #region Tooth Treatments Category Master (Page Load)
        public static List<BusinessEntities.Masters.ToothTreatmentsCategory> GetToothTreatmentsCategory(int? cctId)
        {
            List<BusinessEntities.Masters.ToothTreatmentsCategory> categories = new List<BusinessEntities.Masters.ToothTreatmentsCategory>();
            
            DataTable dt = DataAccessLayer.Masters.ToothTreatmentsCategory.GetToothTreatmentsCategory(cctId);

            foreach (DataRow dr in dt.Rows)
            {
                categories.Add(new BusinessEntities.Masters.ToothTreatmentsCategory
                {
                    cctId = Convert.ToInt32(dr["cctId"]),
                    cct_code = dr["cct_code"].ToString(),
                    cct_category = dr["cct_category"].ToString(),
                    cct_sub_category = dr["cct_sub_category"].ToString(),
                    cct_status = dr["cct_status"].ToString(),
                    actionvisible = dr["actionvisible"].ToString(),
                    cct_date_created = Convert.ToDateTime(dr["cct_date_created"]),
                    cct_flagdeleted = dr["cct_flagdeleted"].ToString(),
                });
            }
            return categories;
        }
        #endregion

        #region Tooth Treatments Category CRUD Operations
        public static List<BusinessEntities.Masters.ToothTreatmentsCategory> GetToothTreatmentsCategoryByID(int? cctId)
        {
            List<BusinessEntities.Masters.ToothTreatmentsCategory> categories = new List<BusinessEntities.Masters.ToothTreatmentsCategory>();

            DataTable dt = DataAccessLayer.Masters.ToothTreatmentsCategory.GetToothTreatmentsCategory(cctId);

            foreach (DataRow dr in dt.Rows)
            {
                categories.Add(new BusinessEntities.Masters.ToothTreatmentsCategory
                {
                    cctId = Convert.ToInt32(dr["cctId"]),
                    cct_code = dr["cct_code"].ToString(),
                    cct_category = dr["cct_category"].ToString(),
                    cct_sub_category = dr["cct_sub_category"].ToString(),
                    cct_status = dr["cct_status"].ToString(),
                    trcode_name = dr["trcode_name"].ToString(),
                    cct_date_created = Convert.ToDateTime(dr["cct_date_created"]),
                    cct_flagdeleted = dr["cct_flagdeleted"].ToString(),
                });
            }
            return categories;
        }

        public static List<BusinessEntities.Masters.ToothTreatmentsCategory> GetActiveTreatmentCodes(int? cctId)
        {
            List<BusinessEntities.Masters.ToothTreatmentsCategory> ttcategorylist = new List<BusinessEntities.Masters.ToothTreatmentsCategory>();
            DataTable dt = DataAccessLayer.Masters.ToothTreatmentsCategory.GetActiveTreatmentCodes(cctId);

            foreach (DataRow dr in dt.Rows)
            {
                ttcategorylist.Add(new BusinessEntities.Masters.ToothTreatmentsCategory
                {
                    trcode_name = dr["trcode_name"].ToString(),

                });
            }
            return ttcategorylist;
        }

        public static int UpdateToothTreatmentsCategoryStatus(int cctId, string cct_status)
        {
            return DataAccessLayer.Masters.ToothTreatmentsCategory.UpdateToothTreatmentsCategoryStatus(cctId, cct_status);
        }

        public static bool InserUpdatetToothTreatmentsCategory(BusinessEntities.Masters.ToothTreatmentsCategory trcodecategory)
        {
            return DataAccessLayer.Masters.ToothTreatmentsCategory.InserUpdatetToothTreatmentsCategory(trcodecategory);
        }
        #endregion
    }
}
