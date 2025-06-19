using BusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Common
{
    public class Documents
    {
        public static bool UploadDocument(BusinessEntities.Common.DocumentUpload doc)
        {
            doc.doc_category = string.IsNullOrEmpty(doc.doc_category) ? string.Empty : doc.doc_category;
            return DataAccessLayer.Common.Documents.UploadDocument(doc);
        }

        public static List<DocumentUpload> GetDocumentsById(int id, int type, string http_path)
        {
            try
            {
                List<DocumentUpload> documents = new List<DocumentUpload>();

                DataTable dt = DataAccessLayer.Common.Documents.GetDocumentsById(id, type);

                foreach (DataRow d in dt.Rows)
                {
                    DocumentUpload _d = new DocumentUpload();
                    _d.docId = int.Parse(d["docId"].ToString());
                    _d.doc_refId = int.Parse(d["doc_refId"].ToString());
                    _d.doc_reftype = d["doc_reftype"].ToString();
                    _d.doc_label = d["doc_label"].ToString();
                    _d.doc_name = d["doc_name"].ToString();
                    _d.doc_ext = d["doc_ext"].ToString();

                    string[] path;
                    if (type == 4)
                    {
                        path = d["doc_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/uploaded_documents" }, StringSplitOptions.None);
                    }
                    else
                    {
                        path = d["doc_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/uploaded_documents" }, StringSplitOptions.None);
                    }


                    _d.doc_path = http_path.Trim().ToString() + "images/uploaded_documents" + path[1].Trim().ToString();
                    _d.doc_status = d["doc_status"].ToString();
                    _d.doc_datecreated = DateTime.Parse(d["doc_datecreated"].ToString());
                    _d.doc_uploadedBy = int.Parse(d["doc_uploadedBy"].ToString());
                    _d.doc_uploadedBy_name = d["doc_uploadedBy_name"].ToString();
                    _d.doc_category = d["doc_category"].ToString();
                    documents.Add(_d);
                }

                return documents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<DocumentUpload> GetPreviousDocumentsById(int id, int type, string http_path)
        {
            List<DocumentUpload> documents = new List<DocumentUpload>();

            DataTable dt = DataAccessLayer.Common.Documents.GetPreviousDocumentsById(id, type);

            foreach (DataRow d in dt.Rows)
            {
                DocumentUpload _d = new DocumentUpload();
                _d.docId = int.Parse(d["docId"].ToString());
                _d.doc_refId = int.Parse(d["doc_refId"].ToString());
                _d.doc_reftype = d["doc_reftype"].ToString();
                _d.doc_label = d["doc_label"].ToString();
                _d.doc_name = d["doc_name"].ToString();
                _d.doc_ext = d["doc_ext"].ToString();

                string[] path;
                if (type == 4)
                {
                    path = d["doc_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/uploaded_documents" }, StringSplitOptions.None);
                }
                else
                {
                    path = d["doc_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/uploaded_documents" }, StringSplitOptions.None);
                }


                _d.doc_path = http_path.Trim().ToString() + "images/uploaded_documents" + path[1].Trim().ToString();
                _d.doc_status = d["doc_status"].ToString();
                _d.doc_datecreated = DateTime.Parse(d["doc_datecreated"].ToString());
                _d.doc_uploadedBy = int.Parse(d["doc_uploadedBy"].ToString());
                _d.doc_uploadedBy_name = d["doc_uploadedBy_name"].ToString();
                _d.emp_license = d["emp_license"].ToString();
                _d.doctor_name = d["doctor_name"].ToString();
                _d.app_fdate = Convert.ToDateTime(d["app_fdate"].ToString());
                _d.doc_category = d["doc_category"].ToString();
                documents.Add(_d);
            }

            return documents;
        }
        public static bool DeleteDocuments(int docId, int madeBy)
        {
            return DataAccessLayer.Common.Documents.DeleteDocuments(docId, madeBy);
        }
    }
}
