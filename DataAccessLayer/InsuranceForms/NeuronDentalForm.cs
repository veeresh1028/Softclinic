using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer.InsuranceForms
{
    public class NeuronDentalForm
    {
        public static DataTable GetNeuronDentalFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Neuron_Claim_Dental_Select");

                db.AddInParameter(dbCommand, "ncd_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveNeuronDentalForm(BusinessEntities.InsuranceForms.NeuronDentalForm medical, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Neuron_Claim_Dental_Insert");

                db.AddInParameter(dbCommand, "ncd_appId", DbType.Int32, medical.ncd_appId);
                db.AddInParameter(dbCommand, "ncd_1", DbType.String, string.IsNullOrEmpty(medical.ncd_1) ? "" : medical.ncd_1);
                db.AddInParameter(dbCommand, "ncd_2", DbType.String, string.IsNullOrEmpty(medical.ncd_2) ? "" : medical.ncd_2);
                db.AddInParameter(dbCommand, "ncd_3", DbType.String, string.IsNullOrEmpty(medical.ncd_3) ? "" : medical.ncd_3);
                db.AddInParameter(dbCommand, "ncd_4", DbType.String, string.IsNullOrEmpty(medical.ncd_4) ? "" : medical.ncd_4);
                db.AddInParameter(dbCommand, "ncd_5", DbType.String, string.IsNullOrEmpty(medical.ncd_5) ? "" : medical.ncd_5);
                db.AddInParameter(dbCommand, "ncd_6", DbType.String, string.IsNullOrEmpty(medical.ncd_6) ? "" : medical.ncd_6);
                db.AddInParameter(dbCommand, "ncd_7", DbType.String, string.IsNullOrEmpty(medical.ncd_7) ? "" : medical.ncd_7);
                db.AddInParameter(dbCommand, "ncd_8", DbType.String, string.IsNullOrEmpty(medical.ncd_8) ? "" : medical.ncd_8);
                db.AddInParameter(dbCommand, "ncd_9", DbType.String, string.IsNullOrEmpty(medical.ncd_9) ? "" : medical.ncd_9);
                db.AddInParameter(dbCommand, "ncd_10", DbType.String, string.IsNullOrEmpty(medical.ncd_10) ? "" : medical.ncd_10);
                db.AddInParameter(dbCommand, "ncd_11", DbType.String, string.IsNullOrEmpty(medical.ncd_11) ? "" : medical.ncd_11);
                db.AddInParameter(dbCommand, "ncd_12", DbType.String, string.IsNullOrEmpty(medical.ncd_12) ? "" : medical.ncd_12);
                db.AddInParameter(dbCommand, "ncd_13", DbType.String, string.IsNullOrEmpty(medical.ncd_13) ? "" : medical.ncd_13);
                db.AddInParameter(dbCommand, "ncd_14", DbType.String, string.IsNullOrEmpty(medical.ncd_14) ? "" : medical.ncd_14);
                db.AddInParameter(dbCommand, "ncd_15", DbType.String, string.IsNullOrEmpty(medical.ncd_15) ? "" : medical.ncd_15);
                db.AddInParameter(dbCommand, "ncd_16", DbType.String, string.IsNullOrEmpty(medical.ncd_16) ? "" : medical.ncd_16);
                db.AddInParameter(dbCommand, "ncd_17", DbType.String, string.IsNullOrEmpty(medical.ncd_17) ? "" : medical.ncd_17);
                db.AddInParameter(dbCommand, "ncd_18", DbType.String, string.IsNullOrEmpty(medical.ncd_18) ? "" : medical.ncd_18);
                db.AddInParameter(dbCommand, "ncd_19", DbType.String, string.IsNullOrEmpty(medical.ncd_19) ? "" : medical.ncd_19);
                db.AddInParameter(dbCommand, "ncd_20", DbType.String, string.IsNullOrEmpty(medical.ncd_20) ? "" : medical.ncd_20);
                db.AddInParameter(dbCommand, "ncd_21", DbType.String, string.IsNullOrEmpty(medical.ncd_21) ? "" : medical.ncd_21);
                db.AddInParameter(dbCommand, "ncd_22", DbType.String, string.IsNullOrEmpty(medical.ncd_22) ? "" : medical.ncd_22);
                db.AddInParameter(dbCommand, "ncd_23", DbType.String, string.IsNullOrEmpty(medical.ncd_23) ? "" : medical.ncd_23);
                db.AddInParameter(dbCommand, "ncd_24", DbType.String, string.IsNullOrEmpty(medical.ncd_24) ? "" : medical.ncd_24);
                db.AddInParameter(dbCommand, "ncd_25", DbType.String, string.IsNullOrEmpty(medical.ncd_25) ? "" : medical.ncd_25);
                db.AddInParameter(dbCommand, "ncd_26", DbType.String, string.IsNullOrEmpty(medical.ncd_26) ? "" : medical.ncd_26);
                db.AddInParameter(dbCommand, "ncd_27", DbType.String, string.IsNullOrEmpty(medical.ncd_27) ? "" : medical.ncd_27);

                db.AddInParameter(dbCommand, "ncd_made_by", DbType.Int32, madeby);

                SqlParameter rtnvalue = new SqlParameter("@ncdId", SqlDbType.Int);

                rtnvalue.Direction = ParameterDirection.ReturnValue;

                int _ncdId = db.ExecuteNonQuery(dbCommand);

                return _ncdId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteNeuronDentalForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Neuron_Claim_Dental_Delete");

                db.AddInParameter(dbCommand, "ncd_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ncd_made_by", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetNeuronDentalFormPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Neuron_Claim_Dental_PreviousHistory");

                db.AddInParameter(dbCommand, "ncd_appId", DbType.Int32, appId);
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
