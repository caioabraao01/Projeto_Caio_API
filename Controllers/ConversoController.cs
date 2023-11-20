using Caio_Teste.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caio_Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversoController : ControllerBase
    {
        [HttpGet]
        public IActionResult converse(float? Anos_Luz, float? km)
        {

            var message = new Message();

            var isKmValid = km >= 1;
            var isAnosLuzValid = Anos_Luz >= 1;

            // Calcular Km -> Anos Luz
            if(isKmValid)
            {
                var _anosLuz = km * 1.057 * Math.Pow(10, -13);

                message.value = (float)_anosLuz;
                message.statusCode = 200;
                message.dataTime = DateTime.Now;
                return Ok(message);
            }

            // Calcular Anos Luz -> Km
            if (isAnosLuzValid)
            {
                var _km = Anos_Luz * 9.46 * Math.Pow(10,12);

                message.value = (float)_km;
                message.statusCode = 200;
                message.dataTime = DateTime.Now;
                return Ok(message);
            }

            message.errorMessage = "invalid value";
            message.statusCode = 400;
            message.dataTime = DateTime.Now;

            return BadRequest(message);

        }

        //[HttpGet]
        //public IActionResult converseKm(float km)
        //{

        //}
    }
}
