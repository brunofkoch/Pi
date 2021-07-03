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
        public DescMed DescMedVeiculo { get; set; }
        public int NumProva { get; set; }

        private MyContext db = new MyContext();


        public void createLeitura(int idv, int vv, int idp, float l1, float l2, float l3, float l4)
        {            
            // Retorna o id da descriçaõ medida da versão do veiculo
            var query = from q in db.DescMeds
                         where q.Veiculo.VeiculoID == idv
                         &&
                         q.Versao == vv
                         select q;            
            

            switch (idp)
            {
                case 1:
                    // Média para Prova de Velocidade
                    // Gera a média das leituras e converte em "Metros por Segundo"
                    // O numeral 10 é referente a distancia percorrida = '10 metros'            
                    this.Media = 10 / ((l1 + l2 + l3 + l4) / 4);
                    this.L1 = l1;
                    this.L2 = l2;
                    this.L3 = l3;
                    this.L4 = l4;
                    this.DescMedVeiculo = query.First();
                    this.NumProva = idp;
                    break;
                case 2:
                    // Média para Prova Tração
                    this.DescMedVeiculo = query.First();
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
                    this.DescMedVeiculo = query.First();
                    this.NumProva = idp;
                    break;
                case 4:
                    // Média para Prova Rampa
                    this.L1 = l1;
                    this.L2 = l2;
                    this.L3 = l3;
                    this.L4 = l4;
                    this.Media = ((l1 + l2 + l3 + l4) / 4);
                    this.DescMedVeiculo = query.First();
                    this.NumProva = idp;
                    break;
                default:
                    break;
            }           

            db.Leituras.Add(this);
            db.SaveChanges();
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

        public bool VerificaExistencia(int NumProva, int idDescMed)
        {
            var query = from q in db.Leituras where q.NumProva == NumProva && q.DescMedVeiculo.DescMedID == idDescMed select q;
            if (query.Count() != 0)
                return true;

            return false;
        }


        public Leitura returnObeject(int numprova, int idDescMed)
        {
            var query = from q in db.Leituras where q.NumProva == numprova && q.DescMedVeiculo.DescMedID == idDescMed select q;
            if (query.Count() == 0)
                return null;
            return query.First();
        }
    }
}
