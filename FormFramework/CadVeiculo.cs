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
        private int IdVeiculo;
        private int IdEquipe;
        private MyContext db = new MyContext();

        public CadVeiculo()
        {
            InitializeComponent();
        }

        public CadVeiculo(int IDE, int IDV, int VV)
        {
            InitializeComponent();
            this.IdEquipe = IDE;
            this.IdVeiculo = IDV;
            this.VersaoVeiculo = VV;            
        }


        private void CadVeiculo_Load(object sender, EventArgs e)
        {            
            var query = from q in db.DescMeds 
                        where q.Veiculo.VeiculoID == this.IdVeiculo 
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
                String.IsNullOrEmpty(textBoxBitTraseira.Text) || String.IsNullOrEmpty(textBoxPasso.Text) || String.IsNullOrEmpty(textBoxPesoVeiculo.Text) || String.IsNullOrEmpty(textBoxCompTotalVeiculo.Text) || String.IsNullOrEmpty(textBoxAltChao.Text))
            {
                MessageBox.Show("Preencher todos os campos", "AVISO!");
                return;
            }


            DescMed descmed = new DescMed();
            // Chama a função de criar descrição do veículo
            descmed.createDescMed(
                this.IdVeiculo, 
                this.VersaoVeiculo,
                textBoxTipoVeiculo.Text, 
                textBoxMatCarroceira.Text, 
                textBoxCorCarroceria.Text, 
                Int32.Parse(textBoxQtdRodas.Text), 
                Int32.Parse(textBoxVoltControle.Text), 
                Int32.Parse(textBoxVoltMotor.Text), 
                Int32.Parse(textBoxValorVeiculo.Text),           
                Int32.Parse(textBoxDiametroRodas.Text),
                Int32.Parse(textBoxAltTotalVeiculo.Text),
                Int32.Parse(textBoxLargTotalVeiculo.Text),
                Int32.Parse(textBoxAltChao.Text),
                Int32.Parse(textBoxBitDianteira.Text),
                Int32.Parse(textBoxBitTraseira.Text),
                Int32.Parse(textBoxPasso.Text),
                Int32.Parse(textBoxPesoVeiculo.Text),
                Int32.Parse(textBoxCompTotalVeiculo.Text)
                );

            buttonCadastrar.Hide();
            buttonAtualiza.Show();
            buttonRemover.Show();

            MessageBox.Show("Informações Salvas!", "AVISO!");
        }

        private void buttonAtualiza_Click(object sender, EventArgs e)
        {
            DescMed descmed = new DescMed();
            // Chama a função de criar descrição do veículo
            descmed.updateDescMed(
                this.IdVeiculo,
                this.VersaoVeiculo,
                textBoxTipoVeiculo.Text,
                textBoxMatCarroceira.Text,
                textBoxCorCarroceria.Text,
                Int32.Parse(textBoxQtdRodas.Text),
                Int32.Parse(textBoxVoltControle.Text),
                Int32.Parse(textBoxVoltMotor.Text),
                Int32.Parse(textBoxValorVeiculo.Text),
                Int32.Parse(textBoxDiametroRodas.Text),
                Int32.Parse(textBoxAltTotalVeiculo.Text),
                Int32.Parse(textBoxLargTotalVeiculo.Text),
                Int32.Parse(textBoxAltChao.Text),
                Int32.Parse(textBoxBitDianteira.Text),
                Int32.Parse(textBoxBitTraseira.Text),
                Int32.Parse(textBoxPasso.Text),
                Int32.Parse(textBoxPesoVeiculo.Text),
                Int32.Parse(textBoxCompTotalVeiculo.Text)
                );
            MessageBox.Show("Informações Atualizadas!", "AVISO!");
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            DescMed descMed = new DescMed();
            descMed.removeDecMed(this.IdVeiculo, this.VersaoVeiculo);

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
            
            buttonAtualiza.Hide();
            buttonRemover.Hide();

            MessageBox.Show("Informações Removidas", "AVISO!");
            buttonCadastrar.Show();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Leituras leituras = new Leituras(this.IdVeiculo, this.VersaoVeiculo);
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

       
    }
}
