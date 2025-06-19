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
    public class RevisionRequestForm
    {
        public static DataTable GetRevisionRequestFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Revision_Request_Form_Select");

                db.AddInParameter(dbCommand, "rrf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveRevisionRequestForm(BusinessEntities.ConsentForms.RevisionRequestForm revision, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Revision_Request_Form_Insert");

                db.AddInParameter(dbCommand, "rrf_appId", DbType.Int32, revision.rrf_appId);
                db.AddInParameter(dbCommand, "rrf_date1", DbType.String, string.IsNullOrEmpty(revision.rrf_date1) ? "" : revision.rrf_date1);
                db.AddInParameter(dbCommand, "rrf_date2", DbType.String, string.IsNullOrEmpty(revision.rrf_date2) ? "" : revision.rrf_date2);
                db.AddInParameter(dbCommand, "rrf_date3", DbType.String, string.IsNullOrEmpty(revision.rrf_date3) ? "" : revision.rrf_date3);
                db.AddInParameter(dbCommand, "rrf_1", DbType.String, string.IsNullOrEmpty(revision.rrf_1) ? "" : revision.rrf_1);
                db.AddInParameter(dbCommand, "rrf_2", DbType.String, string.IsNullOrEmpty(revision.rrf_2) ? "" : revision.rrf_2);
                db.AddInParameter(dbCommand, "rrf_3", DbType.String, string.IsNullOrEmpty(revision.rrf_3) ? "" : revision.rrf_3);
                db.AddInParameter(dbCommand, "rrf_4", DbType.String, string.IsNullOrEmpty(revision.rrf_4) ? "" : revision.rrf_4);
                db.AddInParameter(dbCommand, "rrf_5", DbType.String, string.IsNullOrEmpty(revision.rrf_5) ? "" : revision.rrf_5);
                db.AddInParameter(dbCommand, "rrf_6", DbType.String, string.IsNullOrEmpty(revision.rrf_6) ? "" : revision.rrf_6);
                db.AddInParameter(dbCommand, "rrf_7", DbType.String, string.IsNullOrEmpty(revision.rrf_7) ? "" : revision.rrf_7);
                db.AddInParameter(dbCommand, "rrf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "rrfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _rrfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "rrfId"));
                return _rrfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteRevisionRequestForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Revision_Request_Form_Delete");

                db.AddInParameter(dbCommand, "rrf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "rrf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "rrf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _rrf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "rrf_output"));

                return _rrf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetRevisionRequestFormPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Revision_Request_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "rrf_appId", DbType.Int32, appId);
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
