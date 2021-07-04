using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormFramework
{
    public partial class AreaEquipe : Form
    {
        private int IdEquipe;        
        private MyContext db = new MyContext();


        public AreaEquipe()
        {
            InitializeComponent();
        }

        public AreaEquipe(int IDE)
        {
            InitializeComponent();
            this.IdEquipe = IDE;           
        }

        private void AreaEquipe_Load(object sender, EventArgs e)
        {
             
        }

        private void AreaEquipe_Close(object sender, EventArgs e)
        {
            // Chama o Form login que esta rodando em background 
            Form lg = Application.OpenForms["Login"];
            lg.Show();            
        }

        private void cadastrarIntegrantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadAluno cAluno = new CadAluno(this.IdEquipe);
            cAluno.MdiParent = this;
            cAluno.Show();
            
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            this.Close();            
        }

       
        private void informaçõesNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            // Chama a janela para cadastrar as informações do veiculo passando dois parametros:
            // O Id do veiculo e o numero que referece a sua versão, nessa caso a versão normal.
            CadVeiculo cVeiculo = new CadVeiculo(this.IdEquipe, 1); // o numero '1' é referente ao veiculo na versao normal
            cVeiculo.MdiParent = this;
            cVeiculo.Show();
        }
               
        private void informaçõesOtimizadaToolStripMenuItem1_Click(object sender, EventArgs e)
        {           
            // Chama a janela para cadastrar as informações do veiculo passando dois parametros:
            // O Id do veiculo e o numero que referece a sua versão, nessa caso a versão otimizada.
            CadVeiculo cVeiculo = new CadVeiculo(this.IdEquipe, 2);// o numero '2' é referente ao veiculo na versao otmizada
            cVeiculo.MdiParent = this;
            cVeiculo.Show();
        }

        private void leiturasNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadLeituras leituras = new CadLeituras(this.IdEquipe, 1);
            leituras.MdiParent = this;
            leituras.Show();
        }

        private void leiturasOtimizadaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CadLeituras leituras = new CadLeituras(this.IdEquipe, 2);
            leituras.MdiParent = this;
            leituras.Show();
        }
    }
}
