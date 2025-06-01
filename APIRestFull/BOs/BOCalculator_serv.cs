using APIRestFull.BOs.Interface;
using APIRestFull.Commons;
using APIRestFull.DAOs.Interface;
using APIRestFull.Models;

namespace APIRestFull.BOs
{
    public class BOCalculator_serv : IBOCalculator_serv
    {
        private readonly IDAOCalculator_serv _dAOCalculator_Serv;
        public BOCalculator_serv(IDAOCalculator_serv dAOCalculator_Serv)
        {
            _dAOCalculator_Serv = dAOCalculator_Serv;
        }
        public async Task<Dto_Calculator> AddCalculator(Input_Calculator input)
        {
            Dto_Calculator result = null;
            try
            {
                var subresult = await _dAOCalculator_Serv.AddCalculator(input);
                result = Utils.transform<Dto_Calculator>(subresult);
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public async Task<bool> DeleteCalculator(string usuario)
        {
            bool result = false;
            try
            {
                result = await _dAOCalculator_Serv.DeleteCalculator(usuario);               
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;

        }

        public async Task<List<Dto_Calculator>> GetList()
        {
            List<Dto_Calculator> result = null;
            try
            {
                var subresult = await _dAOCalculator_Serv.GetList();
                result = Utils.transform<List<Dto_Calculator>>(subresult);
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public async Task<Dto_Calculator> GetbyUser(string user)
        {
            Dto_Calculator result = null;
            try
            {
                var subresult = await _dAOCalculator_Serv.GetbyUser(user);
                result = Utils.transform<Dto_Calculator>(subresult);
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }
    }
}
