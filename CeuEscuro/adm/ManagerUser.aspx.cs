using CeuEscuro.BLL;
using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeuEscuro.adm
{
    public partial class ManagerUser : System.Web.UI.Page
    {
        UsuarioBLL objBLL = new UsuarioBLL();
        UsuarioDTO objDTO = new UsuarioDTO();
        //pageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            //chama o metodo aqui para rodar na pagina
            txtIdUsuario.Enabled = false;
            PopularGv1();
            PopularDDL1();

        }

        //Popular gridView
        public void PopularGv1()
        {
            gv1.DataSource = objBLL.GetUsersAll();
            gv1.DataBind();
        }

        //Popular ddl1
        public void PopularDDL1()
        {
            ddl1.DataSource = objBLL.LoadDLLUser();
            ddl1.DataBind();
        }

    }
}