using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Usuario.Conexao.Usuario
{
    internal interface IUsuario
    {
        bool VerificarLogin(string email, string senha);

        DataTable BuscarUsuarios();
    }
}
