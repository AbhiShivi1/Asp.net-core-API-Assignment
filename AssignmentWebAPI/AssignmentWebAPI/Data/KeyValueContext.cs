using Microsoft.EntityFrameworkCore;

namespace AssignmentWebAPI.Data
{
    public class KeyValueContext: DbContext
    {
        public KeyValueContext(DbContextOptions<KeyValueContext> options):base(options)
        {

        }

        public DbSet<KeyValue> KeyValue { get; set; }
    }
}
