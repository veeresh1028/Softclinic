using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.InsuranceForms
{
    public class AdnicDentalAuth
    {
        public static bool isValidAdnicDentalAuth(BusinessEntities.InsuranceForms.AdnicDentalAuth data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ada_diags1))
                {
                    errors.Add("ada_diags1", "Please Enter Diagnosis1");
                }

                if (string.IsNullOrEmpty(data.ada_ser1))
                {
                    errors.Add("ada_ser1", "Please Enter Description of Service1");
                }

                if (string.IsNullOrEmpty(data.ada_tooth1))
                {
                    errors.Add("ada_tooth1", "Please Enter Tooth No.1");
                }

                if (string.IsNullOrEmpty(data.ada_code1))
                {
                    errors.Add("ada_code1", "Please Enter Canadian Code1");
                }

                if (string.IsNullOrEmpty(data.ada_cost1))
                {
                    errors.Add("ada_cost1", "Please Enter Cost Estimate1");
                }

                if (string.IsNullOrEmpty(data.ada_diags2))
                {
                    errors.Add("ada_diags2", "Please Enter Diagnosis2");
                }

                if (string.IsNullOrEmpty(data.ada_ser2))
                {
                    errors.Add("ada_ser2", "Please Enter Description of Service2");
                }

                if (string.IsNullOrEmpty(data.ada_tooth2))
                {
                    errors.Add("ada_tooth2", "Please Enter Tooth No.2");
                }

                if (string.IsNullOrEmpty(data.ada_code2))
                {
                    errors.Add("ada_code2", "Please Enter Canadian Code2");
                }

                if (string.IsNullOrEmpty(data.ada_cost2))
                {
                    errors.Add("ada_cost2", "Please Enter Cost Estimate2");
                }

                if (string.IsNullOrEmpty(data.ada_diags3))
                {
                    errors.Add("ada_diags3", "Please Enter Diagnosis3");
                }

                if (string.IsNullOrEmpty(data.ada_ser3))
                {
                    errors.Add("ada_ser3", "Please Enter Description of Service3");
                }

                if (string.IsNullOrEmpty(data.ada_tooth3))
                {
                    errors.Add("ada_tooth3", "Please Enter Tooth No.3");
                }

                if (string.IsNullOrEmpty(data.ada_code3))
                {
                    errors.Add("ada_code3", "Please Enter Canadian Code3");
                }

                if (string.IsNullOrEmpty(data.ada_cost3))
                {
                    errors.Add("ada_cost3", "Please Enter Cost Estimate3");
                }

                if (string.IsNullOrEmpty(data.ada_diags4))
                {
                    errors.Add("ada_diags4", "Please Enter Diagnosis4");
                }
                if (string.IsNullOrEmpty(data.ada_ser4))
                {
                    errors.Add("ada_ser4", "Please Enter Description of Service4");
                }
                if (string.IsNullOrEmpty(data.ada_tooth4))
                {
                    errors.Add("ada_tooth4", "Please Enter Tooth No.4");
                }
                if (string.IsNullOrEmpty(data.ada_code4))
                {
                    errors.Add("ada_code4", "Please Enter Canadian Code4");
                }
                if (string.IsNullOrEmpty(data.ada_cost4))
                {
                    errors.Add("ada_cost4", "Please Enter Cost Estimate4");
                }
                if (string.IsNullOrEmpty(data.ada_diags5))
                {
                    errors.Add("ada_diags5", "Please Enter Diagnosis5");
                }
                if (string.IsNullOrEmpty(data.ada_ser5))
                {
                    errors.Add("ada_ser5", "Please Enter Description of Service5");
                }
                if (string.IsNullOrEmpty(data.ada_tooth5))
                {
                    errors.Add("ada_tooth5", "Please Enter Tooth No.5");
                }
                if (string.IsNullOrEmpty(data.ada_code5))
                {
                    errors.Add("ada_code5", "Please Enter Canadian Code5");
                }
                if (string.IsNullOrEmpty(data.ada_cost5))
                {
                    errors.Add("ada_cost5", "Please Enter Cost Estimate5");
                }
                if (string.IsNullOrEmpty(data.ada_diags6))
                {
                    errors.Add("ada_diags6", "Please Enter Diagnosis6");
                }
                if (string.IsNullOrEmpty(data.ada_ser6))
                {
                    errors.Add("ada_ser6", "Please Enter Description of Service6");
                }
                if (string.IsNullOrEmpty(data.ada_tooth6))
                {
                    errors.Add("ada_tooth6", "Please Enter Tooth No.6");
                }
                if (string.IsNullOrEmpty(data.ada_code6))
                {
                    errors.Add("ada_code6", "Please Enter Canadian Code6");
                }
                if (string.IsNullOrEmpty(data.ada_cost6))
                {
                    errors.Add("ada_cost6", "Please Enter Cost Estimate6");
                }
                if (string.IsNullOrEmpty(data.ada_treat_tot))
                {
                    errors.Add("ada_treat_tot", "Please Enter Total Amount");
                }
                if (string.IsNullOrEmpty(data.ada_doc_no))
                {
                    errors.Add("ada_doc_no", "Please Enter Document no");
                }
               
            }
            else
            {
                errors.Add("ada_diags1", "Please Enter Diagnosis1");
                errors.Add("ada_ser1", "Please Enter Description of Service1");
                errors.Add("ada_tooth1", "Please Enter Tooth No.1");
                errors.Add("ada_code1", "Please Enter Canadian Code1");
                errors.Add("ada_cost1", "Please Enter Cost Estimate1");
                errors.Add("ada_diags2", "Please Enter Diagnosis2");
                errors.Add("ada_ser2", "Please Enter Description of Service2");
                errors.Add("ada_tooth2", "Please Enter Tooth No.2");
                errors.Add("ada_code2", "Please Enter Canadian Code2");
                errors.Add("ada_cost2", "Please Enter Cost Estimate2");
                errors.Add("ada_diags3", "Please Enter Diagnosis3");
                errors.Add("ada_ser3", "Please Enter Description of Service3");
                errors.Add("ada_tooth3", "Please Enter Tooth No.3");
                errors.Add("ada_code3", "Please Enter Canadian Code3");
                errors.Add("ada_cost3", "Please Enter Cost Estimate3");
                errors.Add("ada_diags4", "Please Enter Diagnosis4");
                errors.Add("ada_ser4", "Please Enter Description of Service4");
                errors.Add("ada_tooth4", "Please Enter Tooth No.4");
                errors.Add("ada_code4", "Please Enter Canadian Code4");
                errors.Add("ada_cost4", "Please Enter Cost Estimate4");
                errors.Add("ada_diags5", "Please Enter Diagnosis5");
                errors.Add("ada_ser5", "Please Enter Description of Service5");
                errors.Add("ada_tooth5", "Please Enter Tooth No.5");
                errors.Add("ada_code5", "Please Enter Canadian Code5");
                errors.Add("ada_cost5", "Please Enter Cost Estimate5");
                errors.Add("ada_diags6", "Please Enter Diagnosis6");
                errors.Add("ada_ser6", "Please Enter Description of Service6");
                errors.Add("ada_tooth6", "Please Enter Tooth No.6");
                errors.Add("ada_code6", "Please Enter Canadian Code6");
                errors.Add("ada_cost6", "Please Enter Cost Estimate6");
                errors.Add("ada_treat_tot", "Please Enter Total Amount");
                errors.Add("ada_doc_no", "Please Enter Document no");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
