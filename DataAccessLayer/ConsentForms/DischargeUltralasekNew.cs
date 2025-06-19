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
    public class DischargeUltralasekNew
    {
        public static DataTable GetDischargeUltralasekNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Ultralasek_Treatment_New_Select");

                db.AddInParameter(dbCommand, "dut_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveDischargeUltralasekNew(BusinessEntities.ConsentForms.DischargeUltralasekNew discharge, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Ultralasek_Treatment_New_Insert");

                db.AddInParameter(dbCommand, "dut_appId", DbType.Int32, discharge.dut_appId);
                db.AddInParameter(dbCommand, "dut_1", DbType.String, string.IsNullOrEmpty(discharge.dut_1) ? "" : discharge.dut_1);
                db.AddInParameter(dbCommand, "dut_2", DbType.String, string.IsNullOrEmpty(discharge.dut_2) ? "" : discharge.dut_2);
                db.AddInParameter(dbCommand, "dut_3", DbType.String, string.IsNullOrEmpty(discharge.dut_3) ? "" : discharge.dut_3);
                db.AddInParameter(dbCommand, "dut_4", DbType.String, string.IsNullOrEmpty(discharge.dut_4) ? "" : discharge.dut_4);
                db.AddInParameter(dbCommand, "dut_5", DbType.String, string.IsNullOrEmpty(discharge.dut_5) ? "" : discharge.dut_5);
                db.AddInParameter(dbCommand, "dut_6", DbType.String, string.IsNullOrEmpty(discharge.dut_6) ? "" : discharge.dut_6);
                db.AddInParameter(dbCommand, "dut_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dutId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dutId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dutId"));
                return _dutId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteDischargeUltralasekNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Ultralasek_Treatment_New_Delete");

                db.AddInParameter(dbCommand, "dut_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dut_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dut_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dut_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dut_output"));

                return _dut_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetDischargeUltralasekNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Ultralasek_Treatment_New_PreviousHistory");

                db.AddInParameter(dbCommand, "dut_appId", DbType.Int32, appId);
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
