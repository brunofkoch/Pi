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
        public Equipe CodEquipe { get; set; }
        public int ModProvas { get; set; }        
        public float Otimizacao { get; set; }

        private MyContext db = new MyContext();

        public void calcProvaVelocidade(int idv, int ide)
        {
            var getN = from q in db.Leituras where q.CodVeiculo.VeiculoID == idv && q.CodVeiculo.Versao == 1 select q;
            var getO = from q in db.Leituras where q.CodVeiculo.VeiculoID == idv && q.CodVeiculo.Versao == 2 select q;
            var verify = from q in db.Resultados where q.CodEquipe.EquipeID == ide && q.ModProvas == 1 select q;

            if (verify.Count() != 0)
            {
                return;
            }

            if (getN.Count() != 0 && getO.Count() != 0)
            {
                this.CodEquipe = db.Equipes.Find(ide);
                this.ModProvas = 1;
                this.Otimizacao = (getO.First().Media - getN.First().Media) * 100;
                db.Resultados.Add(this);
                db.SaveChanges();
                return;
                
            }            
            this.Otimizacao = 0;
            this.CodEquipe = db.Equipes.Find(ide);
            this.ModProvas = 1;
            db.Resultados.Add(this);
            db.SaveChanges();
        }
    }
}
