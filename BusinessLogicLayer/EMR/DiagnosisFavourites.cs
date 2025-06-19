using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class DiagnosisFavourites
    {
        #region Diagnosis Favourites (Page Load)
        public static List<BusinessEntities.EMR.DiagnosisFavourites> GetAllDiagnosisFavourites(int? empId, int? pdfId)
        {
            List<BusinessEntities.EMR.DiagnosisFavourites> sclist = new List<BusinessEntities.EMR.DiagnosisFavourites>();
            DataTable dt = DataAccessLayer.EMR.DiagnosisFavourites.GetAllDiagnosisFavourites(empId, pdfId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.DiagnosisFavourites
                {
                    pdfId = Convert.ToInt32(dr["pdfId"]),
                    pdf_empId = Convert.ToInt32(dr["pdf_empId"]),
                    diag_name = dr["diag_name"].ToString(),
                    pdf_notes = dr["pdf_notes"].ToString(),
                    pdf_diagnosis = Convert.ToInt32(dr["pdf_diagnosis"].ToString()),
                    diag_code = dr["diag_code"].ToString(),
                    diag_class = dr["diag_class"].ToString(),
                    pdf_status = dr["pdf_status"].ToString(),


                });
            }
            return sclist;
        }
        #endregion Diagnosis Favourites (Page Load)

        #region Diagnosis Favourites CRUD Operations

        public static int InsertUpdateDiagnosisFavourites(BusinessEntities.EMR.DiagnosisFavourites data)
        {
            return DataAccessLayer.EMR.DiagnosisFavourites.InsertUpdateDiagnosisFavourites(data);
        }
        public static int DeleteDiagnosisFavourites(int pdfId, int pdf_madeby)
        {
            return DataAccessLayer.EMR.DiagnosisFavourites.DeleteDiagnosisFavourites(pdfId, pdf_madeby);
        }
        #endregion Diagnosis Favourites CRUD Operations
    }
}
