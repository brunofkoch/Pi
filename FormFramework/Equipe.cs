using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFramework
{
    class Equipe
    {
        public int EquipeID { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int Tipo_User { get; set; }

        MyContext db = new MyContext();

        public void createEquipe(string nome, string senha, int tipoUser)
        {
            this.Nome = nome.ToUpper();
            this.Senha = senha;
            this.Tipo_User = tipoUser;
            db.Equipes.Add(this);
            db.SaveChanges();
        }

        public void updateEquipe(int id, string nome, string senha)
        {
            Equipe equipe = db.Equipes.Find(id);
            equipe.Nome = nome.ToUpper();
            equipe.Senha = senha;
            db.Entry(equipe).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public int verificaEquipe(string nome, string senha)
        {
            // Essa função é utilizada para quando a Equipe é criada ela retorna o ID de criação da Equipe
            var query = (from eq in db.Equipes where eq.Nome == nome && eq.Senha == senha select new { ID = eq.EquipeID }).First();
            return query.ID;
        }

        public int verificaEquipe(int id, string senha)
        {
            // Essa função verifica se o ID e SENHA possui correspondencia no banco de dados para realizar o login
            var query = (from eq in db.Equipes where eq.EquipeID == id && eq.Senha == senha select new { ID = eq.EquipeID });

            if (query.Count() != 0)
            {
                return query.First().ID;
            }
            return 0;

        }

        public void deleteEquipe(int i)
        {
            Equipe equipe = db.Equipes.Find(i);
            db.Equipes.Remove(equipe);
            db.SaveChanges();
        }
    }
}
