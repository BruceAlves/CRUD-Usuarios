using CRUD_Usuario.Conexao.Usuario;
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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            IUsuario usuario = new Usuario();
            DataTable dtUsuario = usuario.BuscarUsuarios();

            for (int i = 0; i < dtUsuario.Rows.Count; i++)
            {
                dvgTela_Usuario.Rows.Add
                (
                  dtUsuario.Rows[i]["id"].ToString(),
                  dtUsuario.Rows[i]["nome"].ToString(),
                  dtUsuario.Rows[i]["email"].ToString(),
                  dtUsuario.Rows[i]["senha"].ToString()
                );


            }
        }



        private void btnEditar_Click_1(object sender, EventArgs e)
        {

            string? id = dvgTela_Usuario.SelectedRows[0].Cells[0].Value.ToString();
            string? nome = dvgTela_Usuario.SelectedRows[0].Cells[1].Value.ToString();
            string? email = dvgTela_Usuario.SelectedRows[0].Cells[2].Value.ToString();
            string? senha = dvgTela_Usuario.SelectedRows[0].Cells[3].Value.ToString();



            EditarUsuario EditarUsuarios = new EditarUsuario(id, nome, email, senha);
            EditarUsuarios.ShowDialog();



        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            Inseirir_Usuario inseirir_Usuario = new Inseirir_Usuario();
            inseirir_Usuario.ShowDialog();


        }



    }
}
