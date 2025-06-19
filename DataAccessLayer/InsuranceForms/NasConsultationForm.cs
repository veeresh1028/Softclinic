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
    public class NasConsultationForm
    {
        public static DataTable GetNasConsultationFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Nas_Consultation_Form_Select");

                db.AddInParameter(dbCommand, "ncf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveNasConsultationForm(BusinessEntities.InsuranceForms.NasConsultationForm medical, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Nas_Consultation_Form_Insert");

                db.AddInParameter(dbCommand, "ncf_appId", DbType.Int32, medical.ncf_appId);
                db.AddInParameter(dbCommand, "ncf_1", DbType.String, string.IsNullOrEmpty(medical.ncf_1) ? "" : medical.ncf_1);
                db.AddInParameter(dbCommand, "ncf_2", DbType.String, string.IsNullOrEmpty(medical.ncf_2) ? "" : medical.ncf_2);
                db.AddInParameter(dbCommand, "ncf_3", DbType.String, string.IsNullOrEmpty(medical.ncf_3) ? "" : medical.ncf_3);
                db.AddInParameter(dbCommand, "ncf_chk", DbType.String, string.IsNullOrEmpty(medical.ncf_chk) ? "" : medical.ncf_chk);
                db.AddInParameter(dbCommand, "ncf_radio", DbType.String, string.IsNullOrEmpty(medical.ncf_radio) ? "" : medical.ncf_radio);

                db.AddInParameter(dbCommand, "ncf_made_by", DbType.Int32, madeby);

                SqlParameter rtnvalue = new SqlParameter("@ncfId", SqlDbType.Int);

                rtnvalue.Direction = ParameterDirection.ReturnValue;

                int _ncfId = db.ExecuteNonQuery(dbCommand);

                return _ncfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteNasConsultationForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Nas_Consultation_Form_Delete");

                db.AddInParameter(dbCommand, "ncf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ncf_made_by", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetNasConsultationFormPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Nas_Consultation_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "ncf_appId", DbType.Int32, appId);
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
