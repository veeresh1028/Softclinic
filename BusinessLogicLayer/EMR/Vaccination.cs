using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class Vaccination
    {
        #region Patient Vaccination (Page Load)
        public static List<BusinessEntities.EMR.Vaccination> GetAllVaccination(int? appId, int? pvId)
        {
            List<BusinessEntities.EMR.Vaccination> sclist = new List<BusinessEntities.EMR.Vaccination>();
            DataTable dt = DataAccessLayer.EMR.Vaccination.GetAllVaccination(appId, pvId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.Vaccination
                {
                    pvId = Convert.ToInt32(dr["pvId"]),
                    pv_appId = Convert.ToInt32(dr["pv_appId"]),
                    pv_vaccination = Convert.ToInt32(dr["pv_vaccination"]),
                    pv_batchno = dr["pv_batchno"].ToString(),
                    pv_notes = dr["pv_notes"].ToString(),
                    pv_manufacturer = dr["pv_manufacturer"].ToString(),
                    pv_exp_date = Convert.ToDateTime(dr["pv_exp_date"].ToString()),
                    pv_date = Convert.ToDateTime(dr["pv_date"].ToString()),
                    pv_status = dr["pv_status"].ToString(),
                    pv_dose = dr["pv_dose"].ToString(),
                    v_code = dr["v_code"].ToString(),
                    v_name = dr["v_name"].ToString(),
                    pv_reminder_notes = dr["pv_reminder_notes"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.Vaccination> GetAllPreVaccination(int appId, int patId)
        {
            List<BusinessEntities.EMR.Vaccination> sclist = new List<BusinessEntities.EMR.Vaccination>();
            DataTable dt = DataAccessLayer.EMR.Vaccination.GetAllPreVaccination(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.Vaccination
                {
                    pvId = Convert.ToInt32(dr["pvId"]),
                    pv_appId = Convert.ToInt32(dr["pv_appId"]),
                    pv_vaccination = Convert.ToInt32(dr["pv_vaccination"]),
                    pv_batchno = dr["pv_batchno"].ToString(),
                    pv_notes = dr["pv_notes"].ToString(),
                    pv_manufacturer = dr["pv_manufacturer"].ToString(),
                    pv_exp_date = Convert.ToDateTime(dr["pv_exp_date"].ToString()),
                    pv_date = Convert.ToDateTime(dr["pv_date"].ToString()),
                    pv_status = dr["pv_status"].ToString(),
                    pv_dose = dr["pv_dose"].ToString(),
                    pv_reminder_notes = dr["pv_reminder_notes"].ToString(),
                    emp_license = dr["emp_license"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    v_code = dr["v_code"].ToString(),
                    v_name = dr["v_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        public static List<GetByName> GetVaccine(string query, string flag)
        {
            DataTable dt = DataAccessLayer.EMR.Vaccination.GetVaccine(query, flag);
            List<GetByName> data = new List<GetByName>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    GetByName _data = new GetByName();
                    _data.id = dr["id"].ToString();
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }
            return data;

        }

        #endregion Patient Vaccination (Page Load)

        #region Patient Vaccination CRUD Operations

        public static bool InsertUpdateVaccination(BusinessEntities.EMR.Vaccination data)
        {
            data.pv_notes = string.IsNullOrEmpty(data.pv_notes) ? string.Empty : data.pv_notes;
            data.pv_batchno = string.IsNullOrEmpty(data.pv_batchno) ? string.Empty : data.pv_batchno;
            data.pv_manufacturer = string.IsNullOrEmpty(data.pv_manufacturer) ? string.Empty : data.pv_manufacturer;
            data.pv_dose = string.IsNullOrEmpty(data.pv_dose) ? string.Empty : data.pv_dose;
            data.pv_reminder_notes = string.IsNullOrEmpty(data.pv_reminder_notes) ? string.Empty : data.pv_reminder_notes;
            return DataAccessLayer.EMR.Vaccination.InsertUpdateVaccination(data);
        }

        public static int DeleteVaccination(int pvId, int pv_madeby)
        {
            return DataAccessLayer.EMR.Vaccination.DeleteVaccination(pvId, pv_madeby);
        }
        #endregion Patient Vaccination  CRUD Operations

        #region Patient Vaccination Record (Page Load)
        public static List<BusinessEntities.EMR.VaccinationRecord> GetAllVaccinationRecord(int? patId, int? vac_recId)
        {
            List<BusinessEntities.EMR.VaccinationRecord> sclist = new List<BusinessEntities.EMR.VaccinationRecord>();
            DataTable dt = DataAccessLayer.EMR.Vaccination.GetAllVaccinationRecord(patId, vac_recId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.VaccinationRecord
                {
                    vac_recId = Convert.ToInt32(dr["vac_recId"]),
                    vac_rec_patId = Convert.ToInt32(dr["vac_rec_patId"]),
                    vac_rec_date1 = Convert.ToDateTime(dr["vac_rec_date1"].ToString()),
                    vac_rec_date2 = Convert.ToDateTime(dr["vac_rec_date2"].ToString()),
                    vac_rec_date3 = Convert.ToDateTime(dr["vac_rec_date3"].ToString()),
                    vac_rec_date4 = Convert.ToDateTime(dr["vac_rec_date4"].ToString()),
                    vac_rec_date5 = Convert.ToDateTime(dr["vac_rec_date5"].ToString()),
                    vac_rec_date6 = Convert.ToDateTime(dr["vac_rec_date6"].ToString()),
                    vac_rec_date7 = Convert.ToDateTime(dr["vac_rec_date7"].ToString()),
                    vac_rec_date8 = Convert.ToDateTime(dr["vac_rec_date8"].ToString()),
                    vac_rec_date9 = Convert.ToDateTime(dr["vac_rec_date9"].ToString()),
                    vac_rec_date10 = Convert.ToDateTime(dr["vac_rec_date10"].ToString()),
                    vac_rec_date11 = Convert.ToDateTime(dr["vac_rec_date11"].ToString()),
                    vac_rec_date12 = Convert.ToDateTime(dr["vac_rec_date12"].ToString()),
                    vac_rec_date13 = Convert.ToDateTime(dr["vac_rec_date13"].ToString()),
                    vac_rec_date14 = Convert.ToDateTime(dr["vac_rec_date14"].ToString()),
                    vac_rec_date15 = Convert.ToDateTime(dr["vac_rec_date15"].ToString()),
                    vac_rec_date16 = Convert.ToDateTime(dr["vac_rec_date16"].ToString()),
                    vac_rec_date17 = Convert.ToDateTime(dr["vac_rec_date17"].ToString()),
                    vac_rec_date18 = Convert.ToDateTime(dr["vac_rec_date18"].ToString()),
                    vac_rec_date19 = Convert.ToDateTime(dr["vac_rec_date19"].ToString()),
                    vac_rec_date20 = Convert.ToDateTime(dr["vac_rec_date20"].ToString()),
                    vac_rec_date21 = Convert.ToDateTime(dr["vac_rec_date21"].ToString()),
                    vac_rec_date22 = Convert.ToDateTime(dr["vac_rec_date22"].ToString()),
                    vac_rec_date23 = Convert.ToDateTime(dr["vac_rec_date23"].ToString()),
                    vac_rec_date24 = Convert.ToDateTime(dr["vac_rec_date24"].ToString()),
                    vac_rec_date25 = Convert.ToDateTime(dr["vac_rec_date25"].ToString()),
                    vac_rec_date26 = Convert.ToDateTime(dr["vac_rec_date26"].ToString()),
                    vac_rec_date27 = Convert.ToDateTime(dr["vac_rec_date27"].ToString()),
                    vac_rec_date28 = Convert.ToDateTime(dr["vac_rec_date28"].ToString()),
                    vac_rec_date29 = Convert.ToDateTime(dr["vac_rec_date29"].ToString()),
                    vac_rec_date30 = Convert.ToDateTime(dr["vac_rec_date30"].ToString()),
                    vac_rec_date31 = Convert.ToDateTime(dr["vac_rec_date31"].ToString()),
                    vac_rec_date32 = Convert.ToDateTime(dr["vac_rec_date32"].ToString()),
                    vac_rec_date33 = Convert.ToDateTime(dr["vac_rec_date33"].ToString()),
                    vac_rec_date34 = Convert.ToDateTime(dr["vac_rec_date34"].ToString()),
                    vac_rec_date35 = Convert.ToDateTime(dr["vac_rec_date35"].ToString()),
                    vac_rec_date36 = Convert.ToDateTime(dr["vac_rec_date36"].ToString()),
                    vac_rec_status = dr["vac_rec_status"].ToString(),
                   


                });
            }
            return sclist;
        }

        #endregion Patient Vaccination Record (Page Load)

        #region Patient Vaccination Record CRUD Operations

        public static bool InsertUpdateVaccinationRecord(BusinessEntities.EMR.VaccinationRecord data)
        {
            data.vac_rec_date1 = (data.vac_rec_date1.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date1;
            data.vac_rec_date2 = (data.vac_rec_date2.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date2;
            data.vac_rec_date3 = (data.vac_rec_date3.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date3;
            data.vac_rec_date4 = (data.vac_rec_date4.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date4;
            data.vac_rec_date5 = (data.vac_rec_date5.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date5;
            data.vac_rec_date6 = (data.vac_rec_date6.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date6;
            data.vac_rec_date7 = (data.vac_rec_date7.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date7;
            data.vac_rec_date8 = (data.vac_rec_date8.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date8;
            data.vac_rec_date9 = (data.vac_rec_date9.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date9;
            data.vac_rec_date10 = (data.vac_rec_date10.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date10;
            data.vac_rec_date11 = (data.vac_rec_date11.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date11;
            data.vac_rec_date12 = (data.vac_rec_date12.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date12;
            data.vac_rec_date13 = (data.vac_rec_date13.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date13;
            data.vac_rec_date14 = (data.vac_rec_date14.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date14;
            data.vac_rec_date15 = (data.vac_rec_date15.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date15;
            data.vac_rec_date16 = (data.vac_rec_date16.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date16;
            data.vac_rec_date17 = (data.vac_rec_date17.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date17;
            data.vac_rec_date18 = (data.vac_rec_date18.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date18;
            data.vac_rec_date19 = (data.vac_rec_date19.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date19;
            data.vac_rec_date20 = (data.vac_rec_date20.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date20;
            data.vac_rec_date21 = (data.vac_rec_date21.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date21;
            data.vac_rec_date22 = (data.vac_rec_date22.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date22;
            data.vac_rec_date23 = (data.vac_rec_date23.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date23;
            data.vac_rec_date24 = (data.vac_rec_date24.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date24;
            data.vac_rec_date25 = (data.vac_rec_date25.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date25;
            data.vac_rec_date26 = (data.vac_rec_date26.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date26;
            data.vac_rec_date27 = (data.vac_rec_date27.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date27;
            data.vac_rec_date28 = (data.vac_rec_date28.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date28;
            data.vac_rec_date29 = (data.vac_rec_date29.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date29;
            data.vac_rec_date30 = (data.vac_rec_date30.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date30;
            data.vac_rec_date31 = (data.vac_rec_date31.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date31;
            data.vac_rec_date32 = (data.vac_rec_date32.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date32;
            data.vac_rec_date33 = (data.vac_rec_date33.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date33;
            data.vac_rec_date34 = (data.vac_rec_date34.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date34;
            data.vac_rec_date35 = (data.vac_rec_date35.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date35;
            data.vac_rec_date36 = (data.vac_rec_date36.ToString() == "1/1/0001 12:00:00 AM") ? DateTime.Parse("1900-01-01") : data.vac_rec_date36;

            return DataAccessLayer.EMR.Vaccination.InsertUpdateVaccinationRecord(data);
        }

        public static int DeleteVaccinationRecord(int vac_recId, int vac_rec_madeby)
        {
            return DataAccessLayer.EMR.Vaccination.DeleteVaccinationRecord(vac_recId, vac_rec_madeby);
        }
        #endregion Patient Vaccination Record CRUD Operations
    }
}
