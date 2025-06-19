using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Tab
{
    public class Feedback
    {
        public static List<BusinessEntities.Tab.Feedback> GetFeedbackData(int appId)
        {
            DataTable dt = DataAccessLayer.Tab.Feedback.GetFeedbackData(appId);

            List<BusinessEntities.Tab.Feedback> list = new List<BusinessEntities.Tab.Feedback>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new BusinessEntities.Tab.Feedback
                    {
                        cpfId = Convert.ToInt32(dr["cpfId"]),
                        cpf_appId = Convert.ToInt32(dr["cpf_appId"]),
                        cpf_text = dr["cpf_text"].ToString(),
                        cpf_status = dr["cpf_status"].ToString(),
                        cpf_date_modified = Convert.ToDateTime(dr["cpf_date_modified"].ToString())
                    });
                }
            }

            return list;
        }

        public static int SaveFeedback(BusinessEntities.Tab.Feedback feed)
        {
            return DataAccessLayer.Tab.Feedback.SaveFeedback(feed);
        }
    }
}