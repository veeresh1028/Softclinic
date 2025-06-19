using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EMR
{
    public class TreatmentAttachments
    {
        public static DataTable GetTreatmentAttachments(int ptId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Treatment_Attachments_Select_All_Info");

                if (ptId > 0)
                {
                    db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertTreatmentAttachment(BusinessEntities.EMR.TreatmentAttachments data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Treatment_Attachment_Insert");

                db.AddInParameter(dbCommand, "ti_ptId", DbType.String, data.ti_ptId);
                db.AddInParameter(dbCommand, "ti_appId", DbType.String, data.ti_appId);
                db.AddInParameter(dbCommand, "ti_image", DbType.String, data.ti_image);
                db.AddInParameter(dbCommand, "ti_image_2", DbType.String, data.ti_image_2);
                db.AddInParameter(dbCommand, "ti_image_3", DbType.String, data.ti_image_3);
                db.AddInParameter(dbCommand, "ti_image_4", DbType.String, data.ti_image_4);
                db.AddInParameter(dbCommand, "ti_image_5", DbType.String, data.ti_image_5);
                db.AddInParameter(dbCommand, "ti_image_6", DbType.String, data.ti_image_6);
                db.AddInParameter(dbCommand, "ti_image_7", DbType.String, data.ti_image_7);
                db.AddInParameter(dbCommand, "ti_image_8", DbType.String, data.ti_image_8);
                db.AddInParameter(dbCommand, "ti_image_9", DbType.String, data.ti_image_9);
                db.AddInParameter(dbCommand, "ti_image_10", DbType.String, data.ti_image_10);
                db.AddInParameter(dbCommand, "ti_image_1_type", DbType.String, data.ti_image_1_type);
                db.AddInParameter(dbCommand, "ti_image_2_type", DbType.String, data.ti_image_2_type);
                db.AddInParameter(dbCommand, "ti_image_3_type", DbType.String, data.ti_image_3_type);
                db.AddInParameter(dbCommand, "ti_image_4_type", DbType.String, data.ti_image_4_type);
                db.AddInParameter(dbCommand, "ti_image_5_type", DbType.String, data.ti_image_5_type);
                db.AddInParameter(dbCommand, "ti_lab_1", DbType.String, data.ti_lab_1);
                db.AddInParameter(dbCommand, "ti_lab_2", DbType.String, data.ti_lab_2);
                db.AddInParameter(dbCommand, "ti_lab_3", DbType.String, data.ti_lab_3);
                db.AddInParameter(dbCommand, "ti_lab_4", DbType.String, data.ti_lab_4);
                db.AddInParameter(dbCommand, "ti_lab_5", DbType.String, data.ti_lab_5);
                db.AddInParameter(dbCommand, "ti_lab_6", DbType.String, data.ti_lab_6);
                db.AddInParameter(dbCommand, "ti_lab_7", DbType.String, data.ti_lab_7);
                db.AddInParameter(dbCommand, "ti_lab_8", DbType.String, data.ti_lab_8);
                db.AddInParameter(dbCommand, "ti_lab_9", DbType.String, data.ti_lab_9);
                db.AddInParameter(dbCommand, "ti_loinc_1", DbType.String, data.ti_loinc_1);
                db.AddInParameter(dbCommand, "ti_loinc_2", DbType.String, data.ti_loinc_2);
                db.AddInParameter(dbCommand, "ti_loinc_3", DbType.String, data.ti_loinc_3);
                db.AddInParameter(dbCommand, "ti_loinc_4", DbType.String, data.ti_loinc_4);
                db.AddInParameter(dbCommand, "ti_loinc_5", DbType.String, data.ti_loinc_5);
                db.AddInParameter(dbCommand, "ti_loinc_6", DbType.String, data.ti_loinc_6);
                db.AddInParameter(dbCommand, "ti_loinc_7", DbType.String, data.ti_loinc_7);
                db.AddInParameter(dbCommand, "ti_loinc_8", DbType.String, data.ti_loinc_8);
                db.AddInParameter(dbCommand, "ti_loinc_9", DbType.String, data.ti_loinc_9);
                db.AddInParameter(dbCommand, "ti_loinc_10", DbType.String, data.ti_loinc_10);
                db.AddInParameter(dbCommand, "ti_loinc_11", DbType.String, data.ti_loinc_11);
                db.AddInParameter(dbCommand, "ti_loinc_12", DbType.String, data.ti_loinc_12);
                db.AddInParameter(dbCommand, "ti_loinc_13", DbType.String, data.ti_loinc_13);
                db.AddInParameter(dbCommand, "ti_loinc_14", DbType.String, data.ti_loinc_14);
                db.AddInParameter(dbCommand, "ti_loinc_15", DbType.String, data.ti_loinc_15);
                db.AddInParameter(dbCommand, "ti_bimage_1", DbType.String, data.ti_bimage_1);
                db.AddInParameter(dbCommand, "ti_bimage_2", DbType.String, data.ti_bimage_2);
                db.AddInParameter(dbCommand, "ti_bimage_3", DbType.String, data.ti_bimage_3);
                db.AddInParameter(dbCommand, "ti_bimage_4", DbType.String, data.ti_bimage_4);
                db.AddInParameter(dbCommand, "ti_bimage_5", DbType.String, data.ti_bimage_5);
                db.AddInParameter(dbCommand, "ti_bimage_1_icon", DbType.String, data.ti_bimage_1_icon);
                db.AddInParameter(dbCommand, "ti_bimage_2_icon", DbType.String, data.ti_bimage_2_icon);
                db.AddInParameter(dbCommand, "ti_bimage_3_icon", DbType.String, data.ti_bimage_3_icon);
                db.AddInParameter(dbCommand, "ti_bimage_4_icon", DbType.String, data.ti_bimage_4_icon);
                db.AddInParameter(dbCommand, "ti_bimage_5_icon", DbType.String, data.ti_bimage_5_icon);
                db.AddInParameter(dbCommand, "ti_lab_10", DbType.String, data.ti_lab_10);
                db.AddInParameter(dbCommand, "ti_lab_11", DbType.String, data.ti_lab_11);
                db.AddInParameter(dbCommand, "ti_lab_12", DbType.String, data.ti_lab_12);
                db.AddInParameter(dbCommand, "ti_lab_13", DbType.String, data.ti_lab_13);
                db.AddInParameter(dbCommand, "ti_lab_14", DbType.String, data.ti_lab_14);
                db.AddInParameter(dbCommand, "ti_lab_15", DbType.String, data.ti_lab_15);
                db.AddInParameter(dbCommand, "ti_lab_16", DbType.String, data.ti_lab_16);
                db.AddInParameter(dbCommand, "ti_lab_17", DbType.String, data.ti_lab_17);
                db.AddInParameter(dbCommand, "ti_madeby", DbType.Int32, data.ti_madeby);
                db.AddInParameter(dbCommand, "ti_img_refno1", DbType.String, data.ti_img_refno1);
                db.AddInParameter(dbCommand, "ti_img_refno2", DbType.String, data.ti_img_refno2);
                db.AddInParameter(dbCommand, "ti_img_refno3", DbType.String, data.ti_img_refno3);
                db.AddInParameter(dbCommand, "ti_img_refno4", DbType.String, data.ti_img_refno4);
                db.AddInParameter(dbCommand, "ti_img_refno5", DbType.String, data.ti_img_refno5);

                db.AddOutParameter(dbCommand, "tiId", DbType.Int32, 100);

                int result = db.ExecuteNonQuery(dbCommand);

                int tiId_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "tiId").ToString());

                return tiId_output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DeleteTreatmentAttachment(int tiId, int ti_modifyby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Treatment_Attachment_Delete");

                db.AddInParameter(dbCommand, "tiId", DbType.Int32, tiId);
                db.AddInParameter(dbCommand, "ti_modifyby", DbType.Int32, ti_modifyby);

                db.AddOutParameter(dbCommand, "tr_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "tr_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}