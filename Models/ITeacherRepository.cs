using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* interface used to store and retrieve data */
namespace Tran_Thanh_991515427_Exam.Models
{
    public interface ITeacherRepository
    {
        //allows caller to obtain a sequence of teacher objects
        IQueryable<Teacher> Teachers { get; }
    }
}