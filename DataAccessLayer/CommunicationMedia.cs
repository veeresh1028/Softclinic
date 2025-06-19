using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Marketing;

namespace DataAccessLayer
{
    public class CommunicationMedia
    {
        public static DataTable GetTemplates(int? templateId, int? tempFor)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_All_Templates");
                if (templateId > 0)
                {
                    db.AddInParameter(dbCommand, "TemplateId", DbType.Int32, templateId);
                }

                if (tempFor > 0)
                {
                    db.AddInParameter(dbCommand, "TempFor", DbType.Int32, tempFor);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetTemplateParameters(int templateId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_All_Template_Parameters");
                if (templateId > 0)
                {
                    db.AddInParameter(dbCommand, "TemplateId", DbType.Int32, templateId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void WhatsappConfig(int? empId, int? branchId, out string wa_instance, out string wa_token)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_WhatsappConfig");

                if (empId > 0)
                {
                    db.AddInParameter(dbCommand, "EmpId", DbType.Int32, empId);
                }

                if (branchId > 0)
                {
                    db.AddInParameter(dbCommand, "BranchId", DbType.Int32, branchId);
                }

                db.AddOutParameter(dbCommand, "WhatsappInstance", DbType.String, 100);
                db.AddOutParameter(dbCommand, "WhatsappToken", DbType.String, 100);

                db.ExecuteNonQuery(dbCommand);

                wa_instance = db.GetParameterValue(dbCommand, "WhatsappInstance").ToString();
                wa_token = db.GetParameterValue(dbCommand, "WhatsappToken").ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SMSConfig(int branchId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SMSConfig");
                db.AddInParameter(dbCommand, "BranchId", DbType.Int32, branchId);
                return db.ExecuteDataSet(dbCommand).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SendingMessageAudit(string type, int receiverId, string receiver, string receiverAccount, int sendBy, bool status, string response, int referenceNo, string referenceType)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SMSEmailWhatsapp_Audit");

                db.AddInParameter(dbCommand, "SEW_Type", DbType.String, type);
                db.AddInParameter(dbCommand, "SEW_ReceiverId", DbType.Int32, receiverId);
                db.AddInParameter(dbCommand, "SEW_ReceiverType", DbType.String, receiver);
                db.AddInParameter(dbCommand, "SEW_ReceiverAccount", DbType.String, receiverAccount);
                db.AddInParameter(dbCommand, "SEW_SendBy", DbType.Int32, sendBy);
                db.AddInParameter(dbCommand, "SEW_Status", DbType.Boolean, status);
                db.AddInParameter(dbCommand, "SEW_Response", DbType.String, response);
                db.AddInParameter(dbCommand, "SEW_ReferenceNo", DbType.Int32, (referenceNo == 0) ? 0 : referenceNo);
                db.AddInParameter(dbCommand, "SEW_ReferenceType", DbType.String, string.IsNullOrEmpty(referenceType) ? "" : referenceType);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool isMediaEnabled(string value, string type, int id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SendMediaEnabled");

                db.AddInParameter(dbCommand, "CM_Value", DbType.String, value);
                db.AddInParameter(dbCommand, "CMS_Type", DbType.String, type);
                db.AddInParameter(dbCommand, "CMS_UserId", DbType.Int32, id);
                db.AddOutParameter(dbCommand, "CMSId", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                if (Convert.ToInt32(db.GetParameterValue(dbCommand, "CMSId")) > 0) { return true; }
                else { return false; }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable TemplateParameters_ByDB(int? appId, int? patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TemplateParameters_ByDB");
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "AppId", DbType.Int32, appId);
                }

                if (patId > 0)
                {
                    db.AddInParameter(dbCommand, "PatId", DbType.Int32, patId);
                }
                return db.ExecuteDataSet(dbCommand).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable EmailConfig(int templateId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EmailConfig");
                db.AddInParameter(dbCommand, "TemplateId", DbType.Int32, templateId);
                return db.ExecuteDataSet(dbCommand).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}