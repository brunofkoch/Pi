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
        private int IdVeiculo;
        private MyContext db = new MyContext();


        public AreaEquipe()
        {
            InitializeComponent();
        }

        public AreaEquipe(int IDE)
        {
            InitializeComponent();
            this.IdEquipe = IDE;

            // Quando é criado uma equipe automaticamente é criado o identificador do veiculo
            // Nesse campo é passdo o identificador da equipe para encontra o seu respectivo veiculo
            Veiculo veiculo = new Veiculo();
            int IDV = veiculo.verificaVeiculo(IDE);
            this.IdVeiculo = IDV;
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
            // Retorna o ID do veiculo que referece a Equipe
            Veiculo veiculo = new Veiculo();
            int IDV = veiculo.verificaVeiculo(this.IdEquipe);
            // Chama a janela para cadastrar as informações do veiculo passando dois parametros:
            // O Id do veiculo e o numero que referece a sua versão, nessa caso a versão normal.
            CadVeiculo cVeiculo = new CadVeiculo(this.IdEquipe, IDV, 1); // o numero '1' é referente ao veiculo na versao normal
            cVeiculo.MdiParent = this;
            cVeiculo.Show();
        }
               
        private void informaçõesOtimizadaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Retorna o ID do veiculo que referece a Equipe
            Veiculo veiculo = new Veiculo();
            int IDV = veiculo.verificaVeiculo(this.IdEquipe);
            // Chama a janela para cadastrar as informações do veiculo passando dois parametros:
            // O Id do veiculo e o numero que referece a sua versão, nessa caso a versão otimizada.
            CadVeiculo cVeiculo = new CadVeiculo(this.IdEquipe, IDV, 2);// o numero '2' é referente ao veiculo na versao otmizada
            cVeiculo.MdiParent = this;
            cVeiculo.Show();
        }

        private void leiturasNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Leituras leituras = new Leituras(this.IdVeiculo, 1);
            leituras.MdiParent = this;
            leituras.Show();
        }

        private void leiturasOtimizadaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Leituras leituras = new Leituras(this.IdVeiculo, 2);
            leituras.MdiParent = this;
            leituras.Show();
        }
    }
}
