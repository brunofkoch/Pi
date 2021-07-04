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
        public Veiculo CodVeiculo { get; set; }
        public int ModProvas { get; set; }        
        public float Otimizacao { get; set; }

        private MyContext db = new MyContext();

        public void calcProvaVelocidade(int idv)
        {
            
          
        }
    }
}
