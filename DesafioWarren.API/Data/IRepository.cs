using DesafioWarren.API.Models;

namespace DesafioWarren.API.Data
{
    public interface IRepository
    {
        public List<Cadastro> Cadastros { get; set; }
        public void add(Cadastro cadastro);
        public void update(Cadastro cadastro, Cadastro cdtUpdated);
        public void deleteCdt(Cadastro cadastro);
    }
}
