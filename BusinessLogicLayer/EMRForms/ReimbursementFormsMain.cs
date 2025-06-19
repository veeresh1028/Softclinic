using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMRForms
{
    public class ReimbursementFormsMain
    {

        public static List<CommonDDLFORMS> GetReimbForms()
        {
            List<CommonDDLFORMS> branchlist = new List<CommonDDLFORMS>();

            DataTable dt = DataAccessLayer.EMRForms.ReimbursementFormsMain.GetReimbForms();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    branchlist.Add(new CommonDDLFORMS
                    {
                        id = dr["id"].ToString(),
                        text = dr["text"].ToString()
                    });
                }
            }

            return branchlist;
        }

    }
}