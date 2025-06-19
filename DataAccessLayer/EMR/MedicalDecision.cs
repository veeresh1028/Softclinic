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
    public class MedicalDecision
    {
        #region MedicalDecision (Page Load)
        public static DataTable GetAllMedicalDecision(int? appId, int? mdId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MEDICAL_DECISION_select_all_info");
                if (mdId > 0)
                {
                    db.AddInParameter(dbCommand, "mdId", DbType.Int32, mdId);
                }
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPreMedicalDecision(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MEDICAL_DECISION_PREVIOUS_History");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion MedicalDecision (Page Load)

        #region MedicalDecision CRUD Operations
        public static bool InsertUpdateMedicalDecision(BusinessEntities.EMR.MedicalDecision data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MEDICAL_DECISION_INSERT_UPDATE");
                if (data.mdId > 0)
                {
                    db.AddInParameter(dbCommand, "mdId", DbType.Int32, data.mdId);
                }
                db.AddInParameter(dbCommand, "md_appId", DbType.Int32, data.md_appId);
                db.AddInParameter(dbCommand, "md_txt1", DbType.String, data.md_txt1);
                db.AddInParameter(dbCommand, "md_txt2", DbType.String, data.md_txt2);
                db.AddInParameter(dbCommand, "md_txt3", DbType.String, data.md_txt3);
                db.AddInParameter(dbCommand, "md_txt4", DbType.String, data.md_txt4);
                db.AddInParameter(dbCommand, "md_txt5", DbType.String, data.md_txt5);
                db.AddInParameter(dbCommand, "md_txt6", DbType.String, data.md_txt6);
                db.AddInParameter(dbCommand, "md_txt7", DbType.String, data.md_txt7);
                db.AddInParameter(dbCommand, "md_chk", DbType.String, data.md_chk);

                db.AddInParameter(dbCommand, "md_madeby", DbType.Int32, data.md_madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int DeleteMedicalDecision(int mdId, int md_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MEDICAL_DECISION_delete");

                db.AddInParameter(dbCommand, "mdId", DbType.Int32, mdId);
                db.AddInParameter(dbCommand, "md_madeby", DbType.String, md_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion MedicalDecision CRUD Operations
    }
}
