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
    public partial class Leituras : Form
    {
        public int IDVeiculo { get; set; }
        public int IDVersao { get; set; }
        public int IDProva1 { get; set; }
        public int IDProva2 { get; set; }
        public int IDProva3 { get; set; }
        public int IDProva4 { get; set; }

        public Leituras()
        {
            InitializeComponent();
        }



        public Leituras(int IDV, int VV)
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

            DescMed descmed = new DescMed();
            int idDM = descmed.getId(this.IDVeiculo, this.IDVersao);            

            Leitura vl = new Leitura();
            if(vl.VerificaExistencia(1, idDM)) {
                var result = vl.returnObeject(1, idDM);
                textBox1p1.Text = result.L1.ToString();
                textBox2p1.Text = result.L2.ToString();
                textBox3p1.Text = result.L3.ToString();
                textBox4p1.Text = result.L4.ToString();
                textBox5p1.Text = result.Media.ToString();
                this.IDProva1 = result.LeituraID;
            }

            if (vl.VerificaExistencia(2, idDM))
            {
                var result = vl.returnObeject(2, idDM);
                textBox1p2.Text = result.L1.ToString();
                textBox2p2.Text = result.L2.ToString();
                textBox3p2.Text = result.L3.ToString();
                textBox4p2.Text = result.L4.ToString();
                textBox5p2.Text = result.Media.ToString();
                this.IDProva2 = result.LeituraID;
            }

            if (vl.VerificaExistencia(3, idDM))
            {
                var result = vl.returnObeject(3, idDM);
                textBox1p3.Text = result.L1.ToString();
                textBox2p3.Text = result.L2.ToString();
                textBox3p3.Text = result.L3.ToString();
                textBox4p3.Text = result.L4.ToString();
                textBox5p3.Text = result.Media.ToString();
                this.IDProva3 = result.LeituraID;
            }

            if (vl.VerificaExistencia(4, idDM))
            {
                var result = vl.returnObeject(4, idDM);
                textBox1p4.Text = result.L1.ToString();
                textBox2p4.Text = result.L2.ToString();
                textBox3p4.Text = result.L3.ToString();
                textBox4p4.Text = result.L4.ToString();
                textBox5p4.Text = result.Media.ToString();
                this.IDProva4 = result.LeituraID;
            }
        }

        private void buttonSal1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1p1.Text) || String.IsNullOrEmpty(textBox2p1.Text) || String.IsNullOrEmpty(textBox3p1.Text) || String.IsNullOrEmpty(textBox4p1.Text))            
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso!");
                return;
            }
            Leitura l = new Leitura();
            l.createLeitura(
                this.IDVeiculo,
                this.IDVersao,
                1,
                float.Parse(textBox1p1.Text),
                float.Parse(textBox2p1.Text),
                float.Parse(textBox3p1.Text),
                float.Parse(textBox4p1.Text)
                );
            MessageBox.Show("Leituras Salvas!", "Aviso!");


        }

        private void buttonSal2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1p2.Text) || String.IsNullOrEmpty(textBox2p2.Text) || String.IsNullOrEmpty(textBox3p2.Text) || String.IsNullOrEmpty(textBox4p2.Text))
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso!");
                return;
            }
            Leitura l = new Leitura();
            l.createLeitura(
                this.IDVeiculo,
                this.IDVersao,
                2,
                float.Parse(textBox1p2.Text),
                float.Parse(textBox2p2.Text),
                float.Parse(textBox3p2.Text),
                float.Parse(textBox4p2.Text)
                );
            MessageBox.Show("Leituras Salvas!", "Aviso!");            
            
        }

        private void buttonSal3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1p3.Text) || String.IsNullOrEmpty(textBox2p3.Text) || String.IsNullOrEmpty(textBox3p3.Text) || String.IsNullOrEmpty(textBox4p3.Text))
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso!");
                return;
            }
            Leitura l = new Leitura();
            l.createLeitura(
                this.IDVeiculo,
                this.IDVersao,
                3,
                float.Parse(textBox1p3.Text),
                float.Parse(textBox2p3.Text),
                float.Parse(textBox3p3.Text),
                float.Parse(textBox4p3.Text)
                );
            MessageBox.Show("Leituras Salvas!", "Aviso!");
            
        }

        private void buttonSal4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1p4.Text) || String.IsNullOrEmpty(textBox2p4.Text) || String.IsNullOrEmpty(textBox3p4.Text) || String.IsNullOrEmpty(textBox4p4.Text))
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso!");
                return;
            }
            Leitura l = new Leitura();
            l.createLeitura(
                this.IDVeiculo,
                this.IDVersao,
                4,
                float.Parse(textBox1p4.Text),
                float.Parse(textBox2p4.Text),
                float.Parse(textBox3p4.Text),
                float.Parse(textBox4p4.Text)
                );
            MessageBox.Show("Leituras Salvas!", "Aviso!");
            
        }

        private void buttonAtu1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1p1_TextChanged(object sender, EventArgs e)
        {
            textBox5p1.Text = fCalcularMedia(textBox1p1.Text, textBox2p1.Text, textBox4p1.Text, textBox4p1.Text);
        }

        private void textBox2p1_TextChanged(object sender, EventArgs e)
        {
            textBox5p1.Text = fCalcularMedia(textBox1p1.Text, textBox2p1.Text, textBox4p1.Text, textBox4p1.Text);
        }

        private void textBox3p1_TextChanged(object sender, EventArgs e)
        {
            textBox5p1.Text = fCalcularMedia(textBox1p1.Text, textBox2p1.Text, textBox4p1.Text, textBox4p1.Text);
        }

        private void textBox4p1_TextChanged(object sender, EventArgs e)
        {
            textBox5p1.Text = fCalcularMedia(textBox1p1.Text, textBox2p1.Text, textBox4p1.Text, textBox4p1.Text);
        }

        private void textBox1p2_TextChanged(object sender, EventArgs e)
        {
            textBox5p2.Text = fCalcularMedia(textBox1p2.Text, textBox2p2.Text, textBox3p2.Text, textBox4p2.Text);
        }
        public string fCalcularMedia(string media_1, string media_2, string media_3, string media_4)
        {
            var total = 0.00;
            if (media_1 != "" && media_2 != "" && media_3 != "" && media_4 != "")
            {
                total = (Convert.ToDouble(media_1) + Convert.ToDouble(media_2) + Convert.ToDouble(media_3) + Convert.ToDouble(media_4)) / 4;
            }
            return Convert.ToString(total);
        }

        private void textBox2p2_TextChanged(object sender, EventArgs e)
        {
            textBox5p2.Text = fCalcularMedia(textBox1p2.Text, textBox2p2.Text, textBox3p2.Text, textBox4p2.Text);
        }

        private void textBox3p2_TextChanged(object sender, EventArgs e)
        {
            textBox5p2.Text = fCalcularMedia(textBox1p2.Text, textBox2p2.Text, textBox3p2.Text, textBox4p2.Text);
        }

        private void textBox4p2_TextChanged(object sender, EventArgs e)
        {
            textBox5p2.Text = fCalcularMedia(textBox1p2.Text, textBox2p2.Text, textBox3p2.Text, textBox4p2.Text);
        }

        private void textBox1p3_TextChanged(object sender, EventArgs e)
        {
            textBox5p3.Text = fCalcularMedia(textBox1p3.Text, textBox2p3.Text, textBox3p3.Text, textBox4p3.Text);
        }

        private void textBox2p3_TextChanged(object sender, EventArgs e)
        {
            textBox5p3.Text = fCalcularMedia(textBox1p3.Text, textBox2p3.Text, textBox3p3.Text, textBox4p3.Text);
        }

        private void textBox3p3_TextChanged(object sender, EventArgs e)
        {
            textBox5p3.Text = fCalcularMedia(textBox1p3.Text, textBox2p3.Text, textBox3p3.Text, textBox4p3.Text);
        }

        private void textBox4p3_TextChanged(object sender, EventArgs e)
        {
            textBox5p3.Text = fCalcularMedia(textBox1p3.Text, textBox2p3.Text, textBox3p3.Text, textBox4p3.Text);
        }

        private void textBox1p4_TextChanged(object sender, EventArgs e)
        {
            textBox5p4.Text = fCalcularMedia(textBox1p4.Text, textBox2p4.Text, textBox3p4.Text, textBox4p4.Text);
        }

        private void textBox2p4_TextChanged(object sender, EventArgs e)
        {
            textBox5p4.Text = fCalcularMedia(textBox1p4.Text, textBox2p4.Text, textBox3p4.Text, textBox4p4.Text);
        }

        private void textBox3p4_TextChanged(object sender, EventArgs e)
        {
            textBox5p4.Text = fCalcularMedia(textBox1p4.Text, textBox2p4.Text, textBox3p4.Text, textBox4p4.Text);
        }

        private void textBox4p4_TextChanged(object sender, EventArgs e)
        {
            textBox5p4.Text = fCalcularMedia(textBox1p4.Text, textBox2p4.Text, textBox3p4.Text, textBox4p4.Text);
        }

     

        private void buttonRem1_Click(object sender, EventArgs e)
        {
            Leitura leitura = new Leitura();
            if (leitura.removeLeitura(this.IDProva1))
            {
                this.IDProva1 = 0;
                textBox1p1.Clear();
                textBox2p1.Clear();
                textBox3p1.Clear();
                textBox4p1.Clear();
                MessageBox.Show("Dados removidos!", "Aviso!");
                return;
            }
            MessageBox.Show("Não foi possivel remover. Feche e abra a janela!", "Aviso!");

        }

        private void buttonRem2_Click(object sender, EventArgs e)
        {
            Leitura leitura = new Leitura();
            if (leitura.removeLeitura(this.IDProva2))
            {
                this.IDProva2 = 0;
                textBox1p2.Clear();
                textBox2p2.Clear();
                textBox3p2.Clear();
                textBox4p2.Clear();
                MessageBox.Show("Dados removidos!", "Aviso!");
                return;
            }
            MessageBox.Show("Não foi possivel remover. Feche e abra a janela!", "Aviso!");
        }

        private void buttonRem3_Click(object sender, EventArgs e)
        {
            Leitura leitura = new Leitura();
            if (leitura.removeLeitura(this.IDProva3))
            {
                this.IDProva3 = 0;
                textBox1p3.Clear();
                textBox2p3.Clear();
                textBox3p3.Clear();
                textBox4p3.Clear();
                MessageBox.Show("Dados removidos!", "Aviso!");
                return;
            }
            MessageBox.Show("Não foi possivel remover. Feche e abra a janela!", "Aviso!");
        }

        private void buttonRem4_Click(object sender, EventArgs e)
        {
            Leitura leitura = new Leitura();
            if (leitura.removeLeitura(this.IDProva4))
            {
                this.IDProva4 = 0;
                textBox1p4.Clear();
                textBox2p4.Clear();
                textBox3p4.Clear();
                textBox4p4.Clear();
                MessageBox.Show("Dados removidos!", "Aviso!");
                return;
            }
            MessageBox.Show("Não foi possivel remover. Feche e abra a janela!", "Aviso!");
        }

        
    }
}
