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
            this.L1 = l1;
            this.L2 = l2;
            this.L3 = l3;
            this.L4 = l4;
            this.DescMedVeiculo = query.First();
            this.NumProva = idp;
            this.Media = (l1 + l2 + l3 + l4) / 4;

            db.Leituras.Add(this);
            db.SaveChanges();
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
