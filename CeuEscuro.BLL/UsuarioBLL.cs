using CeuEscuro.DAL;
using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.BLL
{
    public class UsuarioBLL
    {
        //objeto para acesso geral aos Recursos da DAL
        UsuarioDAL objBLL = new UsuarioDAL();
        //autenticar
        public UsuarioDTO AutenticarUsuario(string nome, string senha)
        {

            return objBLL.Autenticar(nome, senha);
        }
    }
}
