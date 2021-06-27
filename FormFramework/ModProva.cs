using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFramework
{
    class ModProva
    {
        public int ModProvaID { get; set; }
        public int NumProva { get; set; }
        public string Nome { get; set; }
        public string Infos { get; set; }

        private MyContext db = new MyContext();

        public ModProva()
        {
            var query = (from q in db.ModProvas select q);
           if(query.Count() == 0)
            {
                StartModalidade();
            }
        }
        

        public void CreateModProva(int id, string nome, string info)
        {
            this.NumProva = id;
            this.Nome = nome;
            this.Infos = info;
            db.ModProvas.Add(this);
            db.SaveChanges();
        }
        

        public void StartModalidade()
        {
            CreateModProva(1, "VELOCIDADE", "LInha dos 10 metros.");
            CreateModProva(2, "TRAÇÃO", "Puxar peso.");
            CreateModProva(3, "SLALON", "Prova dos cones.");
            CreateModProva(4, "RAMPA", "Potencia.");
        }

    }
}
