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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Chama a classe ModProva para criar as modalidades de prova.
            new ModProva();            
        }

        private void Login_Close(object sender, EventArgs e)
        {

        }
        
        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            Equipe equipe = new Equipe();

            var ide = equipe.verificaEquipe(Int32.Parse(textBoxIdEquipe.Text), textBoxSenha.Text);
            if (ide != 0)
            {
                // Realiza o login do usuário e verifica o tipo de usuario ele é.
                //MessageBox.Show("Bem Vindo", "AVISO!");
                var db = new MyContext();
                var tipoUser = db.Equipes.Find(ide);

                if (tipoUser.Tipo_User == 1)
                {
                    MessageBox.Show("You are User Admin");
                    AreaAdmin aAdmin = new AreaAdmin();
                    aAdmin.Show();
                }
                else if (tipoUser.Tipo_User == 2)
                {
                    // Quando é realizado o login o objeto AreaEquipe é instanciado e
                    // atribuido o ID da Equipe em seu atributo 'IdEquipe'                
                    AreaEquipe aEquipe = new AreaEquipe(ide);
                    aEquipe.Show();
                }
                // Esconde o form login deixando ele em execução e também limpa os campos de entrada do form
                this.Hide();
                textBoxIdEquipe.Clear();
                textBoxSenha.Clear();                
            }
            else
            {
                MessageBox.Show("Login Incorreto", "AVISO!");
                textBoxIdEquipe.Clear();
                textBoxSenha.Clear();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelCriaLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadEquipe cEquipe = new CadEquipe();
            cEquipe.Show();
            this.Hide();
        }

        private void textBoxSenha_TextChanged(object sender, EventArgs e)
        {
            textBoxSenha.PasswordChar = '*';
        }
    }
}
