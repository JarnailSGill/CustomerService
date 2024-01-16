using AutoMapper;
using Exclaimer.Service.Customer.Application.DTOs;
using Exclaimer.Service.Customer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exclaimer.Service.Customer.Application.Mapping
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<PersonDTO, Person>();
        }
       
    }
}
