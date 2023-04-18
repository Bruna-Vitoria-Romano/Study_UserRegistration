using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Study_UserRegistrationLibrary.Entities;

namespace Study_UserRegistrationLibrary.Context
{
    public class ContextOrganizer : DbContext
    {
        public ContextOrganizer(DbContextOptions<ContextOrganizer> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
