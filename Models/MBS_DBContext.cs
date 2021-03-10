using Microsoft.EntityFrameworkCore;

namespace Tran_Thanh_991515427_Exam.Models
{
    public class MBS_DBContext : DbContext
    {
        public MBS_DBContext(DbContextOptions<MBS_DBContext> options) : base(options)
        {

        }

        //entity
        public DbSet<Teacher> Teachers { get; set; }
    }
}
