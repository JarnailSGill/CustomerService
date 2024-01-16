using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exclaimer.Service.Customer.AcceptanceTests.Response
{
    public class ValidationErrorResponse
    {
        public List<ValidationError> Errors { get; set; }
    }

    public class ValidationError
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
