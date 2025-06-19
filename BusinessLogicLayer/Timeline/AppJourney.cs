using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Timeline
{
    public class AppJourney
    {
        public static BusinessEntities.Timeline.AppJourneyData GetAppJourney(int appId)
        {
            BusinessEntities.Timeline.AppJourneyData data = new BusinessEntities.Timeline.AppJourneyData();
            try
            {
                DataSet ds = DataAccessLayer.Timeline.AppJourney.GetAppJourney(appId);

                if (ds.Tables.Count > 0)
                {
                    List<BusinessEntities.Timeline.AppJourney> BookStage = new List<BusinessEntities.Timeline.AppJourney>();
                    List<BusinessEntities.Timeline.AppJourney> FrontDeskStage = new List<BusinessEntities.Timeline.AppJourney>();
                    List<BusinessEntities.Timeline.AppJourney> NurseStationStage = new List<BusinessEntities.Timeline.AppJourney>();
                    List<BusinessEntities.Timeline.AppJourney> DoctorStationStage = new List<BusinessEntities.Timeline.AppJourney>();
                    List<BusinessEntities.Timeline.AppJourney> BillingStage = new List<BusinessEntities.Timeline.AppJourney>();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        data.CurrentIndex = int.Parse(ds.Tables[0].Rows[0]["CurrentIndex"].ToString());
                        data.PatientName = ds.Tables[0].Rows[0]["pat_name"].ToString();
                        data.MRN = ds.Tables[0].Rows[0]["pat_code"].ToString();
                        data.Mobile = ds.Tables[0].Rows[0]["pat_mob"].ToString();
                        data.DOB = DateTime.Parse(ds.Tables[0].Rows[0]["pat_dob"].ToString()).ToString("dd/MM/yyyy");
                        data.Gender = ds.Tables[0].Rows[0]["pat_gender"].ToString();

                        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["pat_photo"].ToString()))
                        {
                            //data.Photo = string.Format("data:image/png;base64,{0}", ds.Tables[0].Rows[0]["pat_photo"].ToString());
                            data.Photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/patient_images/" + ds.Tables[0].Rows[0]["pat_photo"].ToString();
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[0]["pat_gender"].ToString().ToLower().StartsWith("f"))
                            {
                                data.Photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-female.jpg";
                            }
                            else
                            {
                                data.Photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";
                            }
                        }
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            BusinessEntities.Timeline.AppJourney appJourney = new BusinessEntities.Timeline.AppJourney();
                            appJourney.CategoryId = int.Parse(dr["CategoryId"].ToString());
                            appJourney.CategoryName = dr["CategoryName"].ToString();
                            appJourney.SubCategoryId = int.Parse(dr["SubCategoryId"].ToString());
                            appJourney.SubCategoryName = dr["SubCategoryName"].ToString();
                            appJourney.isCompleted = bool.Parse(dr["isCompleted"].ToString());
                            appJourney.PatId = int.Parse(dr["PatId"].ToString());
                            appJourney.Status = dr["Status"].ToString();
                            appJourney.TimeStamp = DateTime.Parse(dr["TimeStamp"].ToString());
                            BookStage.Add(appJourney);
                        }

                        data.BookStage = BookStage;
                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[2].Rows)
                        {
                            BusinessEntities.Timeline.AppJourney appJourney = new BusinessEntities.Timeline.AppJourney();
                            appJourney.CategoryId = int.Parse(dr["CategoryId"].ToString());
                            appJourney.CategoryName = dr["CategoryName"].ToString();
                            appJourney.SubCategoryId = int.Parse(dr["SubCategoryId"].ToString());
                            appJourney.SubCategoryName = dr["SubCategoryName"].ToString();
                            appJourney.isCompleted = bool.Parse(dr["isCompleted"].ToString());
                            appJourney.PatId = int.Parse(dr["PatId"].ToString());
                            appJourney.Status = dr["Status"].ToString();
                            appJourney.TimeStamp = DateTime.Parse(dr["TimeStamp"].ToString());
                            FrontDeskStage.Add(appJourney);
                        }
                        data.FrontDeskStage = FrontDeskStage;
                    }

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[3].Rows)
                        {
                            BusinessEntities.Timeline.AppJourney appJourney = new BusinessEntities.Timeline.AppJourney();
                            appJourney.CategoryId = int.Parse(dr["CategoryId"].ToString());
                            appJourney.CategoryName = dr["CategoryName"].ToString();
                            appJourney.SubCategoryId = int.Parse(dr["SubCategoryId"].ToString());
                            appJourney.SubCategoryName = dr["SubCategoryName"].ToString();
                            appJourney.isCompleted = bool.Parse(dr["isCompleted"].ToString());
                            appJourney.PatId = int.Parse(dr["PatId"].ToString());
                            appJourney.Status = dr["Status"].ToString();
                            appJourney.TimeStamp = DateTime.Parse(dr["TimeStamp"].ToString());
                            NurseStationStage.Add(appJourney);
                        }
                        data.NurseStationStage = NurseStationStage;
                    }

                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[4].Rows)
                        {
                            BusinessEntities.Timeline.AppJourney appJourney = new BusinessEntities.Timeline.AppJourney();
                            appJourney.CategoryId = int.Parse(dr["CategoryId"].ToString());
                            appJourney.CategoryName = dr["CategoryName"].ToString();
                            appJourney.SubCategoryId = int.Parse(dr["SubCategoryId"].ToString());
                            appJourney.SubCategoryName = dr["SubCategoryName"].ToString();
                            appJourney.isCompleted = bool.Parse(dr["isCompleted"].ToString());
                            appJourney.PatId = int.Parse(dr["PatId"].ToString());
                            appJourney.Status = dr["Status"].ToString();
                            appJourney.TimeStamp = DateTime.Parse(dr["TimeStamp"].ToString());
                            DoctorStationStage.Add(appJourney);
                        }
                        data.DoctorStationStage = DoctorStationStage;
                    }

                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[5].Rows)
                        {
                            BusinessEntities.Timeline.AppJourney appJourney = new BusinessEntities.Timeline.AppJourney();
                            appJourney.CategoryId = int.Parse(dr["CategoryId"].ToString());
                            appJourney.CategoryName = dr["CategoryName"].ToString();
                            appJourney.SubCategoryId = int.Parse(dr["SubCategoryId"].ToString());
                            appJourney.SubCategoryName = dr["SubCategoryName"].ToString();
                            appJourney.isCompleted = bool.Parse(dr["isCompleted"].ToString());
                            appJourney.PatId = int.Parse(dr["PatId"].ToString());
                            appJourney.Status = dr["Status"].ToString();
                            appJourney.TimeStamp = DateTime.Parse(dr["TimeStamp"].ToString());
                            BillingStage.Add(appJourney);
                        }
                        data.BillingStage = BillingStage;
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<CommonDDL> SearchJourney(string query)
        {
            DataTable dt = DataAccessLayer.Timeline.AppJourney.SearchJourney(query);
            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }
    }
}
