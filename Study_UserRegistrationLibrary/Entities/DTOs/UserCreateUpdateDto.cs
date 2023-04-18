using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_UserRegistrationLibrary.Entities.DTOs
{
    public class UserCreateUpdateDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Photo { get; set; }
    }
}
