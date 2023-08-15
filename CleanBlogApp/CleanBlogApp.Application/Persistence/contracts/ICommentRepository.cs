using CleanBlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBlogApp.Application.Persistence.contracts;
public interface ICommentRepository : IGenericRepository<Comment>
{

}

