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
    public partial class CadVeiculo : Form
    {
        private int VersaoVeiculo;        
        private int IdEquipe;
        private MyContext db = new MyContext();

        public CadVeiculo()
        {
            InitializeComponent();
        }

        public CadVeiculo(int IDE,int VV)
        {
            InitializeComponent();
            this.IdEquipe = IDE;            
            this.VersaoVeiculo = VV;            
        }


        private void CadVeiculo_Load(object sender, EventArgs e)
        {            
            var query = from q in db.Veiculos 
                        where q.CodEquipe.EquipeID == this.IdEquipe 
                        && 
                        q.Versao == this.VersaoVeiculo 
                        select q;

            // Esconde o botão atualizar se nem um registro existir
            buttonAtualiza.Hide();
            buttonRemover.Hide();

            if (query.Count() != 0)
            {
                // Esconde o botão cadastrar e mostra o motão atualizar
                buttonCadastrar.Hide();
                buttonAtualiza.Show();
                buttonRemover.Show();

                // Atribui os valores nos textbox do form
                var result = query.First();
                textBoxTipoVeiculo.Text = result.TipoVeiculo;
                textBoxMatCarroceira.Text = result.MatCarroceria;
                textBoxCorCarroceria.Text = result.CorCarroceria;
                textBoxQtdRodas.Text = result.QtdRodas.ToString();
                textBoxVoltControle.Text = result.VoltControle.ToString();
                textBoxVoltMotor.Text = result.VoltMotor.ToString();
                textBoxValorVeiculo.Text = result.Valor.ToString();
                textBoxDiametroRodas.Text = result.DiametroRodas.ToString();
                textBoxAltTotalVeiculo.Text = result.AlturaTotalVeiculo.ToString();
                textBoxLargTotalVeiculo.Text = result.LarguraVeiculo.ToString();
                textBoxAltChao.Text = result.AlturaDoChao.ToString();
                textBoxBitDianteira.Text = result.BitolaDianteira.ToString();
                textBoxBitTraseira.Text = result.BitolaTraseira.ToString();
                textBoxPasso.Text = result.Passo.ToString();
                textBoxPesoVeiculo.Text = result.PessoTotalVeiculo.ToString();
                textBoxCompTotalVeiculo.Text = result.ComprimentoVeiculo.ToString();
                textBoxLinkFoto.Text = result.Link_Foto.ToString();
                textBoxLinkVideo.Text = result.Link_Video.ToString();
            }

        }

        private void CadVeiculo_Close(object sender, EventArgs e)
        {
            Form areaEquipe = Application.OpenForms["AreaEquipe"];
            areaEquipe.Show();            
        }



        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            // Validação dos inputs para verificar se todos os campos estão preenchidos
            if (String.IsNullOrEmpty(textBoxTipoVeiculo.Text)|| String.IsNullOrEmpty(textBoxQtdRodas.Text) || String.IsNullOrEmpty(textBoxMatCarroceira.Text)||
                String.IsNullOrEmpty(textBoxCorCarroceria.Text) || String.IsNullOrEmpty(textBoxVoltMotor.Text) || String.IsNullOrEmpty(textBoxVoltControle.Text) || String.IsNullOrEmpty(textBoxValorVeiculo.Text))
            {
                MessageBox.Show("Preencher todos os campos", "AVISO!");
                return;
            }
            if (String.IsNullOrEmpty(textBoxDiametroRodas.Text) || String.IsNullOrEmpty(textBoxAltTotalVeiculo.Text) || String.IsNullOrEmpty(textBoxLargTotalVeiculo.Text) || String.IsNullOrEmpty(textBoxBitDianteira.Text) ||
               String.IsNullOrEmpty(textBoxLinkVideo.Text) || String.IsNullOrEmpty(textBoxLinkFoto.Text) || String.IsNullOrEmpty(textBoxBitTraseira.Text) || String.IsNullOrEmpty(textBoxPasso.Text) || String.IsNullOrEmpty(textBoxPesoVeiculo.Text) || String.IsNullOrEmpty(textBoxCompTotalVeiculo.Text) || String.IsNullOrEmpty(textBoxAltChao.Text))
            {
                MessageBox.Show("Preencher todos os campos", "AVISO!");
                return;
            }


            Veiculo veiculo = new Veiculo();
            // Chama a função de criar descrição do veículo
            veiculo.createVeiculo(
                this.IdEquipe, 
                this.VersaoVeiculo,
                textBoxTipoVeiculo.Text, 
                textBoxMatCarroceira.Text, 
                textBoxCorCarroceria.Text,
                textBoxQtdRodas.Text,
                textBoxVoltControle.Text,
                textBoxVoltMotor.Text,
                textBoxValorVeiculo.Text,
                textBoxLinkFoto.Text,
                textBoxLinkVideo.Text,
                float.Parse(textBoxDiametroRodas.Text),
                float.Parse(textBoxAltTotalVeiculo.Text),
                float.Parse(textBoxLargTotalVeiculo.Text),
                float.Parse(textBoxAltChao.Text),
                float.Parse(textBoxBitDianteira.Text),
                float.Parse(textBoxBitTraseira.Text),
                float.Parse(textBoxPasso.Text),
                float.Parse(textBoxPesoVeiculo.Text),
                float.Parse(textBoxCompTotalVeiculo.Text)
                );

            buttonCadastrar.Hide();
            buttonAtualiza.Show();
            buttonRemover.Show();

            MessageBox.Show("Informações Salvas!", "AVISO!");
        }

        private void buttonAtualiza_Click(object sender, EventArgs e)
        {
            Veiculo veiculo = new Veiculo();
            // Chama a função de criar descrição do veículo
            veiculo.updateVeiculo(
                this.IdEquipe,
                this.VersaoVeiculo,
                textBoxTipoVeiculo.Text,
                textBoxMatCarroceira.Text,
                textBoxCorCarroceria.Text,
                textBoxQtdRodas.Text,
                textBoxVoltControle.Text,
                textBoxVoltMotor.Text,
                textBoxValorVeiculo.Text,
                textBoxLinkFoto.Text,
                textBoxLinkVideo.Text,
                float.Parse(textBoxDiametroRodas.Text),
                float.Parse(textBoxAltTotalVeiculo.Text),
                float.Parse(textBoxLargTotalVeiculo.Text),
                float.Parse(textBoxAltChao.Text),
                float.Parse(textBoxBitDianteira.Text),
                float.Parse(textBoxBitTraseira.Text),
                float.Parse(textBoxPasso.Text),
                float.Parse(textBoxPesoVeiculo.Text),
                float.Parse(textBoxCompTotalVeiculo.Text)
                );
            MessageBox.Show("Informações Atualizadas!", "AVISO!");
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            Veiculo veiculo = new Veiculo();
            if (!veiculo.removeDecMed(this.IdEquipe, this.VersaoVeiculo))
            {
                MessageBox.Show("Exitem leituras cadastradas!", "AVISO!");
                return;
            }           

            textBoxTipoVeiculo.Clear();
            textBoxMatCarroceira.Clear();
            textBoxCorCarroceria.Clear();
            textBoxQtdRodas.Clear();
            textBoxVoltControle.Clear();
            textBoxVoltMotor.Clear();
            textBoxValorVeiculo.Clear();
            textBoxDiametroRodas.Clear();
            textBoxAltTotalVeiculo.Clear();
            textBoxLargTotalVeiculo.Clear();
            textBoxAltChao.Clear();
            textBoxBitDianteira.Clear();
            textBoxBitTraseira.Clear();
            textBoxPasso.Clear();
            textBoxPesoVeiculo.Clear();
            textBoxCompTotalVeiculo.Clear();
            textBoxLinkFoto.Clear();
            textBoxLinkVideo.Clear();
            
            buttonAtualiza.Hide();
            buttonRemover.Hide();

            MessageBox.Show("Informações Removidas", "AVISO!");
            buttonCadastrar.Show();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadLeituras leituras = new CadLeituras(this.IdEquipe, this.VersaoVeiculo);
            leituras.MdiParent = Application.OpenForms["AreaEquipe"];
            leituras.Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBoxVoltMotor_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
