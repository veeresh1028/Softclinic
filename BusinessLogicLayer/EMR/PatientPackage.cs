using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class PatientPackage
    {
        public static BusinessEntities.EMR.PatientPackage AutoCreatepackageRefNo(int branch)
        {
            BusinessEntities.EMR.PatientPackage package = new BusinessEntities.EMR.PatientPackage();
            package.poId = 0;
            package.po_refno = DataAccessLayer.EMR.Packages.AutoCreatepackageRefNo(branch);

            return package;
        }
    }
}
