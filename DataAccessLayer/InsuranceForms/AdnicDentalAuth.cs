using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.InsuranceForms
{
    public class AdnicDentalAuth
    {
        public static DataTable GetAdnicDentalAuthData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adnic_Dental_Auth_Select");

                db.AddInParameter(dbCommand, "ada_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int SaveAdnicDentalAuth(BusinessEntities.InsuranceForms.AdnicDentalAuth Dental, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adnic_Dental_Auth_Insert");

                db.AddInParameter(dbCommand, "ada_appId", DbType.Int32, Dental.ada_appId);
                db.AddInParameter(dbCommand, "ada_diags1", DbType.String, string.IsNullOrEmpty(Dental.ada_diags1) ? "" : Dental.ada_diags1);
                db.AddInParameter(dbCommand, "ada_ser1", DbType.String, string.IsNullOrEmpty(Dental.ada_ser1) ? "" : Dental.ada_ser1);
                db.AddInParameter(dbCommand, "ada_tooth1", DbType.String, string.IsNullOrEmpty(Dental.ada_tooth1) ? "" : Dental.ada_tooth1);
                db.AddInParameter(dbCommand, "ada_code1", DbType.String, string.IsNullOrEmpty(Dental.ada_code1) ? "" : Dental.ada_code1);
                db.AddInParameter(dbCommand, "ada_cost1", DbType.String, string.IsNullOrEmpty(Dental.ada_cost1) ? "" : Dental.ada_cost1);
                db.AddInParameter(dbCommand, "ada_diags2", DbType.String, string.IsNullOrEmpty(Dental.ada_diags2) ? "" : Dental.ada_diags2);
                db.AddInParameter(dbCommand, "ada_ser2", DbType.String, string.IsNullOrEmpty(Dental.ada_ser2) ? "" : Dental.ada_ser2);
                db.AddInParameter(dbCommand, "ada_tooth2", DbType.String, string.IsNullOrEmpty(Dental.ada_tooth2) ? "" : Dental.ada_tooth2);
                db.AddInParameter(dbCommand, "ada_code2", DbType.String, string.IsNullOrEmpty(Dental.ada_code2) ? "" : Dental.ada_code2);
                db.AddInParameter(dbCommand, "ada_cost2", DbType.String, string.IsNullOrEmpty(Dental.ada_cost2) ? "" : Dental.ada_cost2);
                db.AddInParameter(dbCommand, "ada_diags3", DbType.String, string.IsNullOrEmpty(Dental.ada_diags3) ? "" : Dental.ada_diags3);
                db.AddInParameter(dbCommand, "ada_ser3", DbType.String, string.IsNullOrEmpty(Dental.ada_ser3) ? "" : Dental.ada_ser3);
                db.AddInParameter(dbCommand, "ada_tooth3", DbType.String, string.IsNullOrEmpty(Dental.ada_tooth3) ? "" : Dental.ada_tooth3);
                db.AddInParameter(dbCommand, "ada_code3", DbType.String, string.IsNullOrEmpty(Dental.ada_code3) ? "" : Dental.ada_code3);
                db.AddInParameter(dbCommand, "ada_cost3", DbType.String, string.IsNullOrEmpty(Dental.ada_cost3) ? "" : Dental.ada_cost3);
                db.AddInParameter(dbCommand, "ada_diags4", DbType.String, string.IsNullOrEmpty(Dental.ada_diags4) ? "" : Dental.ada_diags4);
                db.AddInParameter(dbCommand, "ada_ser4", DbType.String, string.IsNullOrEmpty(Dental.ada_ser4) ? "" : Dental.ada_ser4);
                db.AddInParameter(dbCommand, "ada_tooth4", DbType.String, string.IsNullOrEmpty(Dental.ada_tooth4) ? "" : Dental.ada_tooth4);
                db.AddInParameter(dbCommand, "ada_code4", DbType.String, string.IsNullOrEmpty(Dental.ada_code4) ? "" : Dental.ada_code4);
                db.AddInParameter(dbCommand, "ada_cost4", DbType.String, string.IsNullOrEmpty(Dental.ada_cost4) ? "" : Dental.ada_cost4);
                db.AddInParameter(dbCommand, "ada_diags5", DbType.String, string.IsNullOrEmpty(Dental.ada_diags5) ? "" : Dental.ada_diags5);
                db.AddInParameter(dbCommand, "ada_ser5", DbType.String, string.IsNullOrEmpty(Dental.ada_ser5) ? "" : Dental.ada_ser5);
                db.AddInParameter(dbCommand, "ada_tooth5", DbType.String, string.IsNullOrEmpty(Dental.ada_tooth5) ? "" : Dental.ada_tooth5);
                db.AddInParameter(dbCommand, "ada_code5", DbType.String, string.IsNullOrEmpty(Dental.ada_code5) ? "" : Dental.ada_code5);
                db.AddInParameter(dbCommand, "ada_cost5", DbType.String, string.IsNullOrEmpty(Dental.ada_cost5) ? "" : Dental.ada_cost5);
                db.AddInParameter(dbCommand, "ada_diags6", DbType.String, string.IsNullOrEmpty(Dental.ada_diags6) ? "" : Dental.ada_diags6);
                db.AddInParameter(dbCommand, "ada_ser6", DbType.String, string.IsNullOrEmpty(Dental.ada_ser6) ? "" : Dental.ada_ser6);
                db.AddInParameter(dbCommand, "ada_tooth6", DbType.String, string.IsNullOrEmpty(Dental.ada_tooth6) ? "" : Dental.ada_tooth6);
                db.AddInParameter(dbCommand, "ada_code6", DbType.String, string.IsNullOrEmpty(Dental.ada_code6) ? "" : Dental.ada_code6);
                db.AddInParameter(dbCommand, "ada_cost6", DbType.String, string.IsNullOrEmpty(Dental.ada_cost6) ? "" : Dental.ada_cost6);
                db.AddInParameter(dbCommand, "ada_treat_tot", DbType.String, string.IsNullOrEmpty(Dental.ada_treat_tot) ? "" : Dental.ada_treat_tot);
                db.AddInParameter(dbCommand, "ada_doc_no", DbType.String, string.IsNullOrEmpty(Dental.ada_doc_no) ? "" : Dental.ada_doc_no);
                db.AddInParameter(dbCommand, "ada_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "adaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _adaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "adaId"));
                return _adaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteAdnicDentalAuth(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adnic_Dental_Auth_Delete");

                db.AddInParameter(dbCommand, "ada_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ada_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ada_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ada_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ada_output"));

                return _ada_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetAdnicDentalAuthPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adnic_Dental_Auth_PreviousHistory");

                db.AddInParameter(dbCommand, "ada_appId", DbType.Int32, appId);
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
