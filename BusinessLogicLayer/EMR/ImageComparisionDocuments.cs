using BusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class ImageComparisionDocuments
    {

        public static List<BusinessEntities.EMR.ImageComparisionDocuments> GetImageComparisionDocumentsById(int id)
        {
            DataTable dt = DataAccessLayer.EMR.ImageComparisionDocuments.GetImageComparisionDocumentsById(id);
            List<BusinessEntities.EMR.ImageComparisionDocuments> list = new List<BusinessEntities.EMR.ImageComparisionDocuments>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.EMR.ImageComparisionDocuments
                {
                    imgcId = Convert.ToInt32(dr["imgcId"]),
                    imgc_patId = Convert.ToInt32(dr["imgc_patId"]),
                    imgc_appId = Convert.ToInt32(dr["imgc_appId"]),
                    imgc_notes = dr["imgc_notes"].ToString(),
                    imgc_image = dr["imgc_image"].ToString(),
                    imgc_type = dr["imgc_type"].ToString(),
                    imgc_status = dr["imgc_status"].ToString(),
                    imgc_date_created = Convert.ToDateTime(dr["imgc_date_created"].ToString()),
                });
            }
            return list;
        }
        public static List<BusinessEntities.EMR.ImageComparisionDocuments> GetPrevImageComparisionDocumentsById(int id,int patId)
        {
            DataTable dt = DataAccessLayer.EMR.ImageComparisionDocuments.GetPrevImageComparisionDocumentsById(id, patId);
            List<BusinessEntities.EMR.ImageComparisionDocuments> list = new List<BusinessEntities.EMR.ImageComparisionDocuments>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.EMR.ImageComparisionDocuments
                {
                    imgcId = Convert.ToInt32(dr["imgcId"]),
                    imgc_patId = Convert.ToInt32(dr["imgc_patId"]),
                    imgc_appId = Convert.ToInt32(dr["imgc_appId"]),
                    imgc_notes = dr["imgc_notes"].ToString(),
                    imgc_image = dr["imgc_image"].ToString(),
                    imgc_type = dr["imgc_type"].ToString(),
                    imgc_status = dr["imgc_status"].ToString(),
                    imgc_date_created = Convert.ToDateTime(dr["imgc_date_created"].ToString()),
                });
            }
            return list;
        }
        public static bool SaveImageComparisionDocuments(BusinessEntities.EMR.ImageComparisionDocuments image, int madeby)
        {
            return DataAccessLayer.EMR.ImageComparisionDocuments.SaveImageComparisionDocuments(image, madeby);
        }
        public static bool DeleteImageComparisionDocuments(int imgcId, int madeby)
        {
            return DataAccessLayer.EMR.ImageComparisionDocuments.DeleteImageComparisionDocuments(imgcId, madeby);
        }





























        //public static bool SaveImageComparisionDocuments(BusinessEntities.EMR.ImageComparisionDocuments doc)
        //{
        //    doc.doc_category = string.IsNullOrEmpty(doc.doc_category) ? string.Empty : doc.doc_category;
        //    return DataAccessLayer.EMR.ImageComparisionDocuments.SaveImageComparisionDocuments(doc);
        //}

        //public static List<BusinessEntities.EMR.ImageComparisionDocuments> GetDocumentsById(int id, int type, string http_path)
        //{
        //    try
        //    {
        //        List<BusinessEntities.EMR.ImageComparisionDocuments> image = new List<BusinessEntities.EMR.ImageComparisionDocuments>();

        //        DataTable dt = DataAccessLayer.EMR.ImageComparisionDocuments.GetDocumentsById(id, type);

        //        foreach (DataRow d in dt.Rows)
        //        {
        //            BusinessEntities.EMR.ImageComparisionDocuments _d = new BusinessEntities.EMR.ImageComparisionDocuments();
        //            _d.docId = int.Parse(d["docId"].ToString());
        //            _d.doc_refId = int.Parse(d["doc_refId"].ToString());
        //            _d.doc_reftype = d["doc_reftype"].ToString();
        //            _d.doc_label = d["doc_label"].ToString();
        //            _d.doc_name = d["doc_name"].ToString();
        //            _d.doc_ext = d["doc_ext"].ToString();

        //            string[] path;
        //            if (type == 4)
        //            {
        //                path = d["doc_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/uploaded_documents" }, StringSplitOptions.None);
        //            }
        //            else
        //            {
        //                path = d["doc_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/uploaded_documents" }, StringSplitOptions.None);
        //            }


        //            _d.doc_path = http_path.Trim().ToString() + "images/uploaded_documents" + path[1].Trim().ToString();
        //            _d.doc_status = d["doc_status"].ToString();
        //            _d.doc_datecreated = DateTime.Parse(d["doc_datecreated"].ToString());
        //            _d.doc_uploadedBy = int.Parse(d["doc_uploadedBy"].ToString());
        //            _d.doc_uploadedBy_name = d["doc_uploadedBy_name"].ToString();
        //            _d.doc_category = d["doc_category"].ToString();
        //            image.Add(_d);
        //        }

        //        return image;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public static List<BusinessEntities.EMR.ImageComparisionDocuments> GetPreviousImageComparisionDocumentsId(int id, int type, string http_path)
        //{
        //    List<BusinessEntities.EMR.ImageComparisionDocuments> image = new List<BusinessEntities.EMR.ImageComparisionDocuments>();

        //    DataTable dt = DataAccessLayer.EMR.ImageComparisionDocuments.GetPreviousImageComparisionDocumentsById(id, type);

        //    foreach (DataRow d in dt.Rows)
        //    {
        //        BusinessEntities.EMR.ImageComparisionDocuments _d = new BusinessEntities.EMR.ImageComparisionDocuments();
        //        _d.docId = int.Parse(d["docId"].ToString());
        //        _d.doc_refId = int.Parse(d["doc_refId"].ToString());
        //        _d.doc_reftype = d["doc_reftype"].ToString();
        //        _d.doc_label = d["doc_label"].ToString();
        //        _d.doc_name = d["doc_name"].ToString();
        //        _d.doc_ext = d["doc_ext"].ToString();

        //        string[] path;
        //        if (type == 4)
        //        {
        //            path = d["doc_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/uploaded_documents" }, StringSplitOptions.None);
        //        }
        //        else
        //        {
        //            path = d["doc_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/uploaded_documents" }, StringSplitOptions.None);
        //        }


        //        _d.doc_path = http_path.Trim().ToString() + "images/uploaded_documents" + path[1].Trim().ToString();
        //        _d.doc_status = d["doc_status"].ToString();
        //        _d.doc_datecreated = DateTime.Parse(d["doc_datecreated"].ToString());
        //        _d.doc_uploadedBy = int.Parse(d["doc_uploadedBy"].ToString());
        //        _d.doc_uploadedBy_name = d["doc_uploadedBy_name"].ToString();
        //        _d.emp_license = d["emp_license"].ToString();
        //        _d.doctor_name = d["doctor_name"].ToString();
        //        _d.app_fdate = Convert.ToDateTime(d["app_fdate"].ToString());
        //        _d.doc_category = d["doc_category"].ToString();
        //        image.Add(_d);
        //    }

        //    return image;
        //}
        //public static bool DeleteImageComparisionDocuments(int docId, int madeBy)
        //{
        //    return DataAccessLayer.EMR.ImageComparisionDocuments.DeleteImageComparisionDocuments(docId, madeBy);
        //}


    }
}
