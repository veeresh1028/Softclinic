using BusinessEntities.Patient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Patient
{
    public class PatientInsurance
    {
        public static List<BusinessEntities.Patient.PatientInsurance> GetInsuranceDataByID(int patId)
        {
            List<BusinessEntities.Patient.PatientInsurance> insurances = new List<BusinessEntities.Patient.PatientInsurance>();
            DataTable dt = DataAccessLayer.Patient.PatientInsurance.GetInsuranceDataByPatientID(patId);

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.Patient.PatientInsurance insurance = new BusinessEntities.Patient.PatientInsurance();
                insurance.piId = int.Parse(dr["piId"].ToString());
                insurance.pi_patient = patId;
                insurance.pi_image = dr["pi_image"].ToString();
                insurance.pi_image2 = dr["pi_image2"].ToString();
                insurance.is_ic_code = dr["is_ic_code"].ToString();
                insurance.is_ic_name = dr["is_ic_name"].ToString();
                insurance.is_ip_code = dr["is_ip_code"].ToString();
                insurance.is_ip_name = dr["is_ip_name"].ToString();
                insurance.is_title = dr["is_title"].ToString();
                insurance.pi_insno = dr["pi_insno"].ToString();
                insurance.pi_polocyno = dr["pi_polocyno"].ToString();
                insurance.pi_idate = DateTime.Parse(dr["pi_idate"].ToString());
                insurance.pi_edate = DateTime.Parse(dr["pi_edate"].ToString());
                insurance.pi_limit = double.Parse(dr["pi_limit"].ToString());
                insurance.pi_ceiling = double.Parse(dr["pi_ceiling"].ToString());
                insurance.pi_status = dr["pi_status"].ToString();

                insurance.pat_name = dr["pat_name"].ToString();
                insurance.pat_code = dr["pat_code"].ToString();

                insurance.isAllocated = int.Parse(dr["isAllocated"].ToString());

                insurance.pi_cded = decimal.Parse(dr["pi_cded"].ToString());
                insurance.pi_cded_type = dr["pi_cded_type"].ToString();
                insurance.pi_cded_limit = decimal.Parse(dr["pi_cded_limit"].ToString());

                insurance.pi_ip_dcopay = decimal.Parse(dr["pi_ip_dcopay"].ToString());
                insurance.pi_ip_dcopay_type = dr["pi_ip_dcopay_type"].ToString();
                insurance.pi_ip_dcopay_limit = decimal.Parse(dr["pi_ip_dcopay_limit"].ToString());

                insurance.pi_dded = decimal.Parse(dr["pi_dded"].ToString());
                insurance.pi_dded_type = dr["pi_dded_type"].ToString();
                insurance.pi_dded_limit = decimal.Parse(dr["pi_dded_limit"].ToString());

                insurance.pi_ided = decimal.Parse(dr["pi_ided"].ToString());
                insurance.pi_ided_type = dr["pi_ided_type"].ToString();
                insurance.pi_ided_limit = decimal.Parse(dr["pi_ided_limit"].ToString());

                insurance.pi_rded = decimal.Parse(dr["pi_rded"].ToString());
                insurance.pi_rded_type = dr["pi_rded_type"].ToString();
                insurance.pi_rded_limit = decimal.Parse(dr["pi_rded_limit"].ToString());

                insurance.pi_mded = decimal.Parse(dr["pi_mded"].ToString());
                insurance.pi_mded_type = dr["pi_mded_type"].ToString();
                insurance.pi_mded_limit = decimal.Parse(dr["pi_mded_limit"].ToString());

                insurance.pi_pded = decimal.Parse(dr["pi_pded"].ToString());
                insurance.pi_pded_type = dr["pi_pded_type"].ToString();
                insurance.pi_pded_limit = decimal.Parse(dr["pi_pded_limit"].ToString());

                insurance.pi_copay = decimal.Parse(dr["pi_copay"].ToString());
                insurance.pi_copay_type = dr["pi_copay_type"].ToString();
                insurance.pi_copay_limit = decimal.Parse(dr["pi_copay_limit"].ToString());

                insurance.pi_dcopay = decimal.Parse(dr["pi_dcopay"].ToString());
                insurance.pi_dcopay_type = dr["pi_dcopay_type"].ToString();
                insurance.pi_dcopay_limit = decimal.Parse(dr["pi_dcopay_limit"].ToString());

                insurance.pi_hdcopay = decimal.Parse(dr["pi_hdcopay"].ToString());
                insurance.pi_hdcopay_type = dr["pi_hdcopay_type"].ToString();
                insurance.pi_hdcopay_limit = decimal.Parse(dr["pi_hp_dcopay_limit"].ToString());

                insurances.Add(insurance);
            }

            return insurances;
        }

        public static DataTable GetPatient_InsuranceTPA(int? icId)
        {
            return DataAccessLayer.Patient.PatientInsurance.GetPatient_InsuranceTPA(icId);
        }

        public static DataTable GetPatient_InsurancePayers(int? ipId, int? ip_ins)
        {
            return DataAccessLayer.Patient.PatientInsurance.GetPatient_InsurancePayers(ipId, ip_ins);
        }

        public static DataTable GetPatient_InsuranceNetworks(int? isId, int? is_icId)
        {
            return DataAccessLayer.Patient.PatientInsurance.GetPatient_InsuranceNetworks(isId, is_icId);
        }

        public static int InsertPatientInsurance(PatientInsuranceDetails i, int madeby, int patId)
        {
            i.pi_insno = (string.IsNullOrEmpty(i.pi_insno)) ? string.Empty : i.pi_insno;
            i.pi_image = (string.IsNullOrEmpty(i.pi_image)) ? string.Empty : i.pi_image;
            i.pi_image2 = (string.IsNullOrEmpty(i.pi_image2)) ? string.Empty : i.pi_image2;
            i.pi_polocyno = (string.IsNullOrEmpty(i.pi_polocyno)) ? string.Empty : i.pi_polocyno;
            return DataAccessLayer.Patient.PatientInsurance.InsertPatientInsurance(i, madeby, patId);
        }

        public static PatientInsuranceDetails GetInsuranceDataByInsuranceID(int piId)
        {
            PatientInsuranceDetails insurance = new PatientInsuranceDetails();

            DataTable dt = DataAccessLayer.Patient.PatientInsurance.GetInsuranceDataByInsuranceID(piId);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                insurance.piId = piId;
                insurance.pi_patient = int.Parse(dr["pi_patient"].ToString());
                insurance.pit_insurance = int.Parse(dr["pit_insurance"].ToString());
                insurance.is_insurance = int.Parse(dr["is_insurance"].ToString());
                insurance.pi_insurance = int.Parse(dr["pi_insurance"].ToString());

                insurance.pi_image = dr["pi_image"].ToString();
                insurance.pi_image2 = dr["pi_image2"].ToString();

                insurance.pi_insno = dr["pi_insno"].ToString();
                insurance.pi_polocyno = dr["pi_polocyno"].ToString();
                insurance.pi_idate = DateTime.Parse(dr["pi_idate"].ToString());
                insurance.pi_edate = DateTime.Parse(dr["pi_edate"].ToString());

                insurance.pi_cded = decimal.Parse(dr["pi_cded"].ToString());
                insurance.pi_cded_type = dr["pi_cded_type"].ToString();
                insurance.pi_cded_limit = decimal.Parse(dr["pi_cded_limit"].ToString());

                insurance.pi_ided = decimal.Parse(dr["pi_ided"].ToString());
                insurance.pi_ided_type = dr["pi_ided_type"].ToString();
                insurance.pi_ided_limit = decimal.Parse(dr["pi_ided_limit"].ToString());

                insurance.pi_pded = decimal.Parse(dr["pi_pded"].ToString());
                insurance.pi_pded_type = dr["pi_pded_type"].ToString();
                insurance.pi_pded_limit = decimal.Parse(dr["pi_pded_limit"].ToString());

                insurance.pi_copay = decimal.Parse(dr["pi_copay"].ToString());
                insurance.pi_copay_type = dr["pi_copay_type"].ToString();
                insurance.pi_copay_limit = decimal.Parse(dr["pi_copay_limit"].ToString());

                insurance.pi_dcopay = decimal.Parse(dr["pi_dcopay"].ToString());
                insurance.pi_dcopay_type = dr["pi_dcopay_type"].ToString();
                insurance.pi_dcopay_limit = decimal.Parse(dr["pi_dcopay_limit"].ToString());

                insurance.pi_hdcopay = decimal.Parse(dr["pi_hdcopay"].ToString());
                insurance.pi_hdcopay_type = dr["pi_hdcopay_type"].ToString();
                insurance.pi_hdcopay_limit = decimal.Parse(dr["pi_hp_dcopay_limit"].ToString());

                insurance.pi_ip_dcopay = decimal.Parse(dr["pi_ip_dcopay"].ToString());
                insurance.pi_ip_dcopay_type = dr["pi_ip_dcopay_type"].ToString();
                insurance.pi_ip_dcopay_limit = decimal.Parse(dr["pi_ip_dcopay_limit"].ToString());

                insurance.pi_dded = decimal.Parse(dr["pi_dded"].ToString());
                insurance.pi_dded_type = dr["pi_dded_type"].ToString();
                insurance.pi_dded_limit = decimal.Parse(dr["pi_dded_limit"].ToString());


                insurance.pi_rded = decimal.Parse(dr["pi_rded"].ToString());
                insurance.pi_rded_type = dr["pi_rded_type"].ToString();
                insurance.pi_rded_limit = decimal.Parse(dr["pi_rded_limit"].ToString());

                insurance.pi_mded = decimal.Parse(dr["pi_mded"].ToString());
                insurance.pi_mded_type = dr["pi_mded_type"].ToString();
                insurance.pi_mded_limit = decimal.Parse(dr["pi_mded_limit"].ToString());


                insurance.pi_limit = double.Parse(dr["pi_limit"].ToString());
                insurance.pi_ceiling = double.Parse(dr["pi_ceiling"].ToString());
                insurance.pi_image = dr["pi_image"].ToString();
                insurance.pi_image2 = dr["pi_image2"].ToString();

            }

            return insurance;

        }

        public static int UpdatePatientInsurance(PatientInsuranceDetails i, int madeby)
        {
            return DataAccessLayer.Patient.PatientInsurance.UpdatePatientInsurance(i, madeby);
        }

        public static int ChangePatientInsuranceStatus(int piId, string pi_status, int madeby)
        {
            return DataAccessLayer.Patient.PatientInsurance.ChangePatientInsuranceStatus(piId, pi_status, madeby);
        }
    }
}