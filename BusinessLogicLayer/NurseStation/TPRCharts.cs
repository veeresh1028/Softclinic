using BusinessEntities.NurseStation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.NurseStation
{
    public class TPRCharts
    {
        #region TPRChart
        public static TRPChartData GetTPRStatChart(int patId, string app_fdate)
        {
            TRPChartData data = new TRPChartData();
            DataTable dt = DataAccessLayer.NurseStation.TPRCharts.GetTPRStatChart(patId, app_fdate);

            List<string> labels = new List<string>();
            List<string> tempratures = new List<string>();
            tempratures.Add("data1");
            List<string> respiratorys = new List<string>();
            respiratorys.Add("data2");
            List<string> pulses = new List<string>();
            pulses.Add("data3");
            List<string> weights = new List<string>();
            weights.Add("data4");
            List<string> bmi = new List<string>();
            bmi.Add("data5");

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    labels.Add(dr["emp_name"].ToString() + " " + " \n " + " " + DateTime.Parse(dr["app_fdate"].ToString()).ToString("dd/MM/yyyy"));
                    tempratures.Add(string.IsNullOrEmpty(dr["sign_temp"].ToString()) ? "0" : dr["sign_temp"].ToString());
                    pulses.Add(string.IsNullOrEmpty(dr["sign_pulse"].ToString()) ? "0" : dr["sign_pulse"].ToString());
                    respiratorys.Add(string.IsNullOrEmpty(dr["sign_resp"].ToString()) ? "0" : dr["sign_resp"].ToString());
                    weights.Add(string.IsNullOrEmpty(dr["sign_weight"].ToString()) ? "0" : dr["sign_weight"].ToString());
                    bmi.Add(string.IsNullOrEmpty(dr["sign_bmi"].ToString()) ? "0" : dr["sign_bmi"].ToString());
                }
            }

            data.labels = labels;
            data.tempratures = tempratures;
            data.pulses = pulses;
            data.weights = weights;
            data.bmi = bmi;
            data.respiratorys = respiratorys;

            return data;
        }

        #endregion TPRChart
    }
}
