using Exclaimer.Service.Customer.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exclaimer.Service.Customer.AcceptanceTests.Helpers
{
    public static class PersonHelper
    {
        public static PersonDTO CreateValidPersonRequest()
        {
            return new PersonDTO
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "John.Smith@outlook.co.uk",
                PhoneNumber = "07450742011",
                Address = "24 High Street",
                City = "Birmingham",
                PostalCode = "B68 8LA",
                Country = "West Midlands",
                DateOfBirth = DateTime.UtcNow.AddYears(-30)
            };
        }
    }
}
