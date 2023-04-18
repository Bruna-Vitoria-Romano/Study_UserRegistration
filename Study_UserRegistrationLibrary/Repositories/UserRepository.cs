using Microsoft.EntityFrameworkCore;
using Study_UserRegistrationLibrary.Context;
using Study_UserRegistrationLibrary.Entities;
using Study_UserRegistrationLibrary.Entities.DTOs;
using Study_UserRegistrationLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_UserRegistrationLibrary.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextOrganizer _context;
        public UserRepository(ContextOrganizer context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            _context.Add(user);
        }

        public void Delete(User user) //Delete<T>(T entity)  where T : class Em casos genéricos
        {
            _context.Remove(user); //Aqui seria o entity
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await _context.Users
                .Select(x => new UserDto { Id = x.Id, Name = x.Name, Photo = x.Photo})
                .ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(User user)
        {
            _context.Update(user);
        }
    }
}
