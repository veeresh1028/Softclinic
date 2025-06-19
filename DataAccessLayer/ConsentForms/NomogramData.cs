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
    public class NomogramData
    {
        public static DataTable GetNomogramDataData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Nomogram_Data_New_Select");

                db.AddInParameter(dbCommand, "ndn_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveNomogramData(BusinessEntities.ConsentForms.NomogramData ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Nomogram_Data_New_Insert");

                db.AddInParameter(dbCommand, "ndn_appId", DbType.Int32, ophtha.ndn_appId);
                db.AddInParameter(dbCommand, "ndn_1", DbType.String, string.IsNullOrEmpty(ophtha.ndn_1) ? "" : ophtha.ndn_1);
                db.AddInParameter(dbCommand, "ndn_2", DbType.String, string.IsNullOrEmpty(ophtha.ndn_2) ? "" : ophtha.ndn_2);
                db.AddInParameter(dbCommand, "ndn_3", DbType.String, string.IsNullOrEmpty(ophtha.ndn_3) ? "" : ophtha.ndn_3);
                db.AddInParameter(dbCommand, "ndn_4", DbType.String, string.IsNullOrEmpty(ophtha.ndn_4) ? "" : ophtha.ndn_4);
                db.AddInParameter(dbCommand, "ndn_5", DbType.String, string.IsNullOrEmpty(ophtha.ndn_5) ? "" : ophtha.ndn_5);
                db.AddInParameter(dbCommand, "ndn_6", DbType.String, string.IsNullOrEmpty(ophtha.ndn_6) ? "" : ophtha.ndn_6);
                db.AddInParameter(dbCommand, "ndn_7", DbType.String, string.IsNullOrEmpty(ophtha.ndn_7) ? "" : ophtha.ndn_7);
                db.AddInParameter(dbCommand, "ndn_8", DbType.String, string.IsNullOrEmpty(ophtha.ndn_8) ? "" : ophtha.ndn_8);
                db.AddInParameter(dbCommand, "ndn_9", DbType.String, string.IsNullOrEmpty(ophtha.ndn_9) ? "" : ophtha.ndn_9);
                db.AddInParameter(dbCommand, "ndn_10", DbType.String, string.IsNullOrEmpty(ophtha.ndn_10) ? "" : ophtha.ndn_10);
                db.AddInParameter(dbCommand, "ndn_11", DbType.String, string.IsNullOrEmpty(ophtha.ndn_11) ? "" : ophtha.ndn_11);
                db.AddInParameter(dbCommand, "ndn_12", DbType.String, string.IsNullOrEmpty(ophtha.ndn_12) ? "" : ophtha.ndn_12);
                db.AddInParameter(dbCommand, "ndn_13", DbType.String, string.IsNullOrEmpty(ophtha.ndn_13) ? "" : ophtha.ndn_13);
                db.AddInParameter(dbCommand, "ndn_14", DbType.String, string.IsNullOrEmpty(ophtha.ndn_14) ? "" : ophtha.ndn_14);
                db.AddInParameter(dbCommand, "ndn_15", DbType.String, string.IsNullOrEmpty(ophtha.ndn_15) ? "" : ophtha.ndn_15);
                db.AddInParameter(dbCommand, "ndn_16", DbType.String, string.IsNullOrEmpty(ophtha.ndn_16) ? "" : ophtha.ndn_16);
                db.AddInParameter(dbCommand, "ndn_17", DbType.String, string.IsNullOrEmpty(ophtha.ndn_17) ? "" : ophtha.ndn_17);
                db.AddInParameter(dbCommand, "ndn_18", DbType.String, string.IsNullOrEmpty(ophtha.ndn_18) ? "" : ophtha.ndn_18);
                db.AddInParameter(dbCommand, "ndn_19", DbType.String, string.IsNullOrEmpty(ophtha.ndn_19) ? "" : ophtha.ndn_19);
                db.AddInParameter(dbCommand, "ndn_20", DbType.String, string.IsNullOrEmpty(ophtha.ndn_20) ? "" : ophtha.ndn_20);
                db.AddInParameter(dbCommand, "ndn_21", DbType.String, string.IsNullOrEmpty(ophtha.ndn_21) ? "" : ophtha.ndn_21);
                db.AddInParameter(dbCommand, "ndn_22", DbType.String, string.IsNullOrEmpty(ophtha.ndn_22) ? "" : ophtha.ndn_22);
                db.AddInParameter(dbCommand, "ndn_23", DbType.String, string.IsNullOrEmpty(ophtha.ndn_23) ? "" : ophtha.ndn_23);
                db.AddInParameter(dbCommand, "ndn_24", DbType.String, string.IsNullOrEmpty(ophtha.ndn_24) ? "" : ophtha.ndn_24);

                db.AddInParameter(dbCommand, "ndn_dd_1", DbType.String, string.IsNullOrEmpty(ophtha.ndn_dd_1) ? "" : ophtha.ndn_dd_1);
                db.AddInParameter(dbCommand, "ndn_dd_2", DbType.String, string.IsNullOrEmpty(ophtha.ndn_dd_2) ? "" : ophtha.ndn_dd_2);
                db.AddInParameter(dbCommand, "ndn_dd_3", DbType.String, string.IsNullOrEmpty(ophtha.ndn_dd_3) ? "" : ophtha.ndn_dd_3);
                db.AddInParameter(dbCommand, "ndn_dd_4", DbType.String, string.IsNullOrEmpty(ophtha.ndn_dd_4) ? "" : ophtha.ndn_dd_4);
                db.AddInParameter(dbCommand, "ndn_dd_5", DbType.String, string.IsNullOrEmpty(ophtha.ndn_dd_5) ? "" : ophtha.ndn_dd_5);
                db.AddInParameter(dbCommand, "ndn_dd_6", DbType.String, string.IsNullOrEmpty(ophtha.ndn_dd_6) ? "" : ophtha.ndn_dd_6);
                db.AddInParameter(dbCommand, "ndn_dd_7", DbType.String, string.IsNullOrEmpty(ophtha.ndn_dd_7) ? "" : ophtha.ndn_dd_7);
                db.AddInParameter(dbCommand, "ndn_dd_8", DbType.String, string.IsNullOrEmpty(ophtha.ndn_dd_8) ? "" : ophtha.ndn_dd_8);
                db.AddInParameter(dbCommand, "ndn_dd_9", DbType.String, string.IsNullOrEmpty(ophtha.ndn_dd_9) ? "" : ophtha.ndn_dd_9);
                db.AddInParameter(dbCommand, "ndn_dd_10", DbType.String, string.IsNullOrEmpty(ophtha.ndn_dd_10) ? "" : ophtha.ndn_dd_10);
                db.AddInParameter(dbCommand, "ndn_dd_11", DbType.String, string.IsNullOrEmpty(ophtha.ndn_dd_11) ? "" : ophtha.ndn_dd_11);
                db.AddInParameter(dbCommand, "ndn_dd_12", DbType.String, string.IsNullOrEmpty(ophtha.ndn_dd_12) ? "" : ophtha.ndn_dd_12);
                db.AddInParameter(dbCommand, "ndn_dd_13", DbType.String, string.IsNullOrEmpty(ophtha.ndn_dd_13) ? "" : ophtha.ndn_dd_13);
                db.AddInParameter(dbCommand, "ndn_dd_14", DbType.String, string.IsNullOrEmpty(ophtha.ndn_dd_14) ? "" : ophtha.ndn_dd_14);
                db.AddInParameter(dbCommand, "ndn_dd_15", DbType.String, string.IsNullOrEmpty(ophtha.ndn_dd_15) ? "" : ophtha.ndn_dd_15);
                db.AddInParameter(dbCommand, "ndn_dd_16", DbType.String, string.IsNullOrEmpty(ophtha.ndn_dd_16) ? "" : ophtha.ndn_dd_16);
                db.AddInParameter(dbCommand, "ndn_dd_17", DbType.String, string.IsNullOrEmpty(ophtha.ndn_dd_17) ? "" : ophtha.ndn_dd_17);

                db.AddInParameter(dbCommand, "ndn_chk_1", DbType.String, string.IsNullOrEmpty(ophtha.ndn_chk_1) ? "" : ophtha.ndn_chk_1);

                db.AddInParameter(dbCommand, "ndn_date_1", DbType.String, string.IsNullOrEmpty(ophtha.ndn_date_1) ? "" : ophtha.ndn_date_1);

                db.AddInParameter(dbCommand, "ndn_doc1", DbType.String, ophtha.image);
                db.AddInParameter(dbCommand, "ndn_doc2", DbType.String, ophtha.image2);

                db.AddInParameter(dbCommand, "ndn_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ndnId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ndnId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ndnId"));
                return _ndnId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteNomogramData(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Nomogram_Data_New_Delete");

                db.AddInParameter(dbCommand, "ndn_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ndn_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ndn_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ndn_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ndn_output"));

                return _ndn_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetNomogramDataPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Nomogram_Data_New_PreviousHistory");

                db.AddInParameter(dbCommand, "ndn_appId", DbType.Int32, appId);
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
