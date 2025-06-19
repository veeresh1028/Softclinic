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
    public class OperativeCollagenCrossLinkingNew
    {
        public static DataTable GetOperativeCollagenCrossLinkingNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Collagen_Cross_Linking_New_Select");

                db.AddInParameter(dbCommand, "occl_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveOperativeCollagenCrossLinkingNew(BusinessEntities.ConsentForms.OperativeCollagenCrossLinkingNew discharge, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Collagen_Cross_Linking_New_Insert");

                db.AddInParameter(dbCommand, "occl_appId", DbType.Int32, discharge.occl_appId);
                db.AddInParameter(dbCommand, "occl_1", DbType.String, string.IsNullOrEmpty(discharge.occl_1) ? "" : discharge.occl_1);
                db.AddInParameter(dbCommand, "occl_2", DbType.String, string.IsNullOrEmpty(discharge.occl_2) ? "" : discharge.occl_2);
                db.AddInParameter(dbCommand, "occl_3", DbType.String, string.IsNullOrEmpty(discharge.occl_3) ? "" : discharge.occl_3);
                db.AddInParameter(dbCommand, "occl_4", DbType.String, string.IsNullOrEmpty(discharge.occl_4) ? "" : discharge.occl_4);
                db.AddInParameter(dbCommand, "occl_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "occlId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _occlId = Convert.ToInt32(db.GetParameterValue(dbCommand, "occlId"));
                return _occlId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteOperativeCollagenCrossLinkingNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Collagen_Cross_Linking_New_Delete");

                db.AddInParameter(dbCommand, "occl_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "occl_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "occl_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _occl_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "occl_output"));

                return _occl_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetOperativeCollagenCrossLinkingNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Collagen_Cross_Linking_New_PreviousHistory");

                db.AddInParameter(dbCommand, "occl_appId", DbType.Int32, appId);
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
