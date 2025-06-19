using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class EMR_Patient
    {
        public static DataSet GetPatientEMRInfo(int? appId)
        {
            return DataAccessLayer.EMR.EMR_Patient.GetPatientEMRInfo(appId);
        }
    }
}