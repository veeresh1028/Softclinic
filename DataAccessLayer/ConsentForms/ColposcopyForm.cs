using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConsentForms
{
    public class ColposcopyForm
    {
        public static DataTable GetColposcopyFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Colposcopy_Form_Select");

                db.AddInParameter(dbCommand, "ccf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveColposcopyForm(BusinessEntities.ConsentForms.ColposcopyForm colposcopy, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Colposcopy_Form_Insert");

                db.AddInParameter(dbCommand, "ccf_appId", DbType.Int32, colposcopy.ccf_appId);
                db.AddInParameter(dbCommand, "ccf_1", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_1) ? "" : colposcopy.ccf_1);
                db.AddInParameter(dbCommand, "ccf_2", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_2) ? "" : colposcopy.ccf_2);
                db.AddInParameter(dbCommand, "ccf_3", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_3) ? "" : colposcopy.ccf_3);
                db.AddInParameter(dbCommand, "ccf_4", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_4) ? "" : colposcopy.ccf_4);
                db.AddInParameter(dbCommand, "ccf_5", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_5) ? "" : colposcopy.ccf_5);
                db.AddInParameter(dbCommand, "ccf_6", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_6) ? "" : colposcopy.ccf_6);
                db.AddInParameter(dbCommand, "ccf_7", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_7) ? "" : colposcopy.ccf_7);
                db.AddInParameter(dbCommand, "ccf_8", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_8) ? "" : colposcopy.ccf_8);
                db.AddInParameter(dbCommand, "ccf_9", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_9) ? "" : colposcopy.ccf_9);
                db.AddInParameter(dbCommand, "ccf_10", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_10) ? "" : colposcopy.ccf_10);
                db.AddInParameter(dbCommand, "ccf_11", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_11) ? "" : colposcopy.ccf_11);
                db.AddInParameter(dbCommand, "ccf_12", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_12) ? "" : colposcopy.ccf_12);
                db.AddInParameter(dbCommand, "ccf_13", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_13) ? "" : colposcopy.ccf_13);
                db.AddInParameter(dbCommand, "ccf_14", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_14) ? "" : colposcopy.ccf_14);
                db.AddInParameter(dbCommand, "ccf_15", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_15) ? "" : colposcopy.ccf_15);
                db.AddInParameter(dbCommand, "ccf_16", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_16) ? "" : colposcopy.ccf_16);
                db.AddInParameter(dbCommand, "ccf_17", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_17) ? "" : colposcopy.ccf_17);
                db.AddInParameter(dbCommand, "ccf_18", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_18) ? "" : colposcopy.ccf_18);
                db.AddInParameter(dbCommand, "ccf_19", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_19) ? "" : colposcopy.ccf_19);
                db.AddInParameter(dbCommand, "ccf_20", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_20) ? "" : colposcopy.ccf_20);
                db.AddInParameter(dbCommand, "ccf_21", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_21) ? "" : colposcopy.ccf_21);
                db.AddInParameter(dbCommand, "ccf_22", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_22) ? "" : colposcopy.ccf_22);
                db.AddInParameter(dbCommand, "ccf_chk1", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_chk1) ? "" : colposcopy.ccf_chk1);
                db.AddInParameter(dbCommand, "ccf_radio1", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_radio1) ? "" : colposcopy.ccf_radio1);
                db.AddInParameter(dbCommand, "ccf_radio2", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_radio2) ? "" : colposcopy.ccf_radio2);
                db.AddInParameter(dbCommand, "ccf_radio3", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_radio3) ? "" : colposcopy.ccf_radio3);
                db.AddInParameter(dbCommand, "ccf_radio4", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_radio4) ? "" : colposcopy.ccf_radio4);
                db.AddInParameter(dbCommand, "ccf_date1", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_date1) ? "" : colposcopy.ccf_date1);
                db.AddInParameter(dbCommand, "ccf_date2", DbType.String, string.IsNullOrEmpty(colposcopy.ccf_date2) ? "" : colposcopy.ccf_date2);
                db.AddInParameter(dbCommand, "ccf_doc", DbType.String, colposcopy.image);
                db.AddInParameter(dbCommand, "ccf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ccfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ccfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ccfId"));
                return _ccfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteColposcopyForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Colposcopy_Form_Delete");

                db.AddInParameter(dbCommand, "ccf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ccf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ccf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ccf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ccf_output"));

                return _ccf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetColposcopyFormPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Colposcopy_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "ccf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
