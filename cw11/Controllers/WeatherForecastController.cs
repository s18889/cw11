using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11.ComunicationModels;
using cw11.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace cw11.Controllers
{
    [ApiController]
    [Route("clinic")]
    public class WeatherForecastController : ControllerBase
    {


       
        IDatabaseComunication _db;
        public WeatherForecastController(IDatabaseComunication db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Post()  //załadowanie do bazy danych przykładowych danych
        {
            try
            {
                _db.DatabaseExampleData();
            }catch(Exception e)
            {
                return BadRequest(e.ToString());
            }
            return Ok();
        }

        [HttpGet("doctors")]
        public IActionResult GetDoctors()  //wiem literówka. tylko nie wiem czy napisane powinno być lekarza czy lekarzy "która pozwoli nam pobierać dane lekarze"
        {//zakładam lekarzy bo lekarze to liczba mnoga więc jest blirzej
            try
            {
                var ds = _db.GetDoctors();
                return Ok(ds);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
            
        }

        [HttpPost("doctors")]
        public IActionResult AddDoctor(AddDoctor dr)  
        {
            try
            {
                _db.AddDoctor(dr);
                return Ok(dr);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

        [HttpPatch("doctors")]
        public IActionResult ModyfyDoctor(ModyfyDoctor dr)
        {
            try
            {
                _db.ModDoctor(dr);
                return Ok(dr);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

        [HttpDelete("doctors/{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            try
            {
                _db.DeleteDoctor(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

    }
}
