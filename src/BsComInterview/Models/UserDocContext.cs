using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BsComInterview.Models
{
    public class UserDocContext :DbContext
    {
        public UserDocContext(DbContextOptions<UserDocContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
