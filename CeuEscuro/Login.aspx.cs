using CeuEscuro.BLL;
using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeuEscuro
{
    public partial class Login : System.Web.UI.Page
    {
        UsuarioDTO usuario = new UsuarioDTO();
        UsuarioBLL usuarioBLL = new UsuarioBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            // o .Trim() serve para nao pegar os espacos antes e depois do nome digitado, somente o nome.
            string nome = txtNomeUsuario.Text.Trim();
            string senha = txtSenhaUsuario.Text.Trim();

            usuario = usuarioBLL.AutenticarUsuario(nome, senha);

            if (usuario != null)
            {
                lblMessage.Text = $"Usuario {nome} seu acesso foi liberado!!";

            }
            else
            {
                lblMessage.Text = $"Usuario {nome} nao cadastrado!";
            }

        }
    }
}