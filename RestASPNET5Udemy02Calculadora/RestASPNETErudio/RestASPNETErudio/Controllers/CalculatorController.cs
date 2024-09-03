using Microsoft.AspNetCore.Mvc;

namespace RestASPNETErudio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
       

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }
        //solid aqui
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult soma(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid inout");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult subtracao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid inout");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult divisao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var divi = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(divi.ToString());
            }
            return BadRequest("Invalid inout");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult media(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mediaSoma = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                var media = mediaSoma / 2;
                return Ok(media.ToString());
            }
            return BadRequest("Invalid inout");
        }

        [HttpGet("raiz/{firstNumber}")]
        public IActionResult raiz(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                float f = float.Parse(firstNumber);
                var raiz = Convert.ToSingle(Math.Sqrt(f)); ;
                
                return Ok("raiz de: "+ f + " é igual a: " + raiz.ToString());
            }
            return BadRequest("Invalid inout");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue)) { return decimalValue; }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;

            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo,  out number);

            return isNumber;
        }
    }
}
