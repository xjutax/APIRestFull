using APIRestFull.Models;

namespace APIRestFull.BOs.Interface
{
    public interface IBOCalculator_serv
    {
        public Task<Dto_Calculator> AddCalculator(Input_Calculator input);
        public Task<List<Dto_Calculator>> GetList();
        public Task<Dto_Calculator> GetbyUser(string user);
        public Task<bool> DeleteCalculator(string usuario);
    }
}
