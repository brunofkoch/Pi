using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFramework
{
    class Leitura
    {
        public int LeituraID { get; set; }
        public float L1 { get; set; }
        public float L2 { get; set; }
        public float L3 { get; set; }
        public float L4 { get; set; }
        public float Media { get; set; }
        public Veiculo CodVeiculo { get; set; }
        public int NumProva { get; set; }

        private MyContext db = new MyContext();


        public bool createLeitura(int ide, int vv, int idp, float l1, float l2, float l3, float l4)
        {            
            // Retorna o id da descriçaõ medida da versão do veiculo
            var query = from q in db.Veiculos
                         where q.CodEquipe.EquipeID == ide
                         &&
                         q.Versao == vv
                         select q;

            if (query.Count() == 0)
            {
                return false;
            } 
            switch (idp)
            {
                case 1:
                    // Média para Prova de Velocidade
                    // Gera a média das leituras e converte em "Metros por Segundo"
                    // O numeral 10 é referente a distancia percorrida = '10 metros'                       
                    this.L1 = l1;
                    this.L2 = l2;
                    this.L3 = l3;
                    this.L4 = l4;
                    this.Media = 10 / ((l1 + l2 + l3 + l4) / 4);
                    this.CodVeiculo = query.First();
                    this.NumProva = idp;                    
                    break;
                case 2:
                    // Média para Prova Tração
                    this.CodVeiculo = query.First();
                    this.NumProva = idp;
                    this.L1 = l1;  // ganbiarra kk'                  
                    this.L2 = l2;   // ganbiarra kk'
                    this.L3 = l3;   // ganbiarra kk'
                    this.L4 = l4;   // ganbiarra kk'
                    this.Media = l1;
                    break;
                case 3:
                    // Média para Prova Slalon
                    this.L1 = l1;
                    this.L2 = l2;
                    this.L3 = l3;
                    this.L4 = l4;
                    this.Media = ( (l1 + l2 + l3 + l4) / 4 );
                    this.CodVeiculo = query.First();
                    this.NumProva = idp;
                    break;
                case 4:
                    // Média para Prova Rampa
                    this.L1 = l1;
                    this.L2 = l2;
                    this.L3 = l3;
                    this.L4 = l4;
                    this.Media = ((l1 + l2 + l3 + l4) / 4);
                    this.CodVeiculo = query.First();
                    this.NumProva = idp;
                    break;
                default:
                    break;
            }            
            db.Leituras.Add(this);
            db.SaveChanges();
            return true;
        }


        public bool removeLeitura(int id)
        {
            if(id != 0)
            {
                var result = (from q in db.Leituras where q.LeituraID == id select q).First();
                db.Leituras.Remove(result);
                db.SaveChanges();
                return true;               
            }
            return false;
        }

        public bool VerificaExistencia(int NumProva, int idVeiculo)
        {
            var query = from q in db.Leituras where q.NumProva == NumProva && q.CodVeiculo.VeiculoID == idVeiculo select q;
            if (query.Count() != 0)
                return true;

            return false;
        }


        public Leitura returnObeject(int numprova, int idVeiculo)
        {
            var query = from q in db.Leituras where q.NumProva == numprova && q.CodVeiculo.VeiculoID == idVeiculo select q;
            if (query.Count() == 0)
                return null;
            return query.First();
        }
    }
}
