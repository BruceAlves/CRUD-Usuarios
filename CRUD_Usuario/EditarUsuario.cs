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
    public partial class EditarUsuario : Form 
    {
        public EditarUsuario(string id, string nome,string email, string senha)
        {
            InitializeComponent();

            txtId.Text = id;
            txtNome.Text = nome;
            txtEmail.Text = email;
            txtSenha.Text = senha;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conexao_MySql = "Server=localhost;Database=telacadastro;Uid=root;Pwd=bruce@#2022;";

            string comandoUpdate = $@"Update  cadastros
            set nome = '{txtNome.Text}', email = '{txtEmail.Text}', senha ='{txtSenha.Text}'
            where id = {txtId.Text}";

            MySqlConnection conexaoMySql = new MySqlConnection(conexao_MySql);

            try
            {
                conexaoMySql.Open();

                MySqlCommand executorComando = new MySqlCommand(comandoUpdate, conexaoMySql);
                executorComando.ExecuteNonQuery();

                

                MessageBox.Show($"Dados Alterados com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string senha=txtSenha.Text;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string conexão = "Server=127.0.0.1;Database=telacadastro;Uid=root;Pwd=bruce@#2022;";

            string query = $@"select * from cadastros";

            MySqlConnection conexaoMysql = new MySqlConnection(conexão);
            DataTable tabela = new DataTable();

            try
            {
                conexaoMysql.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexaoMysql);
                adapter.Fill(tabela);
                dgvTela.DataSource = tabela;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Banco de Dados", $"Erro:\n{ex.Message}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexaoMysql.Close();
            }
        }
    }
}
