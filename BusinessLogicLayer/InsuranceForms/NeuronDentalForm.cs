using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.InsuranceForms
{
    public class NeuronDentalForm
    {
        public static List<BusinessEntities.InsuranceForms.NeuronDentalForm> GetNeuronDentalFormData(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.NeuronDentalForm.GetNeuronDentalFormData(appId);
            List<BusinessEntities.InsuranceForms.NeuronDentalForm> list = new List<BusinessEntities.InsuranceForms.NeuronDentalForm>();

            foreach (DataRow dr in dt.Rows)
            {

                list.Add(new BusinessEntities.InsuranceForms.NeuronDentalForm
                {
                    ncdId = Convert.ToInt32(dr["ncdId"]),
                    ncd_appId = Convert.ToInt32(dr["ncd_appId"]),

                    ncd_1 = dr["ncd_1"].ToString(),
                    ncd_2 = dr["ncd_2"].ToString(),
                    ncd_3 = dr["ncd_3"].ToString(),
                    ncd_4 = dr["ncd_4"].ToString(),
                    ncd_5 = dr["ncd_5"].ToString(),
                    ncd_6 = dr["ncd_6"].ToString(),
                    ncd_7 = dr["ncd_7"].ToString(),
                    ncd_8 = dr["ncd_8"].ToString(),
                    ncd_9 = dr["ncd_9"].ToString(),
                    ncd_10 = dr["ncd_10"].ToString(),
                    ncd_11 = dr["ncd_11"].ToString(),
                    ncd_12 = dr["ncd_12"].ToString(),
                    ncd_13 = dr["ncd_13"].ToString(),
                    ncd_14 = dr["ncd_14"].ToString(),
                    ncd_15 = dr["ncd_15"].ToString(),
                    ncd_16 = dr["ncd_16"].ToString(),
                    ncd_17 = dr["ncd_17"].ToString(),
                    ncd_18 = dr["ncd_18"].ToString(),
                    ncd_19 = dr["ncd_19"].ToString(),
                    ncd_20 = dr["ncd_20"].ToString(),
                    ncd_21 = dr["ncd_21"].ToString(),
                    ncd_22 = dr["ncd_22"].ToString(),
                    ncd_23 = dr["ncd_23"].ToString(),
                    ncd_24 = dr["ncd_24"].ToString(),
                    ncd_25 = dr["ncd_25"].ToString(),
                    ncd_26 = dr["ncd_26"].ToString(),
                    ncd_27 = dr["ncd_27"].ToString(),

                    ncd_status = dr["ncd_status"].ToString(),
                    ncd_date_modified = Convert.ToDateTime(dr["ncd_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveNeuronDentalForm(BusinessEntities.InsuranceForms.NeuronDentalForm medical, int madeby)
        {
            return DataAccessLayer.InsuranceForms.NeuronDentalForm.SaveNeuronDentalForm(medical, madeby);
        }
        public static int DeleteNeuronDentalForm(int appId, int madeby)
        {
            return DataAccessLayer.InsuranceForms.NeuronDentalForm.DeleteNeuronDentalForm(appId, madeby);
        }
        public static List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> GetNeuronDentalFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.NeuronDentalForm.GetNeuronDentalFormPreviousHistory(appId);
            List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> list = new List<BusinessEntities.InsuranceForms.ConcentPreviousHistory>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.InsuranceForms.ConcentPreviousHistory
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
    }
}
