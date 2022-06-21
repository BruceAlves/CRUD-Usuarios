using CRUD_Usuario.Conexao.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Usuario
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IUsuario conexaoUsuario = new Usuario();

            bool usuarioValido = conexaoUsuario.VerificarLogin(txtEmail.Text, txtSenha.Text);

            if (usuarioValido)
            {
                MessageBox.Show("Usuario logado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                LimparCampo();

                this.Hide();

                Usuarios TelaUsuarios = new Usuarios();

                TelaUsuarios.ShowDialog();

            }
            else
            {
                MessageBox.Show("Credenciais Inválidas", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void LimparCampo()
        {
            txtEmail.Text = string.Empty;
            txtSenha.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimparCampo();
        }
    }
}
