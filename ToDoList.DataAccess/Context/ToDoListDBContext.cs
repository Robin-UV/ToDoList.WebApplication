using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Models;

namespace ToDoList.DataAccess.Context
{
    public class ToDoListDBContext : DbContext
    {
        public ToDoListDBContext(DbContextOptions options) : base(options)
        {

        }

        protected ToDoListDBContext()
        {

        }

        public DbSet<ToDoListModels> ToDoListContext { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoListModels>(
                entity =>
                {
                    entity.HasKey(e => e.TaskID);
                    entity.Property(e => e.TaskID);
                    entity.Property(e => e.TaskName).HasMaxLength(250);
                    entity.Property(e => e.TaskDescription);
                    entity.Property(e => e.CreatedDate);
                    entity.Property(e => e.CompletedDate);
                    entity.Property(e => e.IsCompleted);
                    entity.Property(e => e.IsArchived);
                });
        }
    }
}
