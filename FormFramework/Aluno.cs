using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFramework
{
    class Aluno
    {
        public int AlunoID { get; set; }
        public string Nome { get; set; }
        public Equipe Equipe { get; set; }

        MyContext db = new MyContext();

        public void createAluno(int equipe, string nome)
        {
            this.Nome = nome.ToUpper();
            this.Equipe = db.Equipes.Find(equipe);
            db.Alunos.Add(this);
            db.SaveChanges();
        }

        public void updateAluno(int idEquipe, int idAluno, string nome)
        {
            Aluno aluno = db.Alunos.Find(idAluno);
            aluno.Nome = nome.ToUpper();
            aluno.Equipe = db.Equipes.Find(idEquipe);
            db.Entry(aluno).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void deleteAluno(int idAluno)
        {
            // Verifica id do aluno para não retornar erro de 'Expression NotNull'
            if (idAluno != 0)
            {
                Aluno aluno = db.Alunos.Find(idAluno);
                db.Alunos.Remove(aluno);
            }            
            db.SaveChanges();
        }


        
    }
}