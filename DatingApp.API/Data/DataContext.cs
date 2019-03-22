using System.ComponentModel.DataAnnotations;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base (options) {

        }

        [Key]
        public DbSet<Value> Values { get; set; }
    }
}