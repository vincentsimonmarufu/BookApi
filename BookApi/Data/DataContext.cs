﻿using BookApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
    }
}