using APIRestFull.BOs.Interface;
using APIRestFull.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIRestFull.Controllers
{
    [ApiController]
    [Route("Api/Calculator")]
    public class CalculatorController : Controller
    {
        private readonly IBOCalculator_serv _bOCalculator_Serv;
        public CalculatorController(IBOCalculator_serv bOCalculator_Serv)
        {
            _bOCalculator_Serv = bOCalculator_Serv;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _bOCalculator_Serv.GetList();
                if (result == null)
                {
                    return BadRequest(new Model_Generic<Dto_Calculator>
                    {
                        Success = false,
                        Message = "Algo sucedio intente de nuevo"
                    });
                }
                return Ok(new Model_Generic<List<Dto_Calculator>> { Success = true, Data = result });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new Model_Generic<Dto_Calculator>
                {
                    Success = false,
                    Message = $"Error interno:{ex.Message}"
                });
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByUser(string Id)
        {
            try
            {
                var result = await _bOCalculator_Serv.GetbyUser(Id);
                if (result == null)
                {
                    return BadRequest(new Model_Generic<Dto_Calculator>
                    {
                        Success = false,
                        Message = "Algo sucedio intente de nuevo"
                    });
                }
                return Ok(new Model_Generic<Dto_Calculator> { Success = true, Data = result });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new Model_Generic<Dto_Calculator>
                {
                    Success = false,
                    Message = $"Error interno:{ex.Message}"
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Input_Calculator input)
        {
            try
            {
                var result = await _bOCalculator_Serv.AddCalculator(input);
                if (result == null)
                {
                    return BadRequest(new Model_Generic<Dto_Calculator>
                    {
                        Success = false,
                        Message = "Algo sucedio intente de nuevo"
                    });
                }
                return Ok(new Model_Generic<Dto_Calculator> { Success=true,Data= result });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new Model_Generic<Dto_Calculator>
                {
                    Success = false,
                    Message = $"Error interno:{ex.Message}"
                });
            }
        }       

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            try
            {
                var result = await _bOCalculator_Serv.DeleteCalculator(Id);
                if (result == null)
                {
                    return BadRequest(new Model_Generic<Dto_Calculator>
                    {
                        Success = false,
                        Message = "Algo sucedio intente de nuevo"
                    });
                }
                return Ok(new Model_Generic<bool> { Success = true, Data = result });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new Model_Generic<Dto_Calculator>
                {
                    Success = false,
                    Message = $"Error interno:{ex.Message}"
                });
            }
        }
    }
}
