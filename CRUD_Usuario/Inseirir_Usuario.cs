using MySql.Data.MySqlClient;
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
    public partial class Inseirir_Usuario : Form
    {
        public Inseirir_Usuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string nome = txtNome.Text;
            string email=txtEmail.Text;
            string senha = txtSenha.Text;

            string conexao_MySql = "Server=localhost;Database=telacadastro;Uid=root;Pwd=bruce@#2022;";

            string comandoInsert = 
            $@"insert into cadastros (nome, email,senha)
            values ('{nome}', '{email}','{senha}');";

            MySqlConnection conexaoMySql = new MySqlConnection(conexao_MySql);

            try
            {
                conexaoMySql.Open();

                MySqlCommand executorComando = new MySqlCommand(comandoInsert, conexaoMySql);
                executorComando.ExecuteNonQuery();

                LimparCampo();

                MessageBox.Show($"Usuario {nome} foi Inserido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no Banco!!", $"Erro!{ex.Message}", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                conexaoMySql.Close();
            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            LimparCampo();
        }

        private void LimparCampo()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
