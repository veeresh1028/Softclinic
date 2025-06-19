using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class Templates
    {
        #region Message Templates (Page Load)
        public static List<BusinessEntities.Masters.Templates> GetTemplates(int? TemplateId)
        {
            List<BusinessEntities.Masters.Templates> templateslist = new List<BusinessEntities.Masters.Templates>();

            DataTable dt = DataAccessLayer.Masters.Templates.GetTemplates(TemplateId);

            foreach (DataRow dr in dt.Rows)
            {
                templateslist.Add(new BusinessEntities.Masters.Templates
                {
                    TemplateId = Convert.ToInt32(dr["TemplateId"]),
                    TempStatus = dr["TempStatus"].ToString(),
                    TempWhatsapp = Convert.ToInt32(dr["TempWhatsapp"].ToString()),
                    TempSMS = Convert.ToInt32(dr["TempSMS"].ToString()),
                    TempEmail = Convert.ToInt32(dr["TempEmail"].ToString()),
                    TempContent = dr["TempContent"].ToString(),
                    TempName = dr["TempName"].ToString(),
                    TempFor = dr["TempFor"].ToString(),
                    actionvisible = dr["actionvisible"].ToString(),
                    TempCreatedTimeStamp = Convert.ToDateTime(dr["TempCreatedTimeStamp"])
                });
            }
            return templateslist;
        }
        #endregion

        #region Message Templates CRUD Operations
        public static bool InsertUpdateTemplate(BusinessEntities.Masters.Templates data)
        {
            return DataAccessLayer.Masters.Templates.InsertUpdateTemplate(data);
        }

        public static int UpdateTemplateStatus(int TemplateId, string TempStatus)
        {
            return DataAccessLayer.Masters.Templates.UpdateTemplateStatus(TemplateId, TempStatus);
        }
        #endregion
    }
}