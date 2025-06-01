using APIRestFull.Commons;
using APIRestFull.DAOs.Interface;
using APIRestFull.Models;
using Dapper;

namespace APIRestFull.DAOs
{
    public class DAOCalculator_serv : IDAOCalculator_serv
    {
        private readonly DapperContext_sserv _dapperContext;
        public DAOCalculator_serv(DapperContext_sserv dapperContext_Sserv)
        {
            _dapperContext = dapperContext_Sserv;
        }
        public async Task<Model_Calculator> AddCalculator(Input_Calculator input)
        {
            var query = @"INSERT INTO Calculator (memoria, usuario) VALUES (@Memoria, @Usuario)
                            RETURNING id;";
            using var contexto = _dapperContext.GetConection();
            var idOk = await contexto.QuerySingleAsync<int>(query,new { input.Memoria,input.Usuario });
            if (idOk == 0) {
                return null;
            }
            var result = Utils.transform<Model_Calculator>(input);
            result.Id = idOk;
            return result;            

        }

        public async Task<bool> DeleteCalculator(string Usuario)
        {
            var query = @"delete from Calculator where usuario=@Usuario";
            using var contexto = _dapperContext.GetConection();
            await contexto.ExecuteAsync(query, new { Usuario });            
            return true;

        }

        public async Task<bool> UpdateCalculator(Input_Calculator input)
        {
            var query = @"update Calculator set memoria=@Memoria where usuario=@Usuario";
            using var contexto = _dapperContext.GetConection();
            await contexto.ExecuteAsync(query, new { input.Memoria, input.Usuario });
            return true;

        }

        public async Task<List<Model_Calculator>> GetList()
        {
            var query = "Select * from Calculator";
            using var connection = _dapperContext.GetConection();
            var result = await connection.QueryAsync<Model_Calculator>(query);
            return result.ToList();
        }

        public async Task<Model_Calculator> GetbyUser(string user)
        {
            var query = "Select * from Calculator where Usuario=@Usuario";
            using var connection = _dapperContext.GetConection();
            var result = await connection.QueryAsync<Model_Calculator>(query, new { Usuario=user });
            return result.FirstOrDefault();
        }
    }
}
