using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorControler : ControllerBase
    {
        private readonly ILogger<CalculatorControler> _logger;

        public CalculatorControler(ILogger<CalculatorControler> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {   
            if(isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sum = ConvertTo(firstNumber) + ConvertTo(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private int ConvertTo(string firstNumber)
        {
            throw new NotImplementedException();
        }

        private bool isNumeric(string firstNumber)
        {
            throw new NotImplementedException();
        }
    }
}
