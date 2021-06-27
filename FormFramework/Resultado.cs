using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFramework
{
    class Resultado
    {
        public int ResultadoID { get; set; }
        public Equipe Equipes { get; set; }
        public ModProva ModProvas { get; set; }
        public Leitura Leituras { get; set; }
        public float Pontuacao { get; set; }
    }
}
