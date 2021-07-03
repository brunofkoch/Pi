﻿using System;
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

        private MyContext db = new MyContext();

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

            buttonRem1.Hide();
            buttonRem2.Hide();
            buttonRem3.Hide();
            buttonRem4.Hide();

            DescMed descmed = new DescMed();
            int idDM = descmed.getId(this.IDVeiculo, this.IDVersao);            

            Leitura vl = new Leitura();
            if(vl.VerificaExistencia(1, idDM)) {
                buttonSal1.Hide();
                buttonRem1.Show();
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
                buttonSal2.Hide();
                buttonRem2.Show();
                var result = vl.returnObeject(2, idDM);
                textBox1p2.Text = result.L1.ToString();                
                this.IDProva2 = result.LeituraID;
            }

            if (vl.VerificaExistencia(3, idDM))
            {
                buttonSal3.Hide();
                buttonRem3.Show();
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
                buttonSal4.Hide();
                buttonRem4.Show();
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
            if (this.IDVersao == 2)
            {
                Resultado res = new Resultado();
                var melhoria = res.calcProvaVelocidade(this.IDVeiculo);
                MessageBox.Show(melhoria.ToString(), "Aviso!");
            }
            buttonSal1.Hide();
            buttonRem1.Show();
            MessageBox.Show("Leituras Salvas!", "Aviso!");


        }

        //Prova Tração
        private void buttonSal2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1p2.Text))
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
                0,0,0
                );
            buttonSal2.Hide();
            buttonRem2.Show();
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
            buttonSal3.Hide();
            buttonRem3.Show();
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
            buttonSal4.Hide();
            buttonRem4.Show();
            MessageBox.Show("Leituras Salvas!", "Aviso!");
            
        }

        public string fCalcularMediap1(string media_1, string media_2, string media_3, string media_4)
        {
            var total = 0.00;
            if (media_1 != "" && media_2 != "" && media_3 != "" && media_4 != "")
            {
                total = 10 / ( (Convert.ToDouble(media_1) + Convert.ToDouble(media_2) + Convert.ToDouble(media_3) + Convert.ToDouble(media_4)) / 4 );
            }
            return Convert.ToString(total);
        }
        public string fCalcularMediap2(string media_1, string media_2, string media_3, string media_4)
        {
            var total = 0.00;
            if (media_1 != "" && media_2 != "" && media_3 != "" && media_4 != "")
            {
                total = ((Convert.ToDouble(media_1) + Convert.ToDouble(media_2) + Convert.ToDouble(media_3) + Convert.ToDouble(media_4)) / 4);
            }
            return Convert.ToString(total);
        }

        private void textBox1p1_TextChanged(object sender, EventArgs e)
        {
            textBox5p1.Text = fCalcularMediap1(textBox1p1.Text, textBox2p1.Text, textBox3p1.Text, textBox4p1.Text);
        }

        private void textBox2p1_TextChanged(object sender, EventArgs e)
        {
            textBox5p1.Text = fCalcularMediap1(textBox1p1.Text, textBox2p1.Text, textBox3p1.Text, textBox4p1.Text);
        }

        private void textBox3p1_TextChanged(object sender, EventArgs e)
        {
            textBox5p1.Text = fCalcularMediap1(textBox1p1.Text, textBox2p1.Text, textBox3p1.Text, textBox4p1.Text);
        }

        private void textBox4p1_TextChanged(object sender, EventArgs e)
        {
            textBox5p1.Text = fCalcularMediap1(textBox1p1.Text, textBox2p1.Text, textBox3p1.Text, textBox4p1.Text);
        }



        private void textBox1p3_TextChanged(object sender, EventArgs e)
        {
            textBox5p3.Text = fCalcularMediap2(textBox1p3.Text, textBox2p3.Text, textBox3p3.Text, textBox4p3.Text);
        }

        private void textBox2p3_TextChanged(object sender, EventArgs e)
        {
            textBox5p3.Text = fCalcularMediap2(textBox1p3.Text, textBox2p3.Text, textBox3p3.Text, textBox4p3.Text);
        }

        private void textBox3p3_TextChanged(object sender, EventArgs e)
        {
            textBox5p3.Text = fCalcularMediap2(textBox1p3.Text, textBox2p3.Text, textBox3p3.Text, textBox4p3.Text);
        }

        private void textBox4p3_TextChanged(object sender, EventArgs e)
        {
            textBox5p3.Text = fCalcularMediap2(textBox1p3.Text, textBox2p3.Text, textBox3p3.Text, textBox4p3.Text);
        }

        private void textBox1p4_TextChanged(object sender, EventArgs e)
        {
            textBox5p4.Text = fCalcularMediap2(textBox1p4.Text, textBox2p4.Text, textBox3p4.Text, textBox4p4.Text);
        }

        private void textBox2p4_TextChanged(object sender, EventArgs e)
        {
            textBox5p4.Text = fCalcularMediap2(textBox1p4.Text, textBox2p4.Text, textBox3p4.Text, textBox4p4.Text);
        }

        private void textBox3p4_TextChanged(object sender, EventArgs e)
        {
            textBox5p4.Text = fCalcularMediap2(textBox1p4.Text, textBox2p4.Text, textBox3p4.Text, textBox4p4.Text);
        }

        private void textBox4p4_TextChanged(object sender, EventArgs e)
        {
            textBox5p4.Text = fCalcularMediap2(textBox1p4.Text, textBox2p4.Text, textBox3p4.Text, textBox4p4.Text);
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
                buttonSal1.Show();
                buttonRem1.Hide();
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
                buttonSal2.Show();
                buttonRem2
                    .Hide();
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
                buttonSal3.Show();
                buttonRem3.Hide();
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
                buttonSal4.Show();
                buttonRem4.Hide();
                MessageBox.Show("Dados removidos!", "Aviso!");
                return;
            }
            
            MessageBox.Show("Não foi possivel remover. Feche e abra a janela!", "Aviso!");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox5p1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1p2_TextChanged_1(object sender, EventArgs e)
        {

        }

      
    }
}
