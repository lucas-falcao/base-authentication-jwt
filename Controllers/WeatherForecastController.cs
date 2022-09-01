using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Autenticacao01.Authentication;
using Autenticacao01.DTOs;

namespace Autenticacao01.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            
            var nome = User.Identity.Name;
            var user = new UserAuthenticatedDTO(nome);
            return Ok(user);
            // return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            // {
            //     Date = DateTime.Now.AddDays(index),
            //     TemperatureC = Random.Shared.Next(-20, 55),
            //     Summary = nome
            // })
            // .ToArray());
           
                // var nome = User.Identity.Name;
                
          
            
            
        }
        
        [HttpGet]
        [Route("nome")]
        public IActionResult getName()
        {
            var us = User;
            
            var nome = User.Identity.Name;
            UserAuthenticatedDTO user = new (nome);
            return Ok(user);
        }
    }
}