using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class TreatmentAttachments
    {
        public static int InsertTreatmentAttachment(BusinessEntities.EMR.TreatmentAttachments data)
        {
            data.ti_bimage_1 = string.IsNullOrEmpty(data.ti_bimage_1) ? string.Empty : data.ti_bimage_1;
            data.ti_bimage_1_icon = string.IsNullOrEmpty(data.ti_bimage_1_icon) ? string.Empty : data.ti_bimage_1_icon;
            data.ti_bimage_2 = string.IsNullOrEmpty(data.ti_bimage_2) ? string.Empty : data.ti_bimage_2;
            data.ti_bimage_2_icon = string.IsNullOrEmpty(data.ti_bimage_2_icon) ? string.Empty : data.ti_bimage_2_icon;
            data.ti_bimage_3 = string.IsNullOrEmpty(data.ti_bimage_3) ? string.Empty : data.ti_bimage_3;
            data.ti_bimage_3_icon = string.IsNullOrEmpty(data.ti_bimage_3_icon) ? string.Empty : data.ti_bimage_3_icon;
            data.ti_bimage_4 = string.IsNullOrEmpty(data.ti_bimage_4) ? string.Empty : data.ti_bimage_4;
            data.ti_bimage_4_icon = string.IsNullOrEmpty(data.ti_bimage_4_icon) ? string.Empty : data.ti_bimage_4_icon;
            data.ti_bimage_5 = string.IsNullOrEmpty(data.ti_bimage_5) ? string.Empty : data.ti_bimage_5;
            data.ti_bimage_5_icon = string.IsNullOrEmpty(data.ti_bimage_5_icon) ? string.Empty : data.ti_bimage_5_icon;
            data.ti_image = string.IsNullOrEmpty(data.ti_image) ? string.Empty : data.ti_image;
            data.ti_image_10 = string.IsNullOrEmpty(data.ti_image_10) ? string.Empty : data.ti_image_10;
            data.ti_image_1_type = string.IsNullOrEmpty(data.ti_image_1_type) ? string.Empty : data.ti_image_1_type;
            data.ti_image_2 = string.IsNullOrEmpty(data.ti_image_2) ? string.Empty : data.ti_image_2;
            data.ti_image_2_type = string.IsNullOrEmpty(data.ti_image_2_type) ? string.Empty : data.ti_image_2_type;
            data.ti_image_3 = string.IsNullOrEmpty(data.ti_image_3) ? string.Empty : data.ti_image_3;
            data.ti_image_3_type = string.IsNullOrEmpty(data.ti_image_3_type) ? string.Empty : data.ti_image_3_type;
            data.ti_image_4 = string.IsNullOrEmpty(data.ti_image_4) ? string.Empty : data.ti_image_4;
            data.ti_image_4_type = string.IsNullOrEmpty(data.ti_image_4_type) ? string.Empty : data.ti_image_4_type;
            data.ti_image_5 = string.IsNullOrEmpty(data.ti_image_5) ? string.Empty : data.ti_image_5;
            data.ti_image_5_type = string.IsNullOrEmpty(data.ti_image_5_type) ? string.Empty : data.ti_image_5_type;
            data.ti_image_6 = string.IsNullOrEmpty(data.ti_image_6) ? string.Empty : data.ti_image_6;
            data.ti_image_7 = string.IsNullOrEmpty(data.ti_image_7) ? string.Empty : data.ti_image_7;
            data.ti_image_8 = string.IsNullOrEmpty(data.ti_image_8) ? string.Empty : data.ti_image_8;
            data.ti_image_9 = string.IsNullOrEmpty(data.ti_image_9) ? string.Empty : data.ti_image_9;
            data.ti_lab_1 = string.IsNullOrEmpty(data.ti_lab_1) ? string.Empty : data.ti_lab_1;
            data.ti_lab_2 = string.IsNullOrEmpty(data.ti_lab_2) ? string.Empty : data.ti_lab_2;
            data.ti_lab_3 = string.IsNullOrEmpty(data.ti_lab_3) ? string.Empty : data.ti_lab_3;
            data.ti_lab_4 = string.IsNullOrEmpty(data.ti_lab_4) ? string.Empty : data.ti_lab_4;
            data.ti_lab_5 = string.IsNullOrEmpty(data.ti_lab_5) ? string.Empty : data.ti_lab_5;
            data.ti_lab_6 = string.IsNullOrEmpty(data.ti_lab_6) ? string.Empty : data.ti_lab_6;
            data.ti_lab_7 = string.IsNullOrEmpty(data.ti_lab_7) ? string.Empty : data.ti_lab_7;
            data.ti_lab_8 = string.IsNullOrEmpty(data.ti_lab_8) ? string.Empty : data.ti_lab_8;
            data.ti_lab_9 = string.IsNullOrEmpty(data.ti_lab_9) ? string.Empty : data.ti_lab_9;
            data.ti_lab_10 = string.IsNullOrEmpty(data.ti_lab_10) ? string.Empty : data.ti_lab_10;
            data.ti_lab_11 = string.IsNullOrEmpty(data.ti_lab_11) ? string.Empty : data.ti_lab_11;
            data.ti_lab_12 = string.IsNullOrEmpty(data.ti_lab_12) ? string.Empty : data.ti_lab_12;
            data.ti_lab_13 = string.IsNullOrEmpty(data.ti_lab_13) ? string.Empty : data.ti_lab_13;
            data.ti_lab_14 = string.IsNullOrEmpty(data.ti_lab_14) ? string.Empty : data.ti_lab_14;
            data.ti_lab_15 = string.IsNullOrEmpty(data.ti_lab_15) ? string.Empty : data.ti_lab_15;
            data.ti_lab_16 = string.IsNullOrEmpty(data.ti_lab_16) ? string.Empty : data.ti_lab_16;
            data.ti_lab_17 = string.IsNullOrEmpty(data.ti_lab_17) ? string.Empty : data.ti_lab_17;
            data.ti_lab_18 = string.IsNullOrEmpty(data.ti_lab_18) ? string.Empty : data.ti_lab_18;
            data.ti_loinc_1 = string.IsNullOrEmpty(data.ti_loinc_1) ? string.Empty : data.ti_loinc_1;
            data.ti_loinc_2 = string.IsNullOrEmpty(data.ti_loinc_2) ? string.Empty : data.ti_loinc_2;
            data.ti_loinc_3 = string.IsNullOrEmpty(data.ti_loinc_3) ? string.Empty : data.ti_loinc_3;
            data.ti_loinc_4 = string.IsNullOrEmpty(data.ti_loinc_4) ? string.Empty : data.ti_loinc_4;
            data.ti_loinc_5 = string.IsNullOrEmpty(data.ti_loinc_5) ? string.Empty : data.ti_loinc_5;
            data.ti_loinc_6 = string.IsNullOrEmpty(data.ti_loinc_6) ? string.Empty : data.ti_loinc_6;
            data.ti_loinc_7 = string.IsNullOrEmpty(data.ti_loinc_7) ? string.Empty : data.ti_loinc_7;
            data.ti_loinc_8 = string.IsNullOrEmpty(data.ti_loinc_8) ? string.Empty : data.ti_loinc_8;
            data.ti_loinc_9 = string.IsNullOrEmpty(data.ti_loinc_9) ? string.Empty : data.ti_loinc_9;
            data.ti_loinc_10 = string.IsNullOrEmpty(data.ti_loinc_10) ? string.Empty : data.ti_loinc_10;
            data.ti_loinc_11 = string.IsNullOrEmpty(data.ti_loinc_11) ? string.Empty : data.ti_loinc_11;
            data.ti_loinc_12 = string.IsNullOrEmpty(data.ti_loinc_12) ? string.Empty : data.ti_loinc_12;
            data.ti_loinc_13 = string.IsNullOrEmpty(data.ti_loinc_13) ? string.Empty : data.ti_loinc_13;
            data.ti_loinc_14 = string.IsNullOrEmpty(data.ti_loinc_14) ? string.Empty : data.ti_loinc_14;
            data.ti_loinc_15 = string.IsNullOrEmpty(data.ti_loinc_15) ? string.Empty : data.ti_loinc_15;
            data.ti_img_refno1 = string.IsNullOrEmpty(data.ti_img_refno1) ? string.Empty : data.ti_img_refno1;
            data.ti_img_refno2 = string.IsNullOrEmpty(data.ti_img_refno2) ? string.Empty : data.ti_img_refno2;
            data.ti_img_refno3 = string.IsNullOrEmpty(data.ti_img_refno3) ? string.Empty : data.ti_img_refno3;
            data.ti_img_refno4 = string.IsNullOrEmpty(data.ti_img_refno4) ? string.Empty : data.ti_img_refno4;
            data.ti_img_refno5 = string.IsNullOrEmpty(data.ti_img_refno5) ? string.Empty : data.ti_img_refno5;

            return DataAccessLayer.EMR.TreatmentAttachments.InsertTreatmentAttachment(data);
        }

        public static List<BusinessEntities.EMR.TreatmentAttachments> GetTreatmentAttachments(int ptId)
        {
            try
            {
                List<BusinessEntities.EMR.TreatmentAttachments> attachments = new List<BusinessEntities.EMR.TreatmentAttachments>();

                DataTable dt = DataAccessLayer.EMR.TreatmentAttachments.GetTreatmentAttachments(ptId);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        attachments.Add(new BusinessEntities.EMR.TreatmentAttachments
                        {
                            tiId = Convert.ToInt32(dr["tiId"]),
                            ti_appId = Convert.ToInt32(dr["ti_appId"].ToString()),
                            ti_image = dr["ti_image"].ToString(),
                            ti_image_2 = dr["ti_image_2"].ToString(),
                            ti_image_3 = dr["ti_image_3"].ToString(),
                            ti_image_4 = dr["ti_image_4"].ToString(),
                            ti_image_5 = dr["ti_image_5"].ToString(),
                            ti_image_6 = dr["ti_image_6"].ToString(),
                            ti_image_7 = dr["ti_image_7"].ToString(),
                            ti_image_8 = dr["ti_image_8"].ToString(),
                            ti_image_9 = dr["ti_image_9"].ToString(),
                            ti_image_10 = dr["ti_image_10"].ToString(),
                            ti_lab_1 = dr["ti_lab_1"].ToString(),
                            ti_lab_2 = dr["ti_lab_2"].ToString(),
                            ti_lab_3 = dr["ti_lab_3"].ToString(),
                            ti_lab_4 = dr["ti_lab_4"].ToString(),
                            ti_lab_5 = dr["ti_lab_5"].ToString(),
                            ti_lab_6 = dr["ti_lab_6"].ToString(),
                            ti_lab_7 = dr["ti_lab_7"].ToString(),
                            ti_lab_8 = dr["ti_lab_8"].ToString(),
                            ti_lab_9 = dr["ti_lab_9"].ToString(),
                            ti_loinc_1 = dr["ti_loinc_1"].ToString(),
                            ti_loinc_2 = dr["ti_loinc_2"].ToString(),
                            ti_loinc_3 = dr["ti_loinc_3"].ToString(),
                            ti_loinc_4 = dr["ti_loinc_4"].ToString(),
                            ti_loinc_5 = dr["ti_loinc_5"].ToString(),
                            ti_loinc_6 = dr["ti_loinc_6"].ToString(),
                            ti_loinc_7 = dr["ti_loinc_7"].ToString(),
                            ti_loinc_8 = dr["ti_loinc_8"].ToString(),
                            ti_loinc_9 = dr["ti_loinc_9"].ToString(),
                            ti_loinc_10 = dr["ti_loinc_10"].ToString(),
                            ti_loinc_11 = dr["ti_loinc_11"].ToString(),
                            ti_loinc_12 = dr["ti_loinc_12"].ToString(),
                            ti_loinc_13 = dr["ti_loinc_13"].ToString(),
                            ti_loinc_14 = dr["ti_loinc_14"].ToString(),
                            ti_loinc_15 = dr["ti_loinc_15"].ToString(),
                            ti_bimage_1 = dr["ti_bimage_1"].ToString(),
                            ti_bimage_2 = dr["ti_bimage_2"].ToString(),
                            ti_bimage_3 = dr["ti_bimage_3"].ToString(),
                            ti_bimage_4 = dr["ti_bimage_4"].ToString(),
                            ti_bimage_5 = dr["ti_bimage_5"].ToString(),
                            ti_bimage_1_icon = dr["ti_bimage_1_icon"].ToString(),
                            ti_bimage_2_icon = dr["ti_bimage_2_icon"].ToString(),
                            ti_bimage_3_icon = dr["ti_bimage_3_icon"].ToString(),
                            ti_bimage_4_icon = dr["ti_bimage_4_icon"].ToString(),
                            ti_bimage_5_icon = dr["ti_bimage_5_icon"].ToString(),
                            ti_lab_10 = dr["ti_lab_10"].ToString(),
                            ti_lab_11 = dr["ti_lab_11"].ToString(),
                            ti_lab_12 = dr["ti_lab_12"].ToString(),
                            ti_lab_13 = dr["ti_lab_13"].ToString(),
                            ti_lab_14 = dr["ti_lab_14"].ToString(),
                            ti_lab_15 = dr["ti_lab_15"].ToString(),
                            ti_lab_16 = dr["ti_lab_16"].ToString(),
                            ti_lab_17 = dr["ti_lab_17"].ToString(),
                            ti_image_1_type = dr["ti_image_1_type"].ToString(),
                            ti_image_2_type = dr["ti_image_2_type"].ToString(),
                            ti_image_3_type = dr["ti_image_3_type"].ToString(),
                            ti_image_4_type = dr["ti_image_4_type"].ToString(),
                            ti_image_5_type = dr["ti_image_5_type"].ToString()
                        });
                    }
                }

                return attachments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteTreatmentAttachment(int tiId, int ti_modifyby)
        {
            return DataAccessLayer.EMR.TreatmentAttachments.DeleteTreatmentAttachment(tiId, ti_modifyby);
        }

        public static List<CommonDDLFORMS> GetLOINCForDropdown(string query)
        {
            DataTable dt = DataAccessLayer.EMR.PatientTreatments.GetLOINCForDropdown(query);

            List<CommonDDLFORMS> data = new List<CommonDDLFORMS>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CommonDDLFORMS _data = new CommonDDLFORMS();
                    _data.id = row["clc_code"].ToString();
                    _data.text = row["clc_code"].ToString() + " | " + row["clc_name"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }
    }
}