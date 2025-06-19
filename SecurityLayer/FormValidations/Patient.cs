using BusinessEntities.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class Patient
    {
        public static bool isValidPatient(PatientWithInsurance data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string,string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.patient.pat_name))
                {
                    errors.Add("pat_name", "First Name is Required");
                }
                else
                {
                    if (data.patient.pat_name.Length < 3)
                    {
                        errors.Add("pat_name", "First Name should be minimum 3 characters");
                    }
                }
                
                if (string.IsNullOrEmpty(data.patient.pat_lname))
                {
                    errors.Add("pat_lname", "Last Name is Required");
                }
                else
                {
                    if (data.patient.pat_lname.Length < 3)
                    {
                        errors.Add("pat_lname", "Last Name should be minimum 3 characters");
                    }
                }
                
                if (string.IsNullOrEmpty(data.patient.pat_code))
                {
                    errors.Add("pat_mrn", "MRN is Required");
                }
                if (string.IsNullOrEmpty(data.patient.pat_class))
                {
                    errors.Add("pat_class", "Patient Class is Required");
                }
                if (!(data.patient.pat_branch > 0))
                {
                    errors.Add("pat_branch", "Patient Btranch is Required");
                }

                DateTime _dob = DateTime.Now;
                if (string.IsNullOrEmpty(data.patient.pat_dob.ToString()))
                {
                    errors.Add("pat_dob", "DOB is Required");
                }
                else
                {
                    if (!DateTime.TryParse(data.patient.pat_dob.ToString(), out _dob))
                    {
                        errors.Add("pat_dob", "Invalid Date of Birth");
                    }
                }
                

                if (string.IsNullOrEmpty(data.patient.pat_gender))
                {
                    errors.Add("pat_gender", "Gender is Required");
                }

                if (string.IsNullOrEmpty(data.patient.pat_ms))
                {
                    errors.Add("pat_ms", "Civil Status is Required");
                }

                if (!string.IsNullOrEmpty(data.patient.pat_tel))
                {
                    if (!(data.patient.pat_tel.Length > 10))
                    {
                        errors.Add("pat_tel", "Telephone number is Invalid");
                    }
                }

                if (string.IsNullOrEmpty(data.patient.pat_mob))
                {
                    errors.Add("pat_mob", "Mobile Number is Required");
                }
                else
                {
                    if (!(data.patient.pat_mob.Length > 10))
                    {
                        errors.Add("pat_mob", "Mobile number is Required");
                    }
                }
                

                if (!string.IsNullOrEmpty(data.patient.pat_email))
                {
                    if (!EmailValidation.isValidEmail(data.patient.pat_email))
                    {
                        errors.Add("pat_email", "Invalid Email address");
                    }
                }

                if (!(data.patient.pat_nat > 0))
                {
                    errors.Add("pat_nat", "Nationality is Required");
                }

                if ((string.IsNullOrEmpty(data.patient.pat_passport)) && (string.IsNullOrEmpty(data.patient.pat_emirateid)))
                {
                    errors.Add("pat_emirateid,pat_passport", "Either Passport or Emirate ID is Required");
                }
                else
                {
                    if (!string.IsNullOrEmpty(data.patient.pat_emirateid))
                    {
                        if (!EMIDValidation.isValidEMID(data.patient.pat_emirateid))
                        {
                            errors.Add("pat_emirateid", "Invalid Emirates ID");
                        }
                    }
                }

                if (!(data.patient.pat_referal > 0))
                {
                    errors.Add("pat_referal", "Referal is Required");
                }

                if (!string.IsNullOrEmpty(data.patient.pat_ec_tel1))
                {
                    if (!(data.patient.pat_ec_tel1.Length > 10))
                    {
                        errors.Add("pat_ec_tel1", "Emergency Contact 1 Telephone number is Invalid");
                    }
                }

                if (!string.IsNullOrEmpty(data.patient.pat_ec_tel11))
                {
                    if (!(data.patient.pat_ec_tel11.Length > 10))
                    {
                        errors.Add("pat_ec_tel11", "Emergency Contact 1 Mobile number is Invalid");
                    }
                }

                if (!string.IsNullOrEmpty(data.patient.pat_ec_tel2))
                {
                    if (!(data.patient.pat_ec_tel2.Length > 10))
                    {
                        errors.Add("pat_ec_tel2", "Emergency Contact 2 Telephone number is Invalid");
                    }
                }

                if (!string.IsNullOrEmpty(data.patient.pat_ec_tel22))
                {
                    if (!(data.patient.pat_ec_tel22.Length > 10))
                    {
                        errors.Add("pat_ec_tel22", "Emergency Contact 2 Mobile number is Invalid");
                    }
                }

                if (!string.IsNullOrEmpty(data.patient.pat_ec_tel3))
                {
                    if (!(data.patient.pat_ec_tel3.Length > 10))
                    {
                        errors.Add("pat_ec_tel3", "Emergency Contact 3 Telephone number is Invalid");
                    }
                }

                if (!string.IsNullOrEmpty(data.patient.pat_ec_tel33))
                {
                    if (!(data.patient.pat_ec_tel33.Length > 10))
                    {
                        errors.Add("pat_ec_tel33", "Emergency Contact 2 Mobile number is Invalid");
                    }
                }

                if (!(data.insurance.pi_insurance > 0))
                {
                    errors.Add("pi_insurance", "Please Select atleast one TPA");
                }

                if (!(data.insurance.pi_payer > 0))
                {
                    errors.Add("pi_payer", "Please Select atleast one Payer");
                }

                if (!(data.insurance.pi_scheme > 0))
                {
                    errors.Add("pi_scheme", "Please Select atleast one Network");
                }

                if (data.insurance.pi_insurance > 1 && data.insurance.pi_payer > 1 && data.insurance.pi_scheme > 1)
                {
                    if (string.IsNullOrEmpty(data.insurance.pi_insno))
                    {
                        errors.Add("pi_insno", "Insurance Number is Required");
                    }

                    DateTime _pi_idate = DateTime.Now;
                    if (string.IsNullOrEmpty(data.insurance.pi_idate.ToString()))
                    {
                        errors.Add("pi_idate", "Insurance Start Date is Required");
                    }
                    else
                    {
                        if (!DateTime.TryParse(data.insurance.pi_idate.ToString(), out _pi_idate))
                        {
                            errors.Add("pi_idate", "Invalid Insurance Start Date");
                        }
                        else
                        {
                            if (!(data.insurance.pi_idate.Date <= DateTime.Today))
                            {
                                errors.Add("pi_idate", "Insurance is not yet started..");
                            }
                        }
                    }
                    

                    DateTime _pi_edate = DateTime.Now;
                    if (string.IsNullOrEmpty(data.insurance.pi_edate.ToString()))
                    {
                        errors.Add("pi_edate", "Insurance End Date is Required");
                    }
                    else{
                        if (!DateTime.TryParse(data.insurance.pi_edate.ToString(), out _pi_edate))
                        {
                            errors.Add("pi_edate", "Invalid Insurance End Date");
                        }
                        else
                        {
                            if (!(data.insurance.pi_edate.Date >= DateTime.Today))
                            {
                                errors.Add("pi_edate", "Insurance is already Expired..");
                            }
                        }
                    }                    
                }
            }
            else
            {
                errors.Add("pat_name", "First Name is Required");
                errors.Add("pat_lname", "Last Name is Required");
                errors.Add("pat_mrn", "MRN is Required");
                errors.Add("pat_class", "Patient Class is Required");
                errors.Add("pat_branch", "Patient Btranch is Required");
                errors.Add("pat_dob", "DOB is Required");
                errors.Add("pat_gender", "Gender is Required");
                errors.Add("pat_mob", "Mobile Number is Required");
                errors.Add("pat_nat", "Nationality is Required");
                errors.Add("pat_emirateid", "Either Passport or Emirate ID is Required");
                errors.Add("pat_referal", "Referal is Required");
            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidForUpdatePatient(PatientDetails data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.pat_name))
                {
                    errors.Add("uepat_name", "First Name is Required");
                }
                else
                {
                    if (data.pat_name.Length < 3)
                    {
                        errors.Add("uepat_name", "First Name should be minimum 3 characters");
                    }
                }

                if (string.IsNullOrEmpty(data.pat_lname))
                {
                    errors.Add("uepat_lname", "Last Name is Required");
                }
                else
                {
                    if (data.pat_lname.Length < 3)
                    {
                        errors.Add("uepat_lname", "Last Name should be minimum 3 characters");
                    }
                }

                if (string.IsNullOrEmpty(data.pat_code))
                {
                    errors.Add("uepat_mrn", "MRN is Required");
                }
                if (string.IsNullOrEmpty(data.pat_class))
                {
                    errors.Add("uepat_class", "Patient Class is Required");
                }
                if (!(data.pat_branch > 0))
                {
                    errors.Add("uepat_branch", "Patient Btranch is Required");
                }

                DateTime _dob = DateTime.Now;
                if (string.IsNullOrEmpty(data.pat_dob.ToString()))
                {
                    errors.Add("uepat_dob", "DOB is Required");
                }
                else
                {
                    if (!DateTime.TryParse(data.pat_dob.ToString(), out _dob))
                    {
                        errors.Add("uepat_dob", "Invalid Date of Birth");
                    }
                }

                if (string.IsNullOrEmpty(data.pat_gender))
                {
                    errors.Add("uepat_gender", "Gender is Required");
                }

                if (string.IsNullOrEmpty(data.pat_ms))
                {
                    errors.Add("uepat_ms", "Civil Status is Required");
                }

                if (!string.IsNullOrEmpty(data.pat_tel))
                {
                    if (!(data.pat_tel.Length >= 10))
                    {
                        errors.Add("uepat_tel", "Telephone number is Invalid");
                    }
                }

                if (string.IsNullOrEmpty(data.pat_mob))
                {
                    errors.Add("uepat_mob", "Mobile Number is Required");
                }
                else
                {
                    if (!(data.pat_mob.Length >= 10))
                    {
                        errors.Add("uepat_mob", "Invalid Mobile #");
                    }
                }

                if (!string.IsNullOrEmpty(data.pat_email))
                {
                    if (!EmailValidation.isValidEmail(data.pat_email))
                    {
                        errors.Add("uepat_email", "Invalid Email address");
                    }
                }

                if (!(data.pat_nat > 0))
                {
                    errors.Add("uepat_nat", "Nationality is Required");
                }

                if ((string.IsNullOrEmpty(data.pat_passport)) && (string.IsNullOrEmpty(data.pat_emirateid)))
                {
                    errors.Add("uepat_emirateid,upat_passport", "Either Passport or Emirate ID is Required");
                }
                else
                {
                    if (!string.IsNullOrEmpty(data.pat_emirateid))
                    {
                        if (!EMIDValidation.isValidEMID(data.pat_emirateid))
                        {
                            errors.Add("uepat_emirateid", "Invalid Emirates ID");
                        }
                    }
                }

                if (!(data.pat_referal > 0))
                {
                    errors.Add("uepat_referal", "Referal is Required");
                }

                if (!string.IsNullOrEmpty(data.pat_ec_tel1))
                {
                    if (!(data.pat_ec_tel1.Length >= 10))
                    {
                        errors.Add("uepat_ec_tel1", "Emergency Contact 1 Telephone number is Invalid");
                    }
                }

                if (!string.IsNullOrEmpty(data.pat_ec_tel11))
                {
                    if (!(data.pat_ec_tel11.Length >= 10))
                    {
                        errors.Add("uepat_ec_tel11", "Emergency Contact 1 Mobile number is Invalid");
                    }
                }

                if (!string.IsNullOrEmpty(data.pat_ec_tel2))
                {
                    if (!(data.pat_ec_tel2.Length >= 10))
                    {
                        errors.Add("uepat_ec_tel2", "Emergency Contact 2 Telephone number is Invalid");
                    }
                }

                if (!string.IsNullOrEmpty(data.pat_ec_tel22))
                {
                    if (!(data.pat_ec_tel22.Length >= 10))
                    {
                        errors.Add("uepat_ec_tel22", "Emergency Contact 2 Mobile number is Invalid");
                    }
                }

                if (!string.IsNullOrEmpty(data.pat_ec_tel3))
                {
                    if (!(data.pat_ec_tel3.Length >= 10))
                    {
                        errors.Add("uepat_ec_tel3", "Emergency Contact 3 Telephone number is Invalid");
                    }
                }

                if (!string.IsNullOrEmpty(data.pat_ec_tel33))
                {
                    if (!(data.pat_ec_tel33.Length >= 10))
                    {
                        errors.Add("uepat_ec_tel33", "Emergency Contact 2 Mobile number is Invalid");
                    }
                }

            }
            else
            {
                errors.Add("uepat_name", "First Name is Required");
                errors.Add("uepat_lname", "Last Name is Required");
                errors.Add("uepat_mrn", "MRN is Required");
                errors.Add("uepat_class", "Patient Class is Required");
                errors.Add("uepat_branch", "Patient Btranch is Required");
                errors.Add("uepat_dob", "DOB is Required");
                errors.Add("uepat_gender", "Gender is Required");
                errors.Add("uepat_mob", "Mobile Number is Required");
                errors.Add("uepat_nat", "Nationality is Required");
                errors.Add("uepat_emirateid", "Either Passport or Emirate ID is Required");
                errors.Add("uepat_referal", "Referal is Required");
            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidPatientInsurance(PatientInsuranceDetails data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (!(data.pi_patient > 0))
                {
                    errors.Add("pi_patient", "Patient is Not Selected");
                }

                if (!(data.pi_insurance > 0))
                {
                    errors.Add("pi_insurance", "Please Select a TPA");
                }

                if (!(data.pi_payer > 0))
                {
                    errors.Add("pi_payer", "Please Select a Payer");
                }

                if (!(data.pi_scheme > 0))
                {
                    errors.Add("pi_scheme", "Please Select a Network");
                }

                if (data.pi_insurance > 1 && data.pi_payer > 1 && data.pi_scheme > 1)
                {
                    if (string.IsNullOrEmpty(data.pi_insno))
                    {
                        errors.Add("pi_insno", "Insurance Number is Required");
                    }

                    if (string.IsNullOrEmpty(data.pi_polocyno))
                    {
                        errors.Add("pi_polocyno", "Policy Number is Required");
                    }

                    DateTime _pi_idate = DateTime.Now;
                    if (string.IsNullOrEmpty(data.pi_idate.ToString()))
                    {
                        errors.Add("pi_idate", "Insurance Start Date is Required");
                    }
                    else
                    {
                        if (!DateTime.TryParse(data.pi_idate.ToString(), out _pi_idate))
                        {
                            errors.Add("pi_idate", "Invalid Insurance Start Date");
                        }
                        else
                        {
                            if (!(data.pi_idate.Date <= DateTime.Today))
                            {
                                errors.Add("pi_idate", "Insurance is not yet started..");
                            }
                        }
                    }


                    DateTime _pi_edate = DateTime.Now;
                    if (string.IsNullOrEmpty(data.pi_edate.ToString()))
                    {
                        errors.Add("pi_edate", "Insurance End Date is Required");
                    }
                    else
                    {
                        if (!DateTime.TryParse(data.pi_edate.ToString(), out _pi_edate))
                        {
                            errors.Add("pi_edate", "Invalid Insurance End Date");
                        }
                        else
                        {
                            if (!(data.pi_edate.Date >= DateTime.Today))
                            {
                                errors.Add("pi_edate", "Insurance is already Expired..");
                            }
                        }
                    }
                }
            }
            else
            {
                errors.Add("pi_insurance", "Please Select a TPA");
                errors.Add("pi_payer", "Please Select a Payer");
                errors.Add("pi_scheme", "Please Select a Network");
            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidPatientSearch(PatientSearch data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();


            if (data != null)
            {
                if (data.mode == 1)
                {
                    if (string.IsNullOrEmpty(data.branch_ids) && string.IsNullOrEmpty(data.residential_types) &&
                    string.IsNullOrEmpty(data.nationalities) && string.IsNullOrEmpty(data.mrn_from) &&
                    string.IsNullOrEmpty(data.mrn_to) && string.IsNullOrEmpty(data.pat_class) &&
                    string.IsNullOrEmpty(data.reg_from) && string.IsNullOrEmpty(data.reg_to) &&
                    string.IsNullOrEmpty(data.dob_from) && string.IsNullOrEmpty(data.dob_to) &&
                    string.IsNullOrEmpty(data.pat_status) && string.IsNullOrEmpty(data.pat_gender) &&
                    string.IsNullOrEmpty(data.pat_ms) && string.IsNullOrEmpty(data.pat_referals)
                    )
                    {
                        errors.Add("", "you should input atleast one input to filter records");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(data.reg_from))
                        {
                            DateTime dt = DateTime.Now;
                            if (!DateTime.TryParse(data.reg_from, out dt))
                            {
                                errors.Add("select_date_from_reg", "Invalid Date");
                            }
                        }

                        if (string.IsNullOrEmpty(data.reg_to))
                        {
                            DateTime dt = DateTime.Now;
                            if (!DateTime.TryParse(data.reg_to, out dt))
                            {
                                errors.Add("select_date_to_reg", "Invalid Date");
                            }
                        }

                        if (string.IsNullOrEmpty(data.reg_to))
                        {
                            DateTime dt = DateTime.Now;
                            if (DateTime.TryParse(data.reg_to, out dt))
                            {
                                if (string.IsNullOrEmpty(data.reg_from))
                                {
                                    DateTime dt1 = DateTime.Now;
                                    if (DateTime.TryParse(data.reg_to, out dt))
                                    {
                                        if (!(dt1 < dt))
                                        {
                                            errors.Add("select_date_from_reg,select_date_to_reg", "From Date should be less than To Date");
                                        }
                                    }
                                }
                            }
                        }

                        if (string.IsNullOrEmpty(data.dob_from))
                        {
                            DateTime dt = DateTime.Now;
                            if (!DateTime.TryParse(data.dob_from, out dt))
                            {
                                errors.Add("select_date_from_dob", "Invalid Date");
                            }
                        }

                        if (string.IsNullOrEmpty(data.dob_to))
                        {
                            DateTime dt = DateTime.Now;
                            if (!DateTime.TryParse(data.dob_to, out dt))
                            {
                                errors.Add("select_date_to_dob", "Invalid Date");
                            }
                        }

                        if (string.IsNullOrEmpty(data.dob_to))
                        {
                            DateTime dt = DateTime.Now;
                            if (DateTime.TryParse(data.dob_to, out dt))
                            {
                                if (string.IsNullOrEmpty(data.dob_from))
                                {
                                    DateTime dt1 = DateTime.Now;
                                    if (DateTime.TryParse(data.dob_from, out dt))
                                    {
                                        if (!(dt1 < dt))
                                        {
                                            errors.Add("select_date_from_reg,select_date_to_reg", "From Date should be less than To Date");
                                        }
                                    }
                                }
                            }
                        }

                        if (string.IsNullOrEmpty(data.mrn_to))
                        {
                            int val = 0;
                            if (!Int32.TryParse(data.mrn_to, out val))
                            {
                                errors.Add("select_mrn_to", "Invalid MRN #");
                            }
                        }

                        if (string.IsNullOrEmpty(data.mrn_from))
                        {
                            int val = 0;
                            if (!Int32.TryParse(data.mrn_from, out val))
                            {
                                errors.Add("select_mrn_from", "Invalid MRN #");
                            }
                        }

                        if (string.IsNullOrEmpty(data.mrn_to))
                        {
                            int val = 0;
                            if (Int32.TryParse(data.mrn_to, out val))
                            {
                                if (string.IsNullOrEmpty(data.mrn_from))
                                {
                                    int val1 = 0;
                                    if (Int32.TryParse(data.mrn_from, out val))
                                    {
                                        if (val <= val1)
                                        {
                                            errors.Add("select_mrn_from,select_mrn_to", "MRN From should be less than or equal to MRN To");
                                        }

                                    }
                                }
                            }
                        }


                    }
                }
            }
            else
            {
                errors.Add("", "you should input atleast one input to filter records");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidForInsertInquiryPatient(PatientWithInsurance data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.patient.pat_name))
                {
                    errors.Add("ipat_name", "First Name is Required");
                }
                else
                {
                    if (data.patient.pat_name.Length < 3)
                    {
                        errors.Add("ipat_name", "First Name should be minimum 3 characters");
                    }
                }

                if (string.IsNullOrEmpty(data.patient.pat_lname))
                {
                    errors.Add("ipat_lname", "Last Name is Required");
                }
                else
                {
                    if (data.patient.pat_lname.Length < 3)
                    {
                        errors.Add("ipat_lname", "Last Name should be minimum 3 characters");
                    }
                }

                if (string.IsNullOrEmpty(data.patient.pat_mob))
                {
                    errors.Add("ipat_mob", "Mobile Number is Required");
                }
            }
            else
            {
                errors.Add("ipat_name", "First Name is Required");
                errors.Add("ipat_lname", "Last Name is Required");
                errors.Add("ipat_mob", "Mobile Number is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidForUpdateInquiryPatient(PatientDetails data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.pat_name))
                {
                    errors.Add("ipat_name", "First Name is Required");
                }
                else
                {
                    if (data.pat_name.Length < 3)
                    {
                        errors.Add("ipat_name", "First Name should be minimum 3 characters");
                    }
                }

                if (string.IsNullOrEmpty(data.pat_lname))
                {
                    errors.Add("ipat_lname", "Last Name is Required");
                }
                else
                {
                    if (data.pat_lname.Length < 3)
                    {
                        errors.Add("ipat_lname", "Last Name should be minimum 3 characters");
                    }
                }

                if (string.IsNullOrEmpty(data.pat_mob))
                {
                    errors.Add("ipat_mob", "Mobile Number is Required");
                }
            }
            else
            {
                errors.Add("ipat_name", "First Name is Required");
                errors.Add("ipat_lname", "Last Name is Required");
                errors.Add("ipat_mob", "Mobile Number is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}