using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FormFramework
{
    class MyContext : DbContext
    {
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }        
        public DbSet<Leitura> Leituras { get; set; }
        public DbSet<Prova> ModProvas { get; set; }
        public DbSet<Resultado> Resultados { get; set; }
        
    }
}
