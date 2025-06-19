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
    public class PhysicalExamEntNew
    {
        public static DataTable GetPhysicalExamEntNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Physical_Exam_Ent_New_Select");

                db.AddInParameter(dbCommand, "pee_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SavePhysicalExamEntNew(BusinessEntities.ConsentForms.PhysicalExamEntNew physical, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Physical_Exam_Ent_New_Insert");

                db.AddInParameter(dbCommand, "pee_appId", DbType.Int32, physical.pee_appId);
                db.AddInParameter(dbCommand, "pee_1", DbType.String, string.IsNullOrEmpty(physical.pee_1) ? "" : physical.pee_1);
                db.AddInParameter(dbCommand, "pee_2", DbType.String, string.IsNullOrEmpty(physical.pee_2) ? "" : physical.pee_2);
                db.AddInParameter(dbCommand, "pee_3", DbType.String, string.IsNullOrEmpty(physical.pee_3) ? "" : physical.pee_3);
                db.AddInParameter(dbCommand, "pee_4", DbType.String, string.IsNullOrEmpty(physical.pee_4) ? "" : physical.pee_4);
                db.AddInParameter(dbCommand, "pee_5", DbType.String, string.IsNullOrEmpty(physical.pee_5) ? "" : physical.pee_5);
                db.AddInParameter(dbCommand, "pee_6", DbType.String, string.IsNullOrEmpty(physical.pee_6) ? "" : physical.pee_6);
                db.AddInParameter(dbCommand, "pee_7", DbType.String, string.IsNullOrEmpty(physical.pee_7) ? "" : physical.pee_7);
                db.AddInParameter(dbCommand, "pee_chk1", DbType.String, string.IsNullOrEmpty(physical.pee_chk1) ? "" : physical.pee_chk1);
                db.AddInParameter(dbCommand, "pee_8", DbType.String, string.IsNullOrEmpty(physical.pee_8) ? "" : physical.pee_8);
                db.AddInParameter(dbCommand, "pee_9", DbType.String, string.IsNullOrEmpty(physical.pee_9) ? "" : physical.pee_9);
                db.AddInParameter(dbCommand, "pee_10", DbType.String, string.IsNullOrEmpty(physical.pee_10) ? "" : physical.pee_10);
                db.AddInParameter(dbCommand, "pee_11", DbType.String, string.IsNullOrEmpty(physical.pee_11) ? "" : physical.pee_11);
                db.AddInParameter(dbCommand, "pee_chk2", DbType.String, string.IsNullOrEmpty(physical.pee_chk2) ? "" : physical.pee_chk2);
                db.AddInParameter(dbCommand, "pee_chk3", DbType.String, string.IsNullOrEmpty(physical.pee_chk3) ? "" : physical.pee_chk3);
                db.AddInParameter(dbCommand, "pee_chk4", DbType.String, string.IsNullOrEmpty(physical.pee_chk4) ? "" : physical.pee_chk4);
                db.AddInParameter(dbCommand, "pee_12", DbType.String, string.IsNullOrEmpty(physical.pee_12) ? "" : physical.pee_12);
                db.AddInParameter(dbCommand, "pee_13", DbType.String, string.IsNullOrEmpty(physical.pee_13) ? "" : physical.pee_13);
                db.AddInParameter(dbCommand, "pee_14", DbType.String, string.IsNullOrEmpty(physical.pee_14) ? "" : physical.pee_14);
                db.AddInParameter(dbCommand, "pee_15", DbType.String, string.IsNullOrEmpty(physical.pee_15) ? "" : physical.pee_15);
                db.AddInParameter(dbCommand, "pee_16", DbType.String, string.IsNullOrEmpty(physical.pee_16) ? "" : physical.pee_16);
                db.AddInParameter(dbCommand, "pee_17", DbType.String, string.IsNullOrEmpty(physical.pee_17) ? "" : physical.pee_17);
                db.AddInParameter(dbCommand, "pee_chk5", DbType.String, string.IsNullOrEmpty(physical.pee_chk5) ? "" : physical.pee_chk5);
                db.AddInParameter(dbCommand, "pee_chk6", DbType.String, string.IsNullOrEmpty(physical.pee_chk6) ? "" : physical.pee_chk6);
                db.AddInParameter(dbCommand, "pee_18", DbType.String, string.IsNullOrEmpty(physical.pee_18) ? "" : physical.pee_18);
                db.AddInParameter(dbCommand, "pee_19", DbType.String, string.IsNullOrEmpty(physical.pee_19) ? "" : physical.pee_19);
                db.AddInParameter(dbCommand, "pee_20", DbType.String, string.IsNullOrEmpty(physical.pee_20) ? "" : physical.pee_20);
                db.AddInParameter(dbCommand, "pee_21", DbType.String, string.IsNullOrEmpty(physical.pee_21) ? "" : physical.pee_21);
                db.AddInParameter(dbCommand, "pee_chk7", DbType.String, string.IsNullOrEmpty(physical.pee_chk7) ? "" : physical.pee_chk7);
                db.AddInParameter(dbCommand, "pee_22", DbType.String, string.IsNullOrEmpty(physical.pee_22) ? "" : physical.pee_22);
                db.AddInParameter(dbCommand, "pee_23", DbType.String, string.IsNullOrEmpty(physical.pee_23) ? "" : physical.pee_23);
                db.AddInParameter(dbCommand, "pee_24", DbType.String, string.IsNullOrEmpty(physical.pee_24) ? "" : physical.pee_24);
                db.AddInParameter(dbCommand, "pee_25", DbType.String, string.IsNullOrEmpty(physical.pee_25) ? "" : physical.pee_25);
                db.AddInParameter(dbCommand, "pee_26", DbType.String, string.IsNullOrEmpty(physical.pee_26) ? "" : physical.pee_26);
                db.AddInParameter(dbCommand, "pee_27", DbType.String, string.IsNullOrEmpty(physical.pee_27) ? "" : physical.pee_27);
                db.AddInParameter(dbCommand, "pee_chk8", DbType.String, string.IsNullOrEmpty(physical.pee_chk8) ? "" : physical.pee_chk8);
                db.AddInParameter(dbCommand, "pee_chk9", DbType.String, string.IsNullOrEmpty(physical.pee_chk9) ? "" : physical.pee_chk9);
                db.AddInParameter(dbCommand, "pee_28", DbType.String, string.IsNullOrEmpty(physical.pee_28) ? "" : physical.pee_28);
                db.AddInParameter(dbCommand, "pee_29", DbType.String, string.IsNullOrEmpty(physical.pee_29) ? "" : physical.pee_29);
                db.AddInParameter(dbCommand, "pee_30", DbType.String, string.IsNullOrEmpty(physical.pee_30) ? "" : physical.pee_30);
                db.AddInParameter(dbCommand, "pee_31", DbType.String, string.IsNullOrEmpty(physical.pee_31) ? "" : physical.pee_31);
                db.AddInParameter(dbCommand, "pee_32", DbType.String, string.IsNullOrEmpty(physical.pee_32) ? "" : physical.pee_32);
                db.AddInParameter(dbCommand, "pee_33", DbType.String, string.IsNullOrEmpty(physical.pee_33) ? "" : physical.pee_33);
                db.AddInParameter(dbCommand, "pee_34", DbType.String, string.IsNullOrEmpty(physical.pee_34) ? "" : physical.pee_34);
                db.AddInParameter(dbCommand, "pee_doc1", DbType.String, physical.image);
                db.AddInParameter(dbCommand, "pee_doc2", DbType.String, physical.image2);
                db.AddInParameter(dbCommand, "pee_doc3", DbType.String, physical.image3);
                db.AddInParameter(dbCommand, "pee_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "peeId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _peeId = Convert.ToInt32(db.GetParameterValue(dbCommand, "peeId"));
                return _peeId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeletePhysicalExamEntNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Physical_Exam_Ent_New_Delete");

                db.AddInParameter(dbCommand, "pee_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "pee_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "pee_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _pee_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "pee_output"));

                return _pee_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetPhysicalExamEntNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Physical_Exam_Ent_New_PreviousHistory");

                db.AddInParameter(dbCommand, "pee_appId", DbType.Int32, appId);
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
