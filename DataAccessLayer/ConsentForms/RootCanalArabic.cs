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
    public class RootCanalArabic
    {
        public static DataTable GetRootCanalArabicData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Root_Canal_Treatment_Arb_Select");

                db.AddInParameter(dbCommand, "crcta_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveRootCanalArabic(BusinessEntities.ConsentForms.RootCanalArabic canal, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Root_Canal_Treatment_Arb_Insert");

                db.AddInParameter(dbCommand, "crcta_appId", DbType.Int32, canal.crcta_appId);
                db.AddInParameter(dbCommand, "crcta_1", DbType.String, canal.crcta_1);
                db.AddInParameter(dbCommand, "crcta_2", DbType.String, canal.crcta_2);
                db.AddInParameter(dbCommand, "crcta_3", DbType.String, canal.crcta_3);
                db.AddInParameter(dbCommand, "crcta_4", DbType.String, canal.crcta_4);
                db.AddInParameter(dbCommand, "crcta_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "crctaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _crctaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "crctaId"));
                return _crctaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteRootCanalArabic(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Root_Canal_Treatment_Arb_Delete");

                db.AddInParameter(dbCommand, "crcta_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "crcta_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "crcta_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _crcta_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "crcta_output"));

                return _crcta_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetRootCanalArabicPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Root_Canal_Treatment_Arb_PreviousHistory");

                db.AddInParameter(dbCommand, "crcta_appId", DbType.Int32, appId);
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
