using Microsoft.EntityFrameworkCore;

namespace Contenter.Data;

public class Database(DbContextOptions<Database> options): DbContext(options)
{
  protected override void OnModelCreating(ModelBuilder mb)
  {
    base.OnModelCreating(mb);
  }
}
