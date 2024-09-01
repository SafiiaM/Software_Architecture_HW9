using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAspNetApp.Models;

namespace MyAspNetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController: ControllerBase
{
    private readonly WeatherForecastHolder _weatherForecastHolder;
    //readonly - защита от дурака 

    public WeatherForecastController(
        WeatherForecastHolder weatherForecastHolder)
        {
            _weatherForecastHolder = weatherForecastHolder;
        }

    
        [HttpPost("add")] 
        public IActionResult Add([FromQuery] DateTime date, [FromQuery] int temperatureC)

        {
            _weatherForecastHolder.Add(date, temperatureC);
            return Ok();
        }

        [HttpPut("update")] 
        public IActionResult Update([FromQuery] DateTime date, [FromQuery] int temperatureC)
        
        {
            bool updated = _weatherForecastHolder.Update(date, temperatureC);
            if (updated)
            {
                return Ok();
            }
            else
            {
                return NotFound($"Прогноз погоды на дату {date} не найден.");
            }
        }

        //Метод Update вызывает Update у WeatherForecastHolder и возвращает статус 
        // в зависимости от того, был ли найден и обновлен элемент.

        [HttpDelete("delete")] 
        public IActionResult Delete([FromQuery] DateTime date)

        {
            bool deleted = _weatherForecastHolder.Delete(date);
            if (deleted)
            {
                return Ok();
            }
            else
            {
                return NotFound($"Прогноз погоды на дату {date} не найден.");
            }
        }

        // Метод Delete вызывает Delete у WeatherForecastHolder и возвращает соответствующий ответ.
        
        [HttpGet("get")] 
        public IActionResult Get([FromQuery] DateTime dateFrom, [FromQuery] DateTime dateTo)

        {
            List<WeatherForecast> list = _weatherForecastHolder.Get(dateFrom, dateTo);
            return Ok(list);
        }
    }
}