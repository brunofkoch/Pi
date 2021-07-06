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
    public partial class CadLeituras : Form
    {
        public int IDVeiculo { get; set; }
        public int IDVersao { get; set; }
        

        public CadLeituras()
        {
            InitializeComponent();
        }



        public CadLeituras(int IDV, int VV)
        {
            InitializeComponent();

            // IDVeiculo = Identificador do veiculo criado para equipe
            // IDDescMed = Identificador da Descrição e Medidas da versão do veiculo
            this.IDVeiculo = IDV;
            this.IDVersao = VV;

            if (this.IDVersao == 1)
            {
                labelVVersao.Text = "VEÍCULO NORMAL";
            }
            else
            {
                labelVVersao.Text = "VEÍCULO OTIMIZADO";
            }            
        }

        private void Leituras_Load(object sender, EventArgs e)
        {
            labelMod1.Text = "VELOCIDADE";
            labelMod2.Text = "TRAÇÃO";
            labelMod3.Text = "SLALON";
            labelMod4.Text = "RAMPA";

            Veiculo descmed = new Veiculo();
            int idDM = descmed.getId(this.IDVeiculo, this.IDVersao);            

            Leitura vl = new Leitura();
            if(vl.VerificaExistencia(1, idDM)) {
                var result = vl.returnObeject(1, idDM);
                textBox1p1.Text = result.L1.ToString();
                textBox2p1.Text = result.L2.ToString();
                textBox3p1.Text = result.L3.ToString();
                textBox4p1.Text = result.L4.ToString();
                textBox5p1.Text = result.Media.ToString();
            }

            if (vl.VerificaExistencia(2, idDM))
            {
                var result = vl.returnObeject(2, idDM);
                textBox1p2.Text = result.L1.ToString();
                textBox2p2.Text = result.L2.ToString();
                textBox3p2.Text = result.L3.ToString();
                textBox4p2.Text = result.L4.ToString();
                textBox5p2.Text = result.Media.ToString();
            }

            if (vl.VerificaExistencia(3, idDM))
            {
                var result = vl.returnObeject(3, idDM);
                textBox1p3.Text = result.L1.ToString();
                textBox2p3.Text = result.L2.ToString();
                textBox3p3.Text = result.L3.ToString();
                textBox4p3.Text = result.L4.ToString();
                textBox5p3.Text = result.Media.ToString();
            }

            if (vl.VerificaExistencia(4, idDM))
            {
                var result = vl.returnObeject(4, idDM);
                textBox1p4.Text = result.L1.ToString();
                textBox2p4.Text = result.L2.ToString();
                textBox3p4.Text = result.L3.ToString();
                textBox4p4.Text = result.L4.ToString();
                textBox5p4.Text = result.Media.ToString();
            }
        }

        private void buttonSal1_Click(object sender, EventArgs e)
        {
            Leitura l = new Leitura();
            l.createLeitura(
                this.IDVeiculo,
                this.IDVersao,
                1,
                Int32.Parse(textBox1p1.Text),
                Int32.Parse(textBox2p1.Text),
                Int32.Parse(textBox3p1.Text),
                Int32.Parse(textBox4p1.Text)
                );            
            MessageBox.Show("Leituras Salvas!", "Aviso!");
            
        }

        private void buttonSal2_Click(object sender, EventArgs e)
        {
            Leitura l = new Leitura();
            l.createLeitura(
                this.IDVeiculo,
                this.IDVersao,
                2,
                Int32.Parse(textBox1p2.Text),
                Int32.Parse(textBox2p2.Text),
                Int32.Parse(textBox3p2.Text),
                Int32.Parse(textBox4p2.Text)
                );
            MessageBox.Show("Leituras Salvas!", "Aviso!");            
            
        }

        private void buttonSal3_Click(object sender, EventArgs e)
        {
            Leitura l = new Leitura();
            l.createLeitura(
                this.IDVeiculo,
                this.IDVersao,
                3,
                Int32.Parse(textBox1p3.Text),
                Int32.Parse(textBox2p3.Text),
                Int32.Parse(textBox3p3.Text),
                Int32.Parse(textBox4p3.Text)
                );
            MessageBox.Show("Leituras Salvas!", "Aviso!");
            
        }

        private void buttonSal4_Click(object sender, EventArgs e)
        {
            Leitura l = new Leitura();
            l.createLeitura(
                this.IDVeiculo,
                this.IDVersao,
                4,
                Int32.Parse(textBox1p4.Text),
                Int32.Parse(textBox2p4.Text),
                Int32.Parse(textBox3p4.Text),
                Int32.Parse(textBox4p4.Text)
                );
            MessageBox.Show("Leituras Salvas!", "Aviso!");
            
        }
    }
}
