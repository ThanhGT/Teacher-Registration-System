using System.Linq;

namespace Tran_Thanh_991515427_Exam.Models
{
    public class EFSystemRepository : ITeacherRepository
    {
        private MBS_DBContext context;
        public EFSystemRepository(MBS_DBContext ctx)
        {
            context = ctx;
        }
        //maps the teachers property defined by the ITeacherRepository interface onto the Teachers property 
        //defined by the MBS_DBContext class
        //teachers property implements the IQueryable<T> Interface 
        public IQueryable<Teacher> Teachers => context.Teachers;
    }
}