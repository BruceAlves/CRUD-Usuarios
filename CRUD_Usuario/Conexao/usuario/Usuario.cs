using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Usuario.Conexao.Usuario
{
    public class Usuario : IUsuario
    {

        private readonly string conexao = "Server=localhost;Database=telacadastro;Uid=root;Pwd=bruce@#2022;";

        

        public bool VerificarLogin(string email, string senha)
        {
            bool usuarioValido = false;

           

            string query = $@"select * from cadastros where  email ='{email}' and senha = '{senha}'";
            MySqlConnection mySql = new MySqlConnection(conexao);


            DataTable dtUsuario = new DataTable();

            try
            {
                mySql.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, mySql);
                adapter.Fill(dtUsuario);

            }
            catch (Exception)
            {
                MessageBox.Show("Erro de conexão", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                mySql.Close();
            }

            if (dtUsuario.Rows.Count > 0)
            {
                return true;
            }

            return usuarioValido;
        }

        public DataTable BuscarUsuarios()
        {

            string query = $@"select * from cadastros";
            MySqlConnection mySql = new MySqlConnection(conexao);
            DataTable dtUsuarios = new DataTable();
            

            try
            {
                mySql.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, mySql);
                adapter.Fill(dtUsuarios);

            }
            catch (Exception)
            {
                MessageBox.Show("Erro de conexão", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                mySql.Close();
            }

            return dtUsuarios;
        }

    }

   
}
