using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("Calculator")]
    public class CalculatorControler : ControllerBase
    {
        private readonly ILogger<CalculatorControler> _logger;

        public CalculatorControler(ILogger<CalculatorControler> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {   
            if(isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var operacao = ConvertTo(firstNumber) + ConvertTo(secondNumber);
                return Ok(operacao.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]

        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if(isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var operacao = ConvertTo(firstNumber) - ConvertTo(secondNumber);
                return Ok(operacao.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("Multi/{firstNumber}/{secondNumber}")]

        public IActionResult Multi(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var operacao = ConvertTo(firstNumber) * ConvertTo(secondNumber);
                return Ok(operacao.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("Divi/{firstNumber}/{secondNumber}")]

        public IActionResult Divi(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var operacao = ConvertTo(firstNumber) / ConvertTo(secondNumber);
                return Ok(operacao.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("Media/{firstNumber}/{secondNumber}")]

        public IActionResult Media(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var operacao = ConvertTo(firstNumber) + ConvertTo(secondNumber);
                var media = operacao / 2;
                return Ok(media.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("squareroot/{firstNumber}")]

        public IActionResult SquareRoot(string firstNumber)
        {
            if (isNumeric(firstNumber))
            {
                var operacao = Math.Sqrt((double)ConvertTo(firstNumber));
                return Ok(operacao.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private bool isNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);

            return isNumber;
        }

        private decimal ConvertTo(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
    }
}
