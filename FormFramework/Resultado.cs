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

        private MyContext db = new MyContext();

        public float calcProvaVelocidade(int Veiculo_ID)
        {
            // Localiza os ID das leituras referente ao Veiculo Nomal e o Veiculo Otimizado
            var getNormal_id = (from q in db.Leituras where q.DescMedVeiculo.Veiculo.VeiculoID == Veiculo_ID && q.DescMedVeiculo.Versao == 1 && q.NumProva == 1 select q);
            var getOtimizado_id = (from q in db.Leituras where q.DescMedVeiculo.Veiculo.VeiculoID == Veiculo_ID && q.DescMedVeiculo.Versao == 2 && q.NumProva == 1 select q);

            if (getNormal_id.Count() != 0 && getOtimizado_id.Count() != 0)
            {
                Leitura Normal = db.Leituras.Find(getNormal_id.First().LeituraID);
                Leitura Otimizado = db.Leituras.Find(getOtimizado_id.First().LeituraID);

                // Atribui os valores das medias de cada veiculo
                float medNormal = Normal.Media;
                float medOtimizado = Otimizado.Media;


                //float melhoria = (((medOtimizado * 100) / medNormal) - 100) * (-1);
                float melhoria = ((medNormal - medOtimizado) / medNormal) * 100;

                return melhoria;
            }

            // Localiza as leituras atraves dos ID encontrados na query acima
            return 0;
        }





    }
}
