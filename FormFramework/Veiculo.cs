using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFramework
{
    class Veiculo
    {
        public int VeiculoID { get; set; }
        public Equipe Equipe { get; set; }
        public DateTime Data_Criacao { get; set; }

        MyContext db = new MyContext();


        public void createVeiculo(int idEquipe)
        {
            this.Equipe = db.Equipes.Find(idEquipe);
            this.Data_Criacao = DateTime.Now;
            db.Veiculos.Add(this);
            db.SaveChanges();
        }
                      
               

        public int verificaVeiculo(int idE)
        {
            // Verifica se a equipe possui um Veiculo cadastrado
            var q = (from v in db.Veiculos where v.Equipe.EquipeID == idE select new { idV = v.VeiculoID });

           // Verifica se a query não esta vazia. Se não estiver quer dizer que a equipe possui um veiculo cadastrado
            // Retorna o ID do Veiculo cadastrado
            if (!q.Equals(""))
            {
                return q.First().idV;
            }            
            return 0;
            
        }

        

    }
}
