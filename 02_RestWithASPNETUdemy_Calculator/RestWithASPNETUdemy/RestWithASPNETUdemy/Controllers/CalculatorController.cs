using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase {
        
        private readonly ILogger<CalculatorController> _logger;
        public CalculatorController(ILogger<CalculatorController> logger) {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult sum(string firstNumber, string secondNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult subtraction(string firstNumber, string secondNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("multiply/{firstNumber}/{secondNumber}")]
        public IActionResult multiply(string firstNumber, string secondNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("divide/{firstNumber}/{secondNumber}")]
        public IActionResult divide(string firstNumber, string secondNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult avereage(string firstNumber, string secondNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }


        [HttpGet("square-root/{firstNumber}")]
        public IActionResult squareRoot(string firstNumber) {
            if (IsNumeric(firstNumber)) {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(squareRoot.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strNumber) {
            double number;
            bool isNumber = double.TryParse(strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber) {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue)) {
                return decimalValue;
            }
            return 0;
        }

    }
}
