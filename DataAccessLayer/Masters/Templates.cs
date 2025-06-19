using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Masters
{
    public class Templates
    {
        #region Message Templates (Page Load)
        public static DataTable GetTemplates(int? TemplateId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TEMPLATE_Select_all_info");
                if (TemplateId > 0)
                {
                    db.AddInParameter(dbCommand, "TemplateId", DbType.Int32, TemplateId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Message Templates CRUD Operations
        public static bool InsertUpdateTemplate(BusinessEntities.Masters.Templates data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TEMPLATE_INSERT_UPDATE");

                if (data.TemplateId > 0)
                {
                    db.AddInParameter(dbCommand, "TemplateId", DbType.Int32, data.TemplateId);
                }

                db.AddInParameter(dbCommand, "TempName", DbType.String, string.IsNullOrEmpty(data.TempName) ? string.Empty : data.TempName);
                db.AddInParameter(dbCommand, "TempContent", DbType.String, string.IsNullOrEmpty(data.TempContent) ? string.Empty : data.TempContent);
                db.AddInParameter(dbCommand, "TempFor", DbType.String, string.IsNullOrEmpty(data.TempFor) ? string.Empty : data.TempFor);
                db.AddInParameter(dbCommand, "TempWhatsapp", DbType.Int32, data.TempWhatsapp);
                db.AddInParameter(dbCommand, "TempSMS", DbType.Int32, data.TempSMS);
                db.AddInParameter(dbCommand, "TempEmail", DbType.Int32, data.TempEmail);
                db.AddInParameter(dbCommand, "TempCreatedBy", DbType.Int32, data.TempCreatedBy);
                db.AddInParameter(dbCommand, "TempUpdatedBy", DbType.Int32, data.TempCreatedBy);
                db.AddInParameter(dbCommand, "TParamKey", DbType.String, string.IsNullOrEmpty(data.TParamKey) ? string.Empty : data.TParamKey);
                db.AddInParameter(dbCommand, "TParamType", DbType.String, string.IsNullOrEmpty(data.TParamType) ? string.Empty : data.TParamType);
                db.AddInParameter(dbCommand, "TParamValue", DbType.String, string.IsNullOrEmpty(data.TParamValue) ? string.Empty : data.TParamValue);
                db.AddOutParameter(dbCommand, "TParamoutput", DbType.Int32, 0);

                db.ExecuteNonQuery(dbCommand);

                int val = Convert.ToInt32(db.GetParameterValue(dbCommand, "TParamoutput").ToString());

                if (val > 0)
                {
                    string t1_value = data.TParamKey;
                    string[] values = t1_value.Split(' ').ToArray();
                    int count = 0;

                    if (values != null)
                    {
                        foreach (string teeth in values)
                        {
                            count = count + 1;
                            DatabaseProviderFactory factory1 = new DatabaseProviderFactory();
                            Database db1 = factory1.CreateDefault();
                            DbCommand dbCommand1 = db1.GetStoredProcCommand("SP_Template_Parameters_INSERT_UPDATE");

                            db1.AddInParameter(dbCommand1, "TemplateId", DbType.Int32, val);
                            db1.AddInParameter(dbCommand1, "TParamCreatedBy", DbType.Int32, data.TempCreatedBy);
                            db1.AddInParameter(dbCommand1, "TParamUpdatedBy", DbType.Int32, data.TempCreatedBy);
                            db1.AddInParameter(dbCommand1, "TParamValue", DbType.String, teeth);
                            db1.AddInParameter(dbCommand1, "TParamKeyNo", DbType.String, count);
                            
                            int result1 = db1.ExecuteNonQuery(dbCommand1);
                        }
                    }
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

        public static int UpdateTemplateStatus(int TemplateId, string TempStatus)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TEMPLATE_update_status");

                db.AddInParameter(dbCommand, "TemplateId", DbType.Int32, TemplateId);
                db.AddInParameter(dbCommand, "TempStatus", DbType.String, TempStatus);
                db.AddOutParameter(dbCommand, "Tempoutput", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "Tempoutput").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}