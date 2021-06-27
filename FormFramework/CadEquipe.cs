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
    public partial class CadEquipe : Form
    {
        public CadEquipe()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Equipe equipe = new Equipe();


            if (String.IsNullOrEmpty(textBoxNomeEquipe.Text) || String.IsNullOrEmpty(textBoxSenha.Text) || String.IsNullOrEmpty(textBoxConfSenha.Text))
            {
                MessageBox.Show("Preencha Todos os Campos", "AVISO!");
                return;
            }
            if (textBoxSenha.Text != textBoxConfSenha.Text)
            {
                MessageBox.Show("As senhas não conferem!", "AVISO!");
            }
            else
            {
                // O numero '2' representa o tipo do usuário.
                // Sendo que 1 representa o ADMIN e 2 representa USUÁRIO COMUM
                equipe.createEquipe(textBoxNomeEquipe.Text, textBoxConfSenha.Text, 2);
                int id = equipe.verificaEquipe(textBoxNomeEquipe.Text, textBoxConfSenha.Text);

                Veiculo veiculo = new Veiculo();
                veiculo.createVeiculo(id);

                MessageBox.Show($"Identificador de Login: {id} ");
                this.Close();
            }

            textBoxSenha.Clear();
            textBoxConfSenha.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CadEquipe_Load(object sender, EventArgs e)
        {

        }
        private void CadEquipe_Close(object sender, EventArgs e)
        {
            Form lg = Application.OpenForms["Login"];
            lg.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxSenha_TextChanged(object sender, EventArgs e)
        {
            textBoxSenha.PasswordChar = '*';
        }

        private void textBoxConfSenha_TextChanged(object sender, EventArgs e)
        {
            textBoxConfSenha.PasswordChar = '*';
        }
    }
}
