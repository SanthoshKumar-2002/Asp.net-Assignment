using Microsoft.EntityFrameworkCore;
using WebApi.Entities.Models;

namespace WebApi2.Entities
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PhoneNumber> phoneNumbers { get; set; }
        public DbSet<Email> emails { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<RefSet> refSets { get; set; }
        public DbSet<SetRef> Setrefs { get; set; }
        public DbSet<Types> Types { get; set; }


    }
}
