using BusinessEntities.EMR;
using BusinessEntities.Invoice;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EMR
{
    public class HardTissue
    {
        public static int InsertUpdateIntraOralHardTissue(BusinessEntities.EMR.HardTissue data, int cht_madeby)
        {
            int chtId = 0;
            int Id = 0;
            List<HardTissue_tooth> list = data.HardTissue_tooth_items;
            //List<HardTissue_tooth> list = data.HardTissue_tooth_items;
            //Patient hardtissues

            BusinessEntities.EMR.IntraOralHardTissue hardtissue = new BusinessEntities.EMR.IntraOralHardTissue();
                hardtissue.cht_appId = data.hard_tissue_info.cht_appId;
                hardtissue.cht_1 = string.IsNullOrEmpty(data.hard_tissue_info.cht_1) ? string.Empty : data.hard_tissue_info.cht_1;
                hardtissue.cht_2 = string.IsNullOrEmpty(data.hard_tissue_info.cht_2) ? string.Empty : data.hard_tissue_info.cht_2;
                hardtissue.cht_3 = string.IsNullOrEmpty(data.hard_tissue_info.cht_3) ? string.Empty : data.hard_tissue_info.cht_3;
                hardtissue.cht_4 = string.IsNullOrEmpty(data.hard_tissue_info.cht_4) ? string.Empty : data.hard_tissue_info.cht_4;
                hardtissue.cht_5 = string.IsNullOrEmpty(data.hard_tissue_info.cht_5) ? string.Empty : data.hard_tissue_info.cht_5;
                hardtissue.cht_6 = string.IsNullOrEmpty(data.hard_tissue_info.cht_6) ? string.Empty : data.hard_tissue_info.cht_6;
                hardtissue.cht_7 = string.IsNullOrEmpty(data.hard_tissue_info.cht_7) ? string.Empty : data.hard_tissue_info.cht_7;
                hardtissue.cht_8 = string.IsNullOrEmpty(data.hard_tissue_info.cht_8) ? string.Empty : data.hard_tissue_info.cht_8;
                hardtissue.cht_9 = string.IsNullOrEmpty(data.hard_tissue_info.cht_9) ? string.Empty : data.hard_tissue_info.cht_9;
                hardtissue.cht_10 = string.IsNullOrEmpty(data.hard_tissue_info.cht_10) ? string.Empty : data.hard_tissue_info.cht_10;
                hardtissue.cht_11 = string.IsNullOrEmpty(data.hard_tissue_info.cht_11) ? string.Empty : data.hard_tissue_info.cht_11;
                hardtissue.cht_12 = string.IsNullOrEmpty(data.hard_tissue_info.cht_12) ? string.Empty : data.hard_tissue_info.cht_12;
                hardtissue.cht_13 = string.IsNullOrEmpty(data.hard_tissue_info.cht_13) ? string.Empty : data.hard_tissue_info.cht_13;
                hardtissue.cht_14 = string.IsNullOrEmpty(data.hard_tissue_info.cht_14) ? string.Empty : data.hard_tissue_info.cht_14;
                hardtissue.cht_15 = string.IsNullOrEmpty(data.hard_tissue_info.cht_15) ? string.Empty : data.hard_tissue_info.cht_15;
                hardtissue.cht_16 = string.IsNullOrEmpty(data.hard_tissue_info.cht_16) ? string.Empty : data.hard_tissue_info.cht_16;
                hardtissue.cht_17 = string.IsNullOrEmpty(data.hard_tissue_info.cht_17) ? string.Empty : data.hard_tissue_info.cht_17;
                hardtissue.cht_18 = string.IsNullOrEmpty(data.hard_tissue_info.cht_18) ? string.Empty : data.hard_tissue_info.cht_18;

                chtId = OralExamination.InsertUpdateIntraOralHardTissues(hardtissue, cht_madeby);


            if (chtId > 0)
            {
                if (list != null)
                {
                    //Patient Treatments
                    foreach (HardTissue_tooth i in list)
                    {
                        BusinessEntities.EMR.HardTissue_tooth _tooth = new BusinessEntities.EMR.HardTissue_tooth();
                        _tooth.chtdId = 0;
                        _tooth.chtd_appId = i.chtd_appId;
                        _tooth.chtd_1 = string.IsNullOrEmpty(i.chtd_1) ? string.Empty : i.chtd_1;
                        _tooth.chtd_2 = string.IsNullOrEmpty(i.chtd_2) ? string.Empty : i.chtd_2;
                        _tooth.chtd_3 = string.IsNullOrEmpty(i.chtd_3) ? string.Empty : i.chtd_3;
                        _tooth.chtd_madeby = cht_madeby;


                        Id = OralExamination.InsertUpdateHardTissuetooth(_tooth, chtId, cht_madeby);
                    }
                }
            }
            
            return chtId;

        }

    }
}
