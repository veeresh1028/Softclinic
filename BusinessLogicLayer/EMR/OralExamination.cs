using BusinessEntities.Appointment;
using BusinessEntities.EMR;
using BusinessEntities.Invoice;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BusinessLogicLayer.EMR
{
    public class OralExamination
    {
        #region  Extra Oral Examination (Page Load)
        public static List<BusinessEntities.EMR.ExtraOralExam> GetAllExtraOralExam(int? appId, int? ceoId)
        {
            List<BusinessEntities.EMR.ExtraOralExam> sclist = new List<BusinessEntities.EMR.ExtraOralExam>();
            DataTable dt = DataAccessLayer.EMR.OralExamination.GetAllExtraOralExam(appId, ceoId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.ExtraOralExam
                {
                    ceoId = Convert.ToInt32(dr["ceoId"]),
                    ceo_appId = Convert.ToInt32(dr["ceo_appId"]),
                    ceo_1 = dr["ceo_1"].ToString(),
                    ceo_2 = dr["ceo_2"].ToString(),
                    ceo_3 = dr["ceo_3"].ToString(),
                    ceo_4 = dr["ceo_4"].ToString(),
                    ceo_5 = dr["ceo_5"].ToString(),
                    ceo_6 = dr["ceo_6"].ToString(),
                    ceo_7 = dr["ceo_7"].ToString(),
                    ceo_8 = dr["ceo_8"].ToString(),
                    ceo_9 = dr["ceo_9"].ToString(),
                    ceo_10 = dr["ceo_10"].ToString(),
                    ceo_11 = dr["ceo_11"].ToString(),
                    ceo_12 = dr["ceo_12"].ToString(),
                    ceo_status = dr["ceo_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.ExtraOralExam> GetAllPreExtraOralExam(int appId, int patId)
        {
            List<BusinessEntities.EMR.ExtraOralExam> sclist = new List<BusinessEntities.EMR.ExtraOralExam>();
            DataTable dt = DataAccessLayer.EMR.OralExamination.GetAllPreExtraOralExam(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.ExtraOralExam
                {
                    ceoId = Convert.ToInt32(dr["ceoId"]),
                    ceo_appId = Convert.ToInt32(dr["ceo_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),

                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Extra Oral Examination (Page Load)
        #region  Extra Oral Examination CRUD Operations
        public static bool InsertUpdateExtraOralExam(BusinessEntities.EMR.ExtraOralExam data)
        {
            data.ceo_1 = string.IsNullOrEmpty(data.ceo_1) ? string.Empty : data.ceo_1;
            data.ceo_2 = string.IsNullOrEmpty(data.ceo_2) ? string.Empty : data.ceo_2;
            data.ceo_3 = string.IsNullOrEmpty(data.ceo_3) ? string.Empty : data.ceo_3;
            data.ceo_4 = string.IsNullOrEmpty(data.ceo_4) ? string.Empty : data.ceo_4;
            data.ceo_5 = string.IsNullOrEmpty(data.ceo_5) ? string.Empty : data.ceo_5;
            data.ceo_6 = string.IsNullOrEmpty(data.ceo_6) ? string.Empty : data.ceo_6;
            data.ceo_7 = string.IsNullOrEmpty(data.ceo_7) ? string.Empty : data.ceo_7;
            data.ceo_8 = string.IsNullOrEmpty(data.ceo_8) ? string.Empty : data.ceo_8;
            data.ceo_9 = string.IsNullOrEmpty(data.ceo_9) ? string.Empty : data.ceo_9;
            data.ceo_10 = string.IsNullOrEmpty(data.ceo_10) ? string.Empty : data.ceo_10;
            data.ceo_11 = string.IsNullOrEmpty(data.ceo_11) ? string.Empty : data.ceo_11;
            data.ceo_12 = string.IsNullOrEmpty(data.ceo_12) ? string.Empty : data.ceo_12;
            

            return DataAccessLayer.EMR.OralExamination.InsertUpdateExtraOralExam(data);
        }

        public static int DeleteExtraOralExam(int ceoId, int ceo_madeby)
        {
            return DataAccessLayer.EMR.OralExamination.DeleteExtraOralExam(ceoId, ceo_madeby);
        }
        #endregion  Extra Oral Examination CRUD Operations

        #region  IntraOral SoftTissue (Page Load)
        public static List<BusinessEntities.EMR.IntraOralSoftTissue> GetAllIntraOralSoftTissue(int? appId, int? cstId)
        {
            List<BusinessEntities.EMR.IntraOralSoftTissue> sclist = new List<BusinessEntities.EMR.IntraOralSoftTissue>();
            DataTable dt = DataAccessLayer.EMR.OralExamination.GetAllIntraOralSoftTissue(appId, cstId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.IntraOralSoftTissue
                {
                    cstId = Convert.ToInt32(dr["cstId"]),
                    cst_appId = Convert.ToInt32(dr["cst_appId"]),
                    cst_1 = dr["cst_1"].ToString(),
                    cst_2 = dr["cst_2"].ToString(),
                    cst_3 = dr["cst_3"].ToString(),
                    cst_4 = dr["cst_4"].ToString(),
                    cst_5 = dr["cst_5"].ToString(),
                    cst_6 = dr["cst_6"].ToString(),
                    cst_7 = dr["cst_7"].ToString(),
                    cst_8 = dr["cst_8"].ToString(),
                    cst_9 = dr["cst_9"].ToString(),
                    cst_10 = dr["cst_10"].ToString(),
                    cst_11 = dr["cst_11"].ToString(),
                    cst_12 = dr["cst_12"].ToString(),
                    cst_13 = dr["cst_13"].ToString(),
                    cst_14 = dr["cst_14"].ToString(),
                    cst_15 = dr["cst_15"].ToString(),
                    cst_16 = dr["cst_16"].ToString(),
                    cst_17 = dr["cst_17"].ToString(),
                    cst_18 = dr["cst_18"].ToString(),
                    cst_19 = dr["cst_19"].ToString(),
                    cst_20 = dr["cst_20"].ToString(),
                    cst_21 = dr["cst_21"].ToString(),
                    cst_22 = dr["cst_22"].ToString(),
                    cst_23 = dr["cst_23"].ToString(),
                    cst_24 = dr["cst_24"].ToString(),
                    cst_25 = dr["cst_25"].ToString(),
                    cst_26 = dr["cst_26"].ToString(),
                    cst_27 = dr["cst_27"].ToString(),
                    cst_28 = dr["cst_28"].ToString(),
                    cst_29 = dr["cst_29"].ToString(),
                    cst_30 = dr["cst_30"].ToString(),
                    cst_31 = dr["cst_31"].ToString(),
                    cst_32 = dr["cst_32"].ToString(),
                    cst_status = dr["cst_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.IntraOralSoftTissue> GetAllPreIntraOralSoftTissue(int appId, int patId)
        {
            List<BusinessEntities.EMR.IntraOralSoftTissue> sclist = new List<BusinessEntities.EMR.IntraOralSoftTissue>();
            DataTable dt = DataAccessLayer.EMR.OralExamination.GetAllPreIntraOralSoftTissue(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.IntraOralSoftTissue
                {
                    cstId = Convert.ToInt32(dr["cstId"]),
                    cst_appId = Convert.ToInt32(dr["cst_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),

                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  IntraOral SoftTissue (Page Load)

        #region  IntraOral SoftTissue CRUD Operations
        public static bool InsertUpdateIntraOralSoftTissue(BusinessEntities.EMR.IntraOralSoftTissue data)
        {
            data.cst_1 = string.IsNullOrEmpty(data.cst_1) ? string.Empty : data.cst_1;
            data.cst_2 = string.IsNullOrEmpty(data.cst_2) ? string.Empty : data.cst_2;
            data.cst_3 = string.IsNullOrEmpty(data.cst_3) ? string.Empty : data.cst_3;
            data.cst_4 = string.IsNullOrEmpty(data.cst_4) ? string.Empty : data.cst_4;
            data.cst_5 = string.IsNullOrEmpty(data.cst_5) ? string.Empty : data.cst_5;
            data.cst_6 = string.IsNullOrEmpty(data.cst_6) ? string.Empty : data.cst_6;
            data.cst_7 = string.IsNullOrEmpty(data.cst_7) ? string.Empty : data.cst_7;
            data.cst_8 = string.IsNullOrEmpty(data.cst_8) ? string.Empty : data.cst_8;
            data.cst_9 = string.IsNullOrEmpty(data.cst_9) ? string.Empty : data.cst_9;
            data.cst_10 = string.IsNullOrEmpty(data.cst_10) ? string.Empty : data.cst_10;
            data.cst_11 = string.IsNullOrEmpty(data.cst_11) ? string.Empty : data.cst_11;
            data.cst_12 = string.IsNullOrEmpty(data.cst_12) ? string.Empty : data.cst_12;
            data.cst_13 = string.IsNullOrEmpty(data.cst_13) ? string.Empty : data.cst_13;
            data.cst_14 = string.IsNullOrEmpty(data.cst_14) ? string.Empty : data.cst_14;
            data.cst_15 = string.IsNullOrEmpty(data.cst_15) ? string.Empty : data.cst_15;
            data.cst_16 = string.IsNullOrEmpty(data.cst_16) ? string.Empty : data.cst_16;
            data.cst_17 = string.IsNullOrEmpty(data.cst_17) ? string.Empty : data.cst_17;
            data.cst_18 = string.IsNullOrEmpty(data.cst_18) ? string.Empty : data.cst_18;
            data.cst_19 = string.IsNullOrEmpty(data.cst_19) ? string.Empty : data.cst_19;
            data.cst_20 = string.IsNullOrEmpty(data.cst_20) ? string.Empty : data.cst_20;
            data.cst_21 = string.IsNullOrEmpty(data.cst_21) ? string.Empty : data.cst_21;
            data.cst_22 = string.IsNullOrEmpty(data.cst_22) ? string.Empty : data.cst_22;
            data.cst_23 = string.IsNullOrEmpty(data.cst_23) ? string.Empty : data.cst_23;
            data.cst_24 = string.IsNullOrEmpty(data.cst_24) ? string.Empty : data.cst_24;
            data.cst_25 = string.IsNullOrEmpty(data.cst_25) ? string.Empty : data.cst_25;
            data.cst_26 = string.IsNullOrEmpty(data.cst_26) ? string.Empty : data.cst_26;
            data.cst_27 = string.IsNullOrEmpty(data.cst_27) ? string.Empty : data.cst_27;
            data.cst_28 = string.IsNullOrEmpty(data.cst_28) ? string.Empty : data.cst_28;
            data.cst_29 = string.IsNullOrEmpty(data.cst_29) ? string.Empty : data.cst_29;
            data.cst_30 = string.IsNullOrEmpty(data.cst_30) ? string.Empty : data.cst_30;
            data.cst_31 = string.IsNullOrEmpty(data.cst_31) ? string.Empty : data.cst_31;
            data.cst_32 = string.IsNullOrEmpty(data.cst_32) ? string.Empty : data.cst_32;

            return DataAccessLayer.EMR.OralExamination.InsertUpdateIntraOralSoftTissue(data);
        }

        public static int DeleteIntraOralSoftTissue(int cstId, int cst_madeby)
        {
            return DataAccessLayer.EMR.OralExamination.DeleteIntraOralSoftTissue(cstId, cst_madeby);
        }
        #endregion  IntraOral SoftTissue CRUD Operations

        #region  IntraOral HardTissue (Page Load)
        public static List<BusinessEntities.EMR.IntraOralHardTissue> GetAllIntraOralHardTissue(int? appId, int? chtId)
        {
            List<BusinessEntities.EMR.IntraOralHardTissue> sclist = new List<BusinessEntities.EMR.IntraOralHardTissue>();
            DataTable dt = DataAccessLayer.EMR.OralExamination.GetAllIntraOralHardTissue(appId, chtId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.IntraOralHardTissue
                {
                    chtId = Convert.ToInt32(dr["chtId"]),
                    cht_appId = Convert.ToInt32(dr["cht_appId"]),
                    cht_1 = dr["cht_1"].ToString(),
                    cht_2 = dr["cht_2"].ToString(),
                    cht_3 = dr["cht_3"].ToString(),
                    cht_4 = dr["cht_4"].ToString(),
                    cht_5 = dr["cht_5"].ToString(),
                    cht_6 = dr["cht_6"].ToString(),
                    cht_7 = dr["cht_7"].ToString(),
                    cht_8 = dr["cht_8"].ToString(),
                    cht_9 = dr["cht_9"].ToString(),
                    cht_10 = dr["cht_10"].ToString(),
                    cht_11 = dr["cht_11"].ToString(),
                    cht_12 = dr["cht_12"].ToString(),
                    cht_13 = dr["cht_13"].ToString(),
                    cht_14 = dr["cht_14"].ToString(),
                    cht_15 = dr["cht_15"].ToString(),
                    cht_16 = dr["cht_16"].ToString(),
                    cht_17 = dr["cht_17"].ToString(),
                    cht_18 = dr["cht_18"].ToString(),
                    cht_status = dr["cht_status"].ToString(),


                });
            }
            return sclist;
        }
        public static BusinessEntities.EMR.HardTissue GetIntraOralHardTissue(int? appId, int? chtId)
        {
                DataTable dt = DataAccessLayer.EMR.OralExamination.GetAllIntraOralHardTissue(appId, chtId);
           
            
            List<BusinessEntities.EMR.HardTissue_tooth> list = new List<BusinessEntities.EMR.HardTissue_tooth>();
            BusinessEntities.EMR.HardTissue hard = new BusinessEntities.EMR.HardTissue();
            IntraOralHardTissue info = new IntraOralHardTissue();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                info.chtId = Convert.ToInt32(dr["chtId"]);
                info.cht_appId = Convert.ToInt32(dr["cht_appId"]);
                info.cht_1 = dr["cht_1"].ToString();
                info.cht_2 = dr["cht_2"].ToString();
                info.cht_3 = dr["cht_3"].ToString();
                info.cht_4 = dr["cht_4"].ToString();
                info.cht_5 = dr["cht_5"].ToString();
                info.cht_6 = dr["cht_6"].ToString();
                info.cht_7 = dr["cht_7"].ToString();
                info.cht_8 = dr["cht_8"].ToString();
                info.cht_9 = dr["cht_9"].ToString();
                info.cht_10 = dr["cht_10"].ToString();
                info.cht_11 = dr["cht_11"].ToString();
                info.cht_12 = dr["cht_12"].ToString();
                info.cht_13 = dr["cht_13"].ToString();
                info.cht_14 = dr["cht_14"].ToString();
                info.cht_15 = dr["cht_15"].ToString();
                info.cht_16 = dr["cht_16"].ToString();
                info.cht_17 = dr["cht_17"].ToString();
                info.cht_18 = dr["cht_18"].ToString();
                info.cht_status = dr["cht_status"].ToString();
            }
            if (info.cht_appId > 0)
            {
                DataTable dt1 = DataAccessLayer.EMR.OralExamination.GetHardTissueTooth(info.chtId, 0);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    
                    
                    HardTissue_tooth tooth = new HardTissue_tooth();
                    tooth.chtdId = Convert.ToInt32(dr1["chtdId"]);
                    tooth.chtd_appId = Convert.ToInt32(dr1["chtd_appId"]);
                    tooth.chtd_chtId = Convert.ToInt32(dr1["chtd_chtId"]);
                    tooth.chtd_1 = dr1["chtd_1"].ToString();
                    tooth.chtd_2 = dr1["chtd_2"].ToString();
                    tooth.chtd_3 = dr1["chtd_3"].ToString();
                    tooth.chtd_status = dr1["chtd_status"].ToString();
                    list.Add(tooth);
                }
            }

            hard.hard_tissue_info = info;
            hard.HardTissue_tooth_items = list;

            return hard;
           
        }

        public static List<BusinessEntities.EMR.IntraOralHardTissue> GetAllPreIntraOralHardTissue(int appId, int patId)
        {
            List<BusinessEntities.EMR.IntraOralHardTissue> sclist = new List<BusinessEntities.EMR.IntraOralHardTissue>();
            DataTable dt = DataAccessLayer.EMR.OralExamination.GetAllPreIntraOralHardTissue(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.IntraOralHardTissue
                {
                    chtId = Convert.ToInt32(dr["chtId"]),
                    cht_appId = Convert.ToInt32(dr["cht_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),

                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        public static List<CommonDDL> GetToothSurface(string query)
        {
            DataTable dt = DataAccessLayer.EMR.OralExamination.GetToothSurface(query);
            List<CommonDDL> data = new List<CommonDDL>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["text"].ToString() ;
                    data.Add(_data);
                }
            }
            return data;

        }
        #endregion  IntraOral HardTissue (Page Load)

        #region  IntraOral HardTissue CRUD Operations
        public static int InsertUpdateIntraOralHardTissue(BusinessEntities.EMR.HardTissue data,int cht_madeby)
        {

            return DataAccessLayer.EMR.HardTissue.InsertUpdateIntraOralHardTissue(data, cht_madeby);
        }

        public static int DeleteIntraOralHardTissue(int chtId, int cht_madeby)
        {
            return DataAccessLayer.EMR.OralExamination.DeleteIntraOralHardTissue(chtId, cht_madeby);
        }

        public static int DeleteHardTissueTooth(List<int> chtdIds, int madeby)
        {
            int val = 0;
            foreach (int chtdId in chtdIds)
            {
                val += DataAccessLayer.EMR.OralExamination.DeleteHardTissueTooth(chtdId, madeby);
            }
            return val;
        }
        #endregion  IntraOral HardTissue CRUD Operations

    }
}
