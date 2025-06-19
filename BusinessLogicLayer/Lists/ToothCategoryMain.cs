using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Lists
{
    public class ToothCategoryMain
    {
        public static DataTable GetToothCategoryMain(int? ctcyId)
        {
            return DataAccessLayer.Lists.ToothCategoryMain.GetToothCategoryMain(ctcyId);
        }

        public static DataTable GetToothSubCategory(int? ctsyId, int? ctsy_code)
        {
            return DataAccessLayer.Lists.ToothCategoryMain.GetToothSubCategory(ctsyId, ctsy_code);
        }

        public static List<GetByName> GetActiveTreatmentCodes()
        {
            DataTable dt = DataAccessLayer.Lists.ToothCategoryMain.GetActiveTreatmentCodes();

            List<GetByName> codes = new List<GetByName>();

            codes.Add(new GetByName { id = "", text = "Select Procedure" });

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    codes.Add(new GetByName
                    {
                        id = dr["tr_code"].ToString(),
                        text = dr["trcode_name"].ToString()
                    });
                }
            }

            return codes;
        }
    }
}
