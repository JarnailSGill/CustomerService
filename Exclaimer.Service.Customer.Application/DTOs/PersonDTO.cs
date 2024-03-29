﻿using System.ComponentModel.DataAnnotations;

namespace Exclaimer.Service.Customer.Application.DTOs
{
    public class PersonDTO
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
