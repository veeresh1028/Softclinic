using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Common
{
    public class AppJourney
    {
        #region AppJourney
        public static void InsertAppJourney(BusinessEntities.Common.AppJourney appJourney)
        {
            DataAccessLayer.Common.AppJourney.InsertAppJourney(appJourney);
        }
        #endregion
    }
}
