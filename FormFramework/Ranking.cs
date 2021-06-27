using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFramework
{
    class Ranking
    {
        public int RankingID { get; set; }
        public int Colocacao { get; set; }
        public int EtapaCompeticao { get; set; }
        public Resultado Resultados { get; set; }
        public ModProva ModProvas { get; set; }
        
    }
}
