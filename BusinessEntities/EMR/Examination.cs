using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class Examination
    {
        public GeneralExamination genex { get; set; }
        public List<GeneralExamination> genexam { get; set; }
        public RespiratorySystem resp { get; set; }
        public List<RespiratorySystem> respiratory { get; set; }
        public CardioVascular card { get; set; }
        public List<CardioVascular> cardio { get; set; }
        public CentralNervous nerv { get; set; }
        public List<CentralNervous> nervous { get; set; }
        public GastroIntestinal gast { get; set; }
        public List<GastroIntestinal> gastro { get; set; }
        public GenitoUrinary geni { get; set; }
        public List<GenitoUrinary> genito { get; set; }
        public MusculoSkeletal musc { get; set; }
        public List<MusculoSkeletal> musculo { get; set; }

    }

}