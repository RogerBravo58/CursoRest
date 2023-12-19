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
