using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BusinessLogicLayer.Appointment
{
    public class Doctor
    {
        public static List<BusinessEntities.Appointment.S_Doctor> GetDoctorData(string val = null, int setId = 0)
        {
            List<BusinessEntities.Appointment.S_Doctor> list = new List<BusinessEntities.Appointment.S_Doctor>();
            DataTable dt = DataAccessLayer.Appointment.Doctors.GetDoctors(val, setId);


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BusinessEntities.Appointment.S_Doctor d = new BusinessEntities.Appointment.S_Doctor();
                    d.id = dr["empId"].ToString();
                    d.title = dr["emp_name"].ToString();

                    BusinessEntities.Appointment.S_DoctorProperties prop = new BusinessEntities.Appointment.S_DoctorProperties();
                    prop.emp_color = dr["emp_color"].ToString();
                    prop.emp_dept_name = dr["emp_dept_name"].ToString();
                    prop.emp_desig_name = dr["emp_desig_name"].ToString();
                    prop.emp_speciality = dr["emp_speciality"].ToString();
                    prop.emp_license = dr["emp_license"].ToString();



                    if (string.IsNullOrEmpty(dr["emp_photo"].ToString().Trim()))
                    {
                        prop.emp_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-doctor.jpg";
                    }
                    else
                    {
                        prop.emp_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/EMPLOYEE_PHOTOS/" + dr["emp_photo"].ToString();
                    }


                    d.extendedProps = prop;
                    list.Add(d);
                }
            }

            return list;
        }

        public static List<BusinessEntities.Appointment.S_Doctor> GetDoctorDataWithDateRange(string val = null, int setId = 0, string start = null, string end = null)
        {
            List<BusinessEntities.Appointment.S_Doctor> list = new List<BusinessEntities.Appointment.S_Doctor>();
            DataTable dt = DataAccessLayer.Appointment.Doctors.GetDoctorsWithDateRange(val, setId, start, end);


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BusinessEntities.Appointment.S_Doctor d = new BusinessEntities.Appointment.S_Doctor();
                    d.id = dr["empId"].ToString();
                    d.title = dr["emp_name"].ToString();

                    List<BusinessEntities.Appointment.WorkingHours> bh_lists = new List<BusinessEntities.Appointment.WorkingHours>();

                    DateTime StartDate = Convert.ToDateTime(start);
                    DateTime EndDate = Convert.ToDateTime(end);

                    double days = (EndDate - StartDate).TotalDays;

                    for (int i = 0; i < days; i++)
                    {
                        DateTime iDay = StartDate.AddDays(i);

                        DataTable dt_ts = DataAccessLayer.Appointment.Doctors.GetDoctorsBusinessHours(int.Parse(dr["empId"].ToString()), setId, iDay);

                        if (dt_ts.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt_ts.Rows)
                            {
                                if (!string.IsNullOrEmpty(r["er_ftime"].ToString()) && !string.IsNullOrEmpty(r["er_ttime"].ToString()))
                                {
                                    BusinessEntities.Appointment.WorkingHours bh = new BusinessEntities.Appointment.WorkingHours();
                                    bh.startTime = r["er_ftime"].ToString();
                                    bh.endTime = (r["er_ttime"].ToString().Equals("00:00")) ? "23:59" : r["er_ttime"].ToString();
                                    List<int> dow = new List<int>();
                                    dow.Add((int)iDay.DayOfWeek);
                                    bh.daysOfWeek = dow;
                                    bh_lists.Add(bh);
                                }
                            }
                        }

                        if (bh_lists.Count == 0)
                        {
                            BusinessEntities.Appointment.WorkingHours bh = new BusinessEntities.Appointment.WorkingHours();
                            bh.startTime = "00:00";
                            bh.endTime = "00:00";
                            List<int> dow = new List<int>();
                            dow.Add((int)iDay.DayOfWeek);
                            bh.daysOfWeek = dow;
                            bh_lists.Add(bh);
                        }
                    }

                    d.businessHours = bh_lists;

                    BusinessEntities.Appointment.S_DoctorProperties prop = new BusinessEntities.Appointment.S_DoctorProperties();
                    prop.emp_color = dr["emp_color"].ToString();
                    prop.emp_dept_name = dr["emp_dept_name"].ToString();
                    prop.emp_desig_name = dr["emp_desig_name"].ToString();
                    prop.emp_speciality = dr["emp_speciality"].ToString();
                    prop.emp_license = dr["emp_license"].ToString();
                    prop.emp_rank = SecurityLayer.DataValidation.isIntValid(dr["emp_rank"].ToString());

                    if (string.IsNullOrEmpty(dr["emp_photo"].ToString().Trim()))
                    {
                        prop.emp_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-doctor.jpg";
                    }
                    else
                    {
                        prop.emp_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/EMPLOYEE_PHOTOS/" + dr["emp_photo"].ToString();
                    }

                    d.extendedProps = prop;
                    list.Add(d);
                }
            }
            return list;
        }

        public static List<BusinessEntities.Appointment.S_Doctor> Doctors_Active(int docId, int setId)
        {
            List<BusinessEntities.Appointment.S_Doctor> list = new List<BusinessEntities.Appointment.S_Doctor>();

            DataTable dt = DataAccessLayer.Appointment.Doctors.Doctors_Active(docId, setId);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BusinessEntities.Appointment.S_Doctor d = new BusinessEntities.Appointment.S_Doctor();
                    d.id = dr["id"].ToString();
                    d.title = dr["text"].ToString();

                    BusinessEntities.Appointment.S_DoctorProperties prop = new BusinessEntities.Appointment.S_DoctorProperties();
                    prop.emp_color = dr["emp_color"].ToString();
                    prop.emp_dept_name = dr["emp_dept_name"].ToString();
                    prop.emp_desig_name = dr["emp_desig_name"].ToString();
                    prop.emp_speciality = dr["emp_speciality"].ToString();
                    prop.emp_license = dr["emp_license"].ToString();

                    if (string.IsNullOrEmpty(dr["emp_photo"].ToString().Trim()))
                    {
                        prop.emp_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-doctor.jpg";
                    }
                    else
                    {
                        prop.emp_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/EMPLOYEE_PHOTOS/" + dr["emp_photo"].ToString();
                    }

                    d.extendedProps = prop;

                    list.Add(d);
                }
            }

            return list;
        }

        public static List<BusinessEntities.Appointment.S_Doctor> GetDoctorsByDepartments(string deptIds, string doctor)
        {
            List<BusinessEntities.Appointment.S_Doctor> list = new List<BusinessEntities.Appointment.S_Doctor>();

            DataTable dt = DataAccessLayer.Appointment.Doctors.GetDoctorsByDepartments(deptIds, doctor);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BusinessEntities.Appointment.S_Doctor d = new BusinessEntities.Appointment.S_Doctor();
                    d.id = dr["id"].ToString();
                    d.title = dr["text"].ToString();

                    BusinessEntities.Appointment.S_DoctorProperties prop = new BusinessEntities.Appointment.S_DoctorProperties();
                    prop.emp_color = dr["emp_color"].ToString();
                    prop.emp_dept_name = dr["emp_dept_name"].ToString();
                    prop.emp_desig_name = dr["emp_desig_name"].ToString();
                    prop.emp_speciality = dr["emp_speciality"].ToString();
                    prop.emp_license = dr["emp_license"].ToString();

                    if (string.IsNullOrEmpty(dr["emp_photo"].ToString().Trim()))
                    {
                        prop.emp_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-doctor.jpg";
                    }
                    else
                    {
                        prop.emp_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/EMPLOYEE_PHOTOS/" + dr["emp_photo"].ToString();
                    }

                    d.extendedProps = prop;
                    list.Add(d);
                }
            }

            return list;
        }

        public static List<BusinessEntities.Appointment.CommonDDL> GetActiveDoctorsByBranches(string branchIds)
        {
            List<BusinessEntities.Appointment.CommonDDL> list = new List<BusinessEntities.Appointment.CommonDDL>();

            DataTable dt = DataAccessLayer.Appointment.Doctors.GetActiveDoctorsByBranches(branchIds);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BusinessEntities.Appointment.CommonDDL d = new BusinessEntities.Appointment.CommonDDL();
                    d.id = Convert.ToInt32(dr["id"]);
                    d.text = dr["text"].ToString();
                    list.Add(d);
                }
            }

            return list;
        }
    }
}
