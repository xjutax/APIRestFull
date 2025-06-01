using APIRestFull.Models;

namespace APIRestFull.DAOs.Interface
{
    public interface IDAOCalculator_serv
    {
        public Task<Model_Calculator> AddCalculator(Input_Calculator input);
        public Task<List<Model_Calculator>> GetList();
        public Task<Model_Calculator> GetbyUser(string user);
        public Task<bool> DeleteCalculator(string usuario);
    }
}
