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
    public class PhysicalExamForm
    {
        public static DataTable GetPhysicalExamFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Physical_Exam_Form_Select");

                db.AddInParameter(dbCommand, "pef_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SavePhysicalExamForm(BusinessEntities.ConsentForms.PhysicalExamForm physical, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Physical_Exam_Form_Insert");

                db.AddInParameter(dbCommand, "pef_appId", DbType.Int32, physical.pef_appId);
                db.AddInParameter(dbCommand, "pef_1", DbType.String, string.IsNullOrEmpty(physical.pef_1) ? "" : physical.pef_1);
                db.AddInParameter(dbCommand, "pef_2", DbType.String, string.IsNullOrEmpty(physical.pef_2) ? "" : physical.pef_2);
                db.AddInParameter(dbCommand, "pef_3", DbType.String, string.IsNullOrEmpty(physical.pef_3) ? "" : physical.pef_3);
                db.AddInParameter(dbCommand, "pef_4", DbType.String, string.IsNullOrEmpty(physical.pef_4) ? "" : physical.pef_4);
                db.AddInParameter(dbCommand, "pef_5", DbType.String, string.IsNullOrEmpty(physical.pef_5) ? "" : physical.pef_5);
                db.AddInParameter(dbCommand, "pef_6", DbType.String, string.IsNullOrEmpty(physical.pef_6) ? "" : physical.pef_6);
                db.AddInParameter(dbCommand, "pef_7", DbType.String, string.IsNullOrEmpty(physical.pef_7) ? "" : physical.pef_7);
                db.AddInParameter(dbCommand, "pef_8", DbType.String, string.IsNullOrEmpty(physical.pef_8) ? "" : physical.pef_8);
                db.AddInParameter(dbCommand, "pef_9", DbType.String, string.IsNullOrEmpty(physical.pef_9) ? "" : physical.pef_9);
                db.AddInParameter(dbCommand, "pef_10", DbType.String, string.IsNullOrEmpty(physical.pef_10) ? "" : physical.pef_10);
                db.AddInParameter(dbCommand, "pef_11", DbType.String, string.IsNullOrEmpty(physical.pef_11) ? "" : physical.pef_11);
                db.AddInParameter(dbCommand, "pef_12", DbType.String, string.IsNullOrEmpty(physical.pef_12) ? "" : physical.pef_12);
                db.AddInParameter(dbCommand, "pef_13", DbType.String, string.IsNullOrEmpty(physical.pef_13) ? "" : physical.pef_13);
                db.AddInParameter(dbCommand, "pef_14", DbType.String, string.IsNullOrEmpty(physical.pef_14) ? "" : physical.pef_14);
                db.AddInParameter(dbCommand, "pef_15", DbType.String, string.IsNullOrEmpty(physical.pef_15) ? "" : physical.pef_15);
                db.AddInParameter(dbCommand, "pef_16", DbType.String, string.IsNullOrEmpty(physical.pef_16) ? "" : physical.pef_16);
                db.AddInParameter(dbCommand, "pef_17", DbType.String, string.IsNullOrEmpty(physical.pef_17) ? "" : physical.pef_17);
                db.AddInParameter(dbCommand, "pef_18", DbType.String, string.IsNullOrEmpty(physical.pef_18) ? "" : physical.pef_18);
                db.AddInParameter(dbCommand, "pef_19", DbType.String, string.IsNullOrEmpty(physical.pef_19) ? "" : physical.pef_19);
                db.AddInParameter(dbCommand, "pef_20", DbType.String, string.IsNullOrEmpty(physical.pef_20) ? "" : physical.pef_20);
                db.AddInParameter(dbCommand, "pef_21", DbType.String, string.IsNullOrEmpty(physical.pef_21) ? "" : physical.pef_21);
                db.AddInParameter(dbCommand, "pef_22", DbType.String, string.IsNullOrEmpty(physical.pef_22) ? "" : physical.pef_22);
                db.AddInParameter(dbCommand, "pef_23", DbType.String, string.IsNullOrEmpty(physical.pef_23) ? "" : physical.pef_23);
                db.AddInParameter(dbCommand, "pef_24", DbType.String, string.IsNullOrEmpty(physical.pef_24) ? "" : physical.pef_24);
                db.AddInParameter(dbCommand, "pef_25", DbType.String, string.IsNullOrEmpty(physical.pef_25) ? "" : physical.pef_25);
                db.AddInParameter(dbCommand, "pef_26", DbType.String, string.IsNullOrEmpty(physical.pef_26) ? "" : physical.pef_26);
                db.AddInParameter(dbCommand, "pef_27", DbType.String, string.IsNullOrEmpty(physical.pef_27) ? "" : physical.pef_27);
                db.AddInParameter(dbCommand, "pef_28", DbType.String, string.IsNullOrEmpty(physical.pef_28) ? "" : physical.pef_28);
                db.AddInParameter(dbCommand, "pef_29", DbType.String, string.IsNullOrEmpty(physical.pef_29) ? "" : physical.pef_29);
                db.AddInParameter(dbCommand, "pef_30", DbType.String, string.IsNullOrEmpty(physical.pef_30) ? "" : physical.pef_30);
                db.AddInParameter(dbCommand, "pef_31", DbType.String, string.IsNullOrEmpty(physical.pef_31) ? "" : physical.pef_31);
                db.AddInParameter(dbCommand, "pef_32", DbType.String, string.IsNullOrEmpty(physical.pef_32) ? "" : physical.pef_32);
                db.AddInParameter(dbCommand, "pef_33", DbType.String, string.IsNullOrEmpty(physical.pef_33) ? "" : physical.pef_33);
                db.AddInParameter(dbCommand, "pef_34", DbType.String, string.IsNullOrEmpty(physical.pef_34) ? "" : physical.pef_34);
                db.AddInParameter(dbCommand, "pef_35", DbType.String, string.IsNullOrEmpty(physical.pef_35) ? "" : physical.pef_35);
                db.AddInParameter(dbCommand, "pef_36", DbType.String, string.IsNullOrEmpty(physical.pef_36) ? "" : physical.pef_36);
                db.AddInParameter(dbCommand, "pef_chk1", DbType.String, string.IsNullOrEmpty(physical.pef_chk1) ? "" : physical.pef_chk1);
                db.AddInParameter(dbCommand, "pef_doc", DbType.String, physical.image);
                db.AddInParameter(dbCommand, "pef_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "pefId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _pefId = Convert.ToInt32(db.GetParameterValue(dbCommand, "pefId"));
                return _pefId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeletePhysicalExamForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Physical_Exam_Form_Delete");

                db.AddInParameter(dbCommand, "pef_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "pef_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "pef_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _pef_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "pef_output"));

                return _pef_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetPhysicalExamFormPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Physical_Exam_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "pef_appId", DbType.Int32, appId);
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
