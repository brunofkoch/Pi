using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFramework
{
    class DescMed
    {
        // Descrições
        public int DescMedID { get; set; }
        public Veiculo Veiculo { get; set; }
        public int Versao { get; set; }
        public string TipoVeiculo { get; set; }
        public string MatCarroceria { get; set; }
        public string CorCarroceria { get; set; }
        public int QtdRodas { get; set; }
        public int VoltControle { get; set; }
        public int VoltMotor { get; set; }
        public int Valor { get; set; }
        public string link_video { get; set; }

        // Medidas                
        public float DiametroRodas { get; set; }
        public float AlturaTotalVeiculo { get; set; }
        public float AlturaDoChao { get; set; }
        public float LarguraVeiculo { get; set; }
        public float ComprimentoVeiculo { get; set; }
        public float Passo { get; set; }
        public float BitolaDianteira { get; set; }
        public float BitolaTraseira { get; set; }
        public float PessoTotalVeiculo { get; set; }
        public DateTime UltimaModificacao { get; set; }

        private MyContext db = new MyContext();


        public void createDescMed(int idVeiculo, int versao, string tipVeiculo, string matCarr,
            string corCarr, int qtdR, int volC, int volM, int valor, float diaRodas, float altVeiculo, float altChao,
            float larVeiculo, float compVeiculo, float passo, float bitDiant, float bitTras, float pesTotal)
        {
            this.Veiculo = db.Veiculos.Find(idVeiculo);
            this.Versao = versao;
            this.TipoVeiculo = tipVeiculo.ToUpper();
            this.MatCarroceria = matCarr.ToUpper();
            this.CorCarroceria = corCarr.ToUpper();
            this.QtdRodas = qtdR;
            this.VoltControle = volC;
            this.VoltMotor = volM;
            this.Valor = valor;

            this.DiametroRodas = diaRodas;
            this.AlturaTotalVeiculo = altVeiculo;
            this.AlturaDoChao = altChao;
            this.LarguraVeiculo = larVeiculo;
            this.ComprimentoVeiculo = compVeiculo;
            this.Passo = passo;
            this.BitolaDianteira = bitDiant;
            this.BitolaTraseira = bitTras;
            this.PessoTotalVeiculo = pesTotal;

            this.UltimaModificacao = DateTime.Now;
            
            db.DescMeds.Add(this);
            db.SaveChanges();
        }

        public void updateDescMed(int idVeiculo, int versao, string tipVeiculo, string matCarr,
            string corCarr, int qtdR, int volC, int volM, int valor, float diaRodas, float altVeiculo, float altChao,
            float larVeiculo, float compVeiculo, float passo, float bitDiant, float bitTras, float pesTotal)
        {
            var query = (from q in db.DescMeds
                        where q.Veiculo.VeiculoID == idVeiculo
                        &&
                        q.Versao == versao
                        select q).First();

            DescMed result = db.DescMeds.Find(query.DescMedID);

            result.TipoVeiculo = tipVeiculo.ToUpper();
            result.MatCarroceria = matCarr.ToUpper();
            result.CorCarroceria = corCarr.ToUpper();
            result.QtdRodas = qtdR;
            result.VoltControle = volC;
            result.VoltMotor = volM;
            result.Valor = valor;

            result.DiametroRodas = diaRodas;
            result.AlturaTotalVeiculo = altVeiculo;
            result.AlturaDoChao = altChao;
            result.LarguraVeiculo = larVeiculo;
            result.ComprimentoVeiculo = compVeiculo;
            result.Passo = passo;
            result.BitolaDianteira = bitDiant;
            result.BitolaTraseira = bitTras;
            result.PessoTotalVeiculo = pesTotal;

            result.UltimaModificacao = DateTime.Now;


            db.Entry(result).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

        }


        public void removeDecMed(int idVeiculo, int versao)
        {
            var query1 = (from q1 in db.DescMeds
                         where q1.Veiculo.VeiculoID == idVeiculo
                         &&
                         q1.Versao == versao
                         select q1).First().DescMedID;

            var query2 = (from q2 in db.Leituras
                         where q2.DescMedVeiculo.DescMedID == query1
                         select q2).First();

            if (!query2.Equals(""))
            {
                Leitura leit = db.Leituras.Find(query2.LeituraID);
                db.Leituras.Remove(leit);
            }
            if (query1.Equals(""))
            {
                DescMed result = db.DescMeds.Find(query1);
                db.DescMeds.Remove(result);
            }            
            db.SaveChanges();

        }


        public int getId(int IDV, int VV)
        {
            
            var query = from q in db.DescMeds
                         where q.Veiculo.VeiculoID == IDV
                         &&
                         q.Versao == VV
                         select new { id=q.DescMedID};

            if (query.Count() == 0)
            {
                return 0;
            }            
            return query.First().id;
        }

    }
}
