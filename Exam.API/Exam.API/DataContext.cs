﻿using Exam.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.API
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext>options):base(options)
        {
                
        }
        public DbSet<User> Users { get; set; }
    }
}
