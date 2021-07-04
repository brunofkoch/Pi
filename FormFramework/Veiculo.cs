using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFramework
{
    class Veiculo
    {
        // Descrições
        public int VeiculoID { get; set; }
        public Equipe CodEquipe { get; set; }
        public int Versao { get; set; }
        public string TipoVeiculo { get; set; }
        public string MatCarroceria { get; set; }
        public string CorCarroceria { get; set; }
        public string QtdRodas { get; set; }
        public string VoltControle { get; set; }
        public string VoltMotor { get; set; }
        public string Valor { get; set; }
        public string Link_Video { get; set; }
        public string Link_Foto { get; set; }

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


        public void createVeiculo(int idEquipe, int versao, string tipVeiculo, string matCarr,
            string corCarr, string qtdR, string volC, string volM, string valor, string lkFoto, string lkVideo, float diaRodas, float altVeiculo, float altChao,
            float larVeiculo, float compVeiculo, float passo, float bitDiant, float bitTras, float pesTotal)
        {
            this.CodEquipe = db.Equipes.Find(idEquipe);
            this.Versao = versao;
            this.TipoVeiculo = tipVeiculo.ToUpper();
            this.MatCarroceria = matCarr.ToUpper();
            this.CorCarroceria = corCarr.ToUpper();
            this.QtdRodas = qtdR;
            this.VoltControle = volC;
            this.VoltMotor = volM;
            this.Valor = valor;
            this.Link_Foto = lkFoto;
            this.Link_Video = lkVideo;

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

            db.Veiculos.Add(this);
            db.SaveChanges();
        }

        public void updateVeiculo(int idEquipe, int versao, string tipVeiculo, string matCarr,
            string corCarr, string qtdR, string volC, string volM, string valor, string lkFoto, string lkVideo, float diaRodas, float altVeiculo, float altChao,
            float larVeiculo, float compVeiculo, float passo, float bitDiant, float bitTras, float pesTotal)
        {
            var query = (from q in db.Veiculos
                         where q.CodEquipe.EquipeID == idEquipe
                         &&
                         q.Versao == versao
                         select q).First();

            Veiculo result = db.Veiculos.Find(query.VeiculoID);

            result.TipoVeiculo = tipVeiculo.ToUpper();
            result.MatCarroceria = matCarr.ToUpper();
            result.CorCarroceria = corCarr.ToUpper();
            result.QtdRodas = qtdR;
            result.VoltControle = volC;
            result.VoltMotor = volM;
            result.Valor = valor;
            result.Link_Foto = lkFoto;
            result.Link_Video = lkVideo;

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


        public bool removeDecMed(int idEquipe, int versao)
        {
            var qVeiculo = (from q in db.Veiculos
                            where q.CodEquipe.EquipeID == idEquipe
                            &&
                            q.Versao == versao
                            select q);


            if (qVeiculo.Count() != 0)
            {
                var veiculo = qVeiculo.First().VeiculoID;
                var Leitura_ID = (from q2 in db.Leituras
                                  where q2.CodVeiculo.VeiculoID == veiculo
                                  select q2);
                if (Leitura_ID.Count() != 0)
                {
                    return false;
                }
                db.Veiculos.Remove(qVeiculo.First());
            }
            db.SaveChanges();
            return true;
        }


        public int getId(int IDE, int VV)
        {
            var query = from q in db.Veiculos
                        where q.CodEquipe.EquipeID == IDE
                        &&
                        q.Versao == VV
                        select new { id = q.VeiculoID };

            if (query.Count() == 0)
            {
                return 0;
            }
            return query.First().id;
        }

    }
}
