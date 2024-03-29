﻿using madera_erp_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_erp_api.Data
{
    public class DbMainContext : DbContext
    {
        public DbMainContext(DbContextOptions<DbMainContext> opt) : base(opt)
        {
        }

        public DbSet<User> User { get; set; }

    }
}
