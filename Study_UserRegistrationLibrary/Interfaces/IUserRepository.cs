using Study_UserRegistrationLibrary.Entities;
using Study_UserRegistrationLibrary.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_UserRegistrationLibrary.Interfaces
{
    public interface IUserRepository
    {
        public void Create(User user);
        public void Update(User user);
        public void Delete(User user);
        Task<IEnumerable<UserDto>> GetAll();
        Task<User> GetById(int id);
        Task<bool> SaveChangesAsync();
    }
}
