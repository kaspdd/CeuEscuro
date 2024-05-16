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

        //CRUD
        //Create
        public void CreateUser(UsuarioDTO usuario)
        {
            objBLL.Create(usuario);
        }
        //Read
        public List<UsuarioDTO> GetUsersAll()
        {
            return objBLL.GetUsers();
            
        }
        //Update
        public void UpdateUser(UsuarioDTO usuario)
        {
            objBLL.Update(usuario);
        }
        //Delete
        public void DeleteUser(int idUser)
        {
            objBLL.Delete(idUser);
        }
        //Search by Id
        public UsuarioDTO SearchByIdUser(int idUser)
        {
            return objBLL.SearchByID(idUser);
        }
        //Search by Name
        public UsuarioDTO SearchByNameUser(string nameUser)
        {
            return objBLL.SearchByName(nameUser);
        }
        //Load DropDownList
        public List<TipoUsuarioDTO> LoadDLLUser()
        {
            return objBLL.LoadDLL();
        }
    }


}
