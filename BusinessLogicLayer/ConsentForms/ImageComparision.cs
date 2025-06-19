using BusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ImageComparision
    {
        public static List<BusinessEntities.ConsentForms.ImageComparision> GetImageComparisionData(int appId, int? trsId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ImageComparision.GetImageComparisionData(appId, trsId);
            List<BusinessEntities.ConsentForms.ImageComparision> list = new List<BusinessEntities.ConsentForms.ImageComparision>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ImageComparision
                {
                    cicId = Convert.ToInt32(dr["cicId"]),
                    cic_appId = Convert.ToInt32(dr["cic_appId"]),
                    cic_title = dr["cic_title"].ToString(),
                    cic_discription = dr["cic_discription"].ToString(),
                    cic_doc = dr["cic_doc"].ToString(),
                    cic_date_modified = Convert.ToDateTime(dr["cic_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveImageComparision(BusinessEntities.ConsentForms.ImageComparision image, int madeby)
        {
            return DataAccessLayer.ConsentForms.ImageComparision.SaveImageComparision(image, madeby);
        }
        public static int DeleteImageComparision(int cicId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ImageComparision.DeleteImageComparision(cicId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetImageComparisionPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ImageComparision.GetImageComparisionPreviousHistory(appId);
            List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> list = new List<BusinessEntities.ConcentForms.ConcentPreviousHistroy>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ConcentPreviousHistroy
                {
                    formId = Convert.ToInt32(dr["formId"]),
                    appId = Convert.ToInt32(dr["appId"]),
                    emp_license = dr["emp_license"].ToString(),
                    emp_name = dr["emp_name"].ToString() + " " + dr["emp_lname"].ToString(),
                    emp_dept_name = dr["emp_dept_name"].ToString(),
                    app_fdate = DateTime.Parse(dr["app_fdate"].ToString()).ToString("dd-MMM-yyyy") + " " + dr["app_doc_ftime"].ToString() + " - " + dr["app_doc_ttime"].ToString()
                });
            }
            return list;
        }




        //public static bool SaveImageComparision(BusinessEntities.ConsentForms.ImageComparision image)
        //{
        //    image.cic_category = string.IsNullOrEmpty(image.cic_category) ? string.Empty : image.cic_category;
        //    return DataAccessLayer.ConsentForms.ImageComparision.SaveImageComparision(image);
        //}

        //public static List<BusinessEntities.ConsentForms.ImageComparision> GetImageComparisionData(int id, int type, string http_path)
        //{
        //    try
        //    {
        //        List<BusinessEntities.ConsentForms.ImageComparision> imageComparisionList = new List<BusinessEntities.ConsentForms.ImageComparision>();

        //        DataTable dt = DataAccessLayer.ConsentForms.ImageComparision.GetImageComparisionData(id, type);

        //        foreach (DataRow i in dt.Rows)
        //        {
        //            BusinessEntities.ConsentForms.ImageComparision _i = new BusinessEntities.ConsentForms.ImageComparision();
        //            _i.cicId = int.Parse(i["cicId"].ToString());
        //            _i.cic_refId = int.Parse(i["cic_refId"].ToString());
        //            _i.cic_reftype = i["cic_reftype"].ToString();
        //            _i.cic_label = i["cic_label"].ToString();
        //            _i.cic_1 = i["cic_1"].ToString();
        //            _i.cic_name = i["cic_name"].ToString();
        //            _i.cic_ext = i["cic_ext"].ToString();

        //            string[] path;
        //            if (type == 4)
        //            {
        //                path = i["cic_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/ConsentForms/SavedImages/uploaded_ImageComparision" }, StringSplitOptions.None);
        //            }
        //            else
        //            {
        //                path = i["cic_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/ConsentForms/SavedImages/uploaded_ImageComparision" }, StringSplitOptions.None);
        //            }


        //            _i.cic_path = http_path.Trim().ToString() + "images/ConsentForms/SavedImages/uploaded_ImageComparision" + path[1].Trim().ToString();
        //            _i.cic_status = i["cic_status"].ToString();
        //            _i.cic_datecreated = DateTime.Parse(i["cic_datecreated"].ToString());
        //            _i.cic_uploadedBy = int.Parse(i["cic_uploadedBy"].ToString());
        //            _i.cic_uploadedBy_name = i["cic_uploadedBy_name"].ToString();
        //            _i.cic_category = i["cic_category"].ToString();
        //            imageComparisionList.Add(_i);
        //        }

        //        return imageComparisionList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static List<BusinessEntities.ConsentForms.ImageComparision> GetImageComparisionPreviousHistory(int id, int type, string http_path)
        //{
        //    List<BusinessEntities.ConsentForms.ImageComparision> imageComparisionList = new List<BusinessEntities.ConsentForms.ImageComparision>();

        //    DataTable dt = DataAccessLayer.ConsentForms.ImageComparision.GetImageComparisionPreviousHistory(id, type);

        //    foreach (DataRow i in dt.Rows)
        //    {
        //        BusinessEntities.ConsentForms.ImageComparision _i = new BusinessEntities.ConsentForms.ImageComparision();
        //        _i.cicId = int.Parse(i["cicId"].ToString());
        //        _i.cic_refId = int.Parse(i["cic_refId"].ToString());
        //        _i.cic_reftype = i["cic_reftype"].ToString();
        //        _i.cic_label = i["cic_label"].ToString();
        //        _i.cic_1 = i["cic_1"].ToString();
        //        _i.cic_name = i["cic_name"].ToString();
        //        _i.cic_ext = i["cic_ext"].ToString();

        //        string[] path;
        //        if (type == 4)
        //        {
        //            path = i["cic_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/ConsentForms/SavedImages/uploaded_ImageComparision" }, StringSplitOptions.None);
        //        }
        //        else
        //        {
        //            path = i["cic_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/ConsentForms/SavedImages/uploaded_ImageComparision" }, StringSplitOptions.None);
        //        }


        //        _i.cic_path = http_path.Trim().ToString() + "images/ConsentForms/SavedImages/uploaded_ImageComparision" + path[1].Trim().ToString();
        //        _i.cic_status = i["cic_status"].ToString();
        //        _i.cic_datecreated = DateTime.Parse(i["cic_datecreated"].ToString());
        //        _i.cic_uploadedBy = int.Parse(i["cic_uploadedBy"].ToString());
        //        _i.cic_uploadedBy_name = i["cic_uploadedBy_name"].ToString();
        //        _i.emp_license = i["emp_license"].ToString();
        //        _i.doctor_name = i["doctor_name"].ToString();
        //        _i.app_fdate = Convert.ToDateTime(i["app_fdate"].ToString());
        //        _i.cic_category = i["cic_category"].ToString();
        //        imageComparisionList.Add(_i);
        //    }

        //    return imageComparisionList;
        //}
        //public static bool DeleteImageComparision(int cicId, int madeBy)
        //{
        //    return DataAccessLayer.ConsentForms.ImageComparision.DeleteImageComparision(cicId, madeBy);
        //}
    }
}
