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
                dvgTela_Usuario.Rows[i].Cells[0].Value = dtUsuario.Rows[i]["id"].ToString();
                dvgTela_Usuario.Rows[i].Cells[1].Value = dtUsuario.Rows[i]["nome"].ToString();
                dvgTela_Usuario.Rows[i].Cells[2].Value = dtUsuario.Rows[i]["email"].ToString();
                dvgTela_Usuario.Rows[i].Cells[3].Value = dtUsuario.Rows[i]["senha"].ToString();

            }
        }
    }
}
