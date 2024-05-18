using CeuEscuro.DTO;
using CeuEscuro.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.BLL
{
    public class FilmeBLL :
    {
        FilmDAL objBLL = new FilmDAL();

        public void Create(FilmDTO filme)
        {
            objBLL.Create(filme);
        }

        public List<FilmDTO> GetFilms()
        {
            return objBLL.GetFilms();
        }

        public void Update(FilmDTO filme)
        {
            objBLL.Update(filme);
        }

        public void Delete(int idFilme)
        {
            objBLL.Delete(idFilme);
        }

        public FilmDTO SearchByID(int filmeId)
        {
            return objBLL.SearchByID(filmeId);
        }

        public FilmDTO SearchByName(string filmeTitulo)
        {
            return objBLL.SearchByName(filmeTitulo);
        }

        public List<FilmDTO> Filter(string generoFilme)
        {
            return objBLL.Filter(generoFilme);
        }

        public List<ClassificacaoDTO> LoadDLLClassificacao()
        {
            return objBLL.LoadDLLClassificacao();
        }

        public List<GeneroDTO> LoadDLLGenero()
        {
           return objBLL.LoadDLLGenero();
        }

    }
}
