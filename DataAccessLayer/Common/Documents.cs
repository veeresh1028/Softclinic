using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Common
{
    public class Documents
    {

        public static bool UploadDocument(BusinessEntities.Common.DocumentUpload doc)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DocumentUpload");

                db.AddInParameter(dbCommand, "doc_refId", DbType.Int32, doc.doc_refId);                
                db.AddInParameter(dbCommand, "doc_reftype", DbType.String, doc.doc_reftype);
                db.AddInParameter(dbCommand, "doc_label", DbType.String, doc.doc_label);
                db.AddInParameter(dbCommand, "doc_name", DbType.String, doc.doc_name);
                db.AddInParameter(dbCommand, "doc_ext", DbType.String, doc.doc_ext);
                db.AddInParameter(dbCommand, "doc_path", DbType.String, doc.doc_path);
                db.AddInParameter(dbCommand, "doc_uploadedBy", DbType.Int32, doc.doc_uploadedBy);
                db.AddInParameter(dbCommand, "doc_category", DbType.String, doc.doc_category);
                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
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
        public static DataTable GetDocumentsById(int id, int type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetDocumentsById");

                db.AddInParameter(dbCommand, "id", DbType.Int32, id);
                db.AddInParameter(dbCommand, "type", DbType.Int32, type);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetPreviousDocumentsById(int id, int type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Previous_DocumentsById");

                db.AddInParameter(dbCommand, "id", DbType.Int32, id);
                db.AddInParameter(dbCommand, "type", DbType.Int32, type);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool DeleteDocuments(int docId, int madeBy)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_UploadedDocuments_Delete");

                db.AddInParameter(dbCommand, "docId", DbType.Int32, docId);
                db.AddInParameter(dbCommand, "doc_employee", DbType.Int32, madeBy);
                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
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
    }
}
